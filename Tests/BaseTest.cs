using System.Collections.Generic;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        private static IMapper mapper;
        private static medikeepContext dbContext;
        private static DatabaseContextFake fakes;

        [AssemblyInitialize]
        public static void Setup(TestContext tc)
        {
            //build startup pipeline for test
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>().Build();
            mapper = webHost.Services.GetService(typeof(IMapper)) as IMapper;
            //seed data for item entity
            
            fakes = new DatabaseContextFake();
            
        }

        public static IMapper GetMapper()
        {
            return mapper;
        }
        

        public static DatabaseContextFake GetFakeContext()
        {
            return fakes;
        }
        
    }
}