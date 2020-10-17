using System;
using System.Collections.Generic;

namespace DataAccess
{
    public partial class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal? Cost { get; set; }
    }
}
