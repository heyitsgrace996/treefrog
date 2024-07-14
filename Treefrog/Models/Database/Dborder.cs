using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Treefrog.Models.Database
{
    public class DbOrder
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CollectionDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<DbOrderItem> Items { get; set; }
    }

    public class DbOrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public DbOrder Order { get; set; }
    }
}