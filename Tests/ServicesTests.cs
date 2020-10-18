using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using AutoMapper;
using DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services;


namespace Tests
{
    [TestClass]
    public class ServicesTests
    {
        private IMapper mapper;
        private medikeepContext context;
        private ItemService service;
        private ItemValidator validator;

        [TestInitialize]
        public void Setup()
        {
            mapper = BaseTest.GetMapper();
            context = BaseTest.GetContext();
            validator = BaseTest.GetValidator();
            service = new ItemService(context, validator, mapper);
        }

      
        
        
        [TestMethod]
        public void Context_for_MediKeep_Should_exist()
        {
            var context = new medikeepContext();
            
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void Class_for_Table_Item_should_exist()
        {
            var entity = new Item();
            
            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void ItemService_should_be_able_to_add_an_item()
        {
            //arrange
            var item = new ItemDTO()
            {
                Id = 0, Cost = 4000, ItemName = "Item40"
            };
            //act
            var createReturn = service.CreateItem(item);
           
            //assert
            Assert.AreEqual(8, createReturn.Count());
   
        }
        
        [TestMethod]
        [ExpectedException(typeof(FluentValidation.ValidationException))]
        public void ItemService_should_be_able_detect_invalid_DataObject_with_negative_cost()
        {
            //arrange
            var item = new ItemDTO()
            {
                Id = 0, Cost = -4000, ItemName = "Item40"
            };
            //act
            
            var createReturn = service.CreateItem(item);
            
            

        }
        [TestMethod]
        [ExpectedException(typeof(FluentValidation.ValidationException))]
        public void ItemService_should_be_able_detect_invalid_DataObject_with_Empty_ItemName()
        {
            //arrange
            var item = new ItemDTO()
            {
                Id = 0, Cost = 400, ItemName = ""
            };
            //act
            var createReturn = service.CreateItem(item);

        }
        [TestMethod]
        public void ItemService_should_be_able_to_return_Item_given_Id()
        {
            //arrange
            var item = service.GetItemById(1);
            
            Assert.AreEqual("ITEM 1", item.ItemName);
        }

        [TestMethod]
        public void ItemService_should_be_able_to_return_list_given_ItemName()
        {
            //arrange
            var item = service.GetAllItemByName("ITEM 1");
            
            //assert;
            Assert.AreEqual(2, item.Count());
        }
        [TestMethod]
        public void ItemService_should_be_able_update_item()
        {
            //arrange
            var item = new ItemDTO()
            {
                Id = 1, Cost = 4000, ItemName = "ITEM 1"
            };
            //act
            var result = service.UpdateItem(item);
            var updatedItem = context.Item.Find(1);
            
            //Assert
            Assert.AreEqual(4000, updatedItem.Cost);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void ItemService_should_return_false_for_update_when_item_doesnot_exist()
        {
            //arrange
            var item = new ItemDTO()
            {
                Id = 195, Cost = 4000, ItemName = "ITEM 1"
            };
            //act
            var result = service.UpdateItem(item);
       
            
            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void ItemService_should_be_able_to_return_max_cost_given_ItemName()
        {
            //arrange
            var maxCostForSelectedItem = service.GetMaxCostForItemName("ITEM 1");
            
            //assert
            Assert.AreEqual(250, maxCostForSelectedItem);
        }
        
        [TestMethod]
        public void ItemService_should_be_able_to_return_max_cost_grouped_ItemName()
        {
            //arrange
            var maxCostForSelectedItem = service.GetMaxCostForItems();
            
            //act
            var itemOne = maxCostForSelectedItem.Where(w => w.ItemName == "ITEM 1").First();
            //assert
            Assert.AreEqual(4000, itemOne.MaxCost);
        }

        
        [TestMethod]
        public void ItemService_should_be_able_to_list_all_items()
        {
            //arrange
            var allItems = service.GetAllItems();
            
            
            Assert.AreEqual(8, allItems.Count());
        }
        [ClassCleanup]
        public static void Cleanup()
        {
            BaseTest.CleanupData();
        }
        
    }
}