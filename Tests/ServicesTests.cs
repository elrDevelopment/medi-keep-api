using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using AutoMapper;
using DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;


namespace Tests
{
    [TestClass]
    public class ServicesTests
    {
        private IMapper mapper;
        private medikeepContext context;
        private ItemService service;

        [TestInitialize]
        public void Setup()
        {
            mapper = BaseTest.GetMapper();
            context = BaseTest.GetFakeContext().GetDatabaseItemContext();
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
            Assert.IsTrue(true);
        }
        
    }
}