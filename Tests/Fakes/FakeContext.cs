using DataAccess;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.Fakes
{
    public static class FakeContext
    {
    
        public static Mock<medikeepContext> MockContext()
        {
            return new Mock<medikeepContext>();
        }
        
        public static Mock<DbSet<Item>> MockItems()
        {
            return new Mock<DbSet<Item>>();
        }
    }
}