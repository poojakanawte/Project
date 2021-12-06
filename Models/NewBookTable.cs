using System;
using System.Collections.Generic;

#nullable disable

namespace BookDatabaseApi.Models
{
    public partial class NewBookTable
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public int? AvailableQuantity { get; set; }
        public int? Price { get; set; }
        public string ImagePath { get; set; }
    }
}
