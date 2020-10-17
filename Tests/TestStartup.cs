using MediKeeperPricing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Tests
{
    public class TestStartup: Startup
    {
        private IConfiguration config;
        public TestStartup(IConfiguration config, IWebHostEnvironment env) : base(config) { }
    }
}