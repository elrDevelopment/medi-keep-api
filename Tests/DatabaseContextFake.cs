using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class DatabaseContextFake
    {
        
        public medikeepContext GetDatabaseItemContext()
        {
            var options = new DbContextOptionsBuilder<medikeepContext>()
                .UseSqlite("Filename= test.db")
                .Options;
            var databaseContext = new medikeepContext(options);
            databaseContext.Database.EnsureCreated();
           
            //seeding
            databaseContext.AddRange(GetMockData());
            return  databaseContext;
        }

  
        public List<Item> GetMockData()
        {
            var items = new List<Item>()
            {
                new Item() {Id=0,ItemName="ITEM 1",Cost=100, IsDeleted = false,
                    LastModifiedOn = DateTime.Now, ItemCategory = "products", 
                    ItemDescription = "Initial Item For Testing", ImageSrcUrl = "https://via.placeholder.com/150"},
                new Item() {Id=0,ItemName="ITEM 2",Cost=200, IsDeleted = false,
                    LastModifiedOn = DateTime.Now, ItemCategory = "products", 
                    ItemDescription = "Initial Item For Testing", ImageSrcUrl = "https://via.placeholder.com/150"},
                new Item() {Id=0,ItemName="ITEM 1",Cost=250, IsDeleted = false,
                    LastModifiedOn = DateTime.Now, ItemCategory = "products", 
                    ItemDescription = "Initial Item For Testing", ImageSrcUrl = "https://via.placeholder.com/150"},
                new Item() {Id=0,ItemName="ITEM 3",Cost=300, IsDeleted = false,
                    LastModifiedOn = DateTime.Now, ItemCategory = "products", 
                    ItemDescription = "Initial Item For Testing", ImageSrcUrl = "https://via.placeholder.com/150"},
                new Item() {Id=0,ItemName="ITEM 4",Cost=50, IsDeleted = false,
                    LastModifiedOn = DateTime.Now, ItemCategory = "products", 
                    ItemDescription = "Initial Item For Testing", ImageSrcUrl = "https://via.placeholder.com/150"},
                new Item() {Id=0,ItemName="ITEM 4",Cost=40, IsDeleted = false,
                    LastModifiedOn = DateTime.Now, ItemCategory = "products", 
                    ItemDescription = "Initial Item For Testing", ImageSrcUrl = "https://via.placeholder.com/150"},
                new Item() {Id=0,ItemName="ITEM 2",Cost=200, IsDeleted = false,
                    LastModifiedOn = DateTime.Now, ItemCategory = "products", 
                    ItemDescription = "Initial Item For Testing", ImageSrcUrl = "https://via.placeholder.com/150"},
            };

            return items;
        }

 
    }
}