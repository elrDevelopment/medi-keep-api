using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Fakes;

namespace Tests
{
    [TestClass]
    public class ServicesTests: FakeContext, IDisposable
    {
        private readonly DbConnection _connection;
        
        public ServicesTests()        : base(
            new DbContextOptionsBuilder<medikeepContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options)
        {
            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }

       
        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();
            
            return connection;
        }

        public void Dispose() => _connection.Dispose();
        
        
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
            _connection
        }
        
    }
}