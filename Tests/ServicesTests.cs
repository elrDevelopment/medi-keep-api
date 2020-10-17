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
            context = BaseTest.GetFakeContext().GetDatabaseItemContext();
            validator = new Mock<ItemValidator>().Object;
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
        public void Services_should_be_able_to_add_an_item()
        {
            //arrange
            var item = new ItemDTO()
            {
                Id = 0, Cost = 4000, ItemName = "Item40"
            };
            //act
            var createReturn = service.CreateItem(item);
            var totalItems = context.Item.Count();
            //assert
            Assert.AreEqual(totalItems, createReturn.Count());
   
        }
        
    }
}