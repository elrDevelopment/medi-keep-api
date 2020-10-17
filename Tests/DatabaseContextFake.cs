using System.Collections.Generic;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class DatabaseContextFake
    {
        public medikeepContext GetDatabaseItemContext()
        {
            var options = new DbContextOptionsBuilder<medikeepContext>()
                .UseSqlite("filename: test.db")
                .Options;
            var databaseContext = new medikeepContext(options);
            databaseContext.Database.EnsureCreated();
            //seeding
            databaseContext.AddRange(GetMockData());
            return databaseContext;
        }

        public List<Item> GetMockData()
        {
            var items = new List<Item>()
            {
                new Item() {Id=1,ItemName="ITEM 1",Cost=100},
                new Item() {Id=2,ItemName="ITEM 2",Cost=200},
                new Item() {Id=3,ItemName="ITEM 1",Cost=250},
                new Item() {Id=4,ItemName="ITEM 3",Cost=300},
                new Item() {Id=5,ItemName="ITEM 4",Cost=50},
                new Item() {Id=6,ItemName="ITEM 4",Cost=40},
                new Item() {Id=7,ItemName="ITEM 2",Cost=200},
            };

            return items;
        }
    }
}