using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        private static IMapper mapper;
        private static medikeepContext dbContext;
        private static DatabaseContextFake fakes;
        private static ItemValidator validator;
        [AssemblyInitialize]
        public static void Setup(TestContext tc)
        {
            //build startup pipeline for test
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>().Build();
            mapper = webHost.Services.GetService(typeof(IMapper)) as IMapper;
            //seed data for item entity
            validator = webHost.Services.GetService(typeof(ItemValidator)) as ItemValidator;
            fakes = new DatabaseContextFake();
            dbContext = fakes.GetDatabaseItemContext();

        }

        public static medikeepContext GetContext()
        {
            return dbContext;
        }
        public static IMapper GetMapper()
        {
            return mapper;
        }
        public static ItemValidator GetValidator()
        {
            return validator;
        }
        public static DatabaseContextFake GetFakeContext()
        {
            return fakes;
        }
        
        public static void CleanupData()
        {
            //startup
            var all = dbContext.Item.ToList();
            dbContext.RemoveRange(all);
            dbContext.Database
                .ExecuteSqlRaw("UPDATE SQLITE_SEQUENCE SET SEQ= '0' WHERE NAME='Item';");
            dbContext.SaveChanges();


        }
     
        
    }
}
