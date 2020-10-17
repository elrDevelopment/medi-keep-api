using System.Collections.Generic;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    public class BaseTest
    {
        private static IMapper mapper;
        private static medikeepContext dbContext;
        

        [AssemblyInitialize]
        public void Setup()
        {
            //build startup pipeline for test
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>().Build();
            mapper = webHost.Services.GetService(typeof(IMapper)) as IMapper;
            //seed data for item entity
            
            dbContext = new DatabaseContextFake().GetDatabaseCustomerContext();
            
            
        }
      
        
        public static IMapper GetMapper()
        {
            return mapper;
        }

 

        public static medikeepContext GetDbContext()
        {
            return dbContext;
        }

        public static DatabaseContextFake GetFakeContext()
        {
            return fakes;
        }
        
    }
}