using System;
using System.Collections.Generic;

namespace DataAccess
{
    public partial class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal? Cost { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCategory { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string ImageSrcUrl { get; set; }
    }
}
