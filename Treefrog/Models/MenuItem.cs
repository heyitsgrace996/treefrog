using System;
namespace Treefrog.Models
{
    public class MenuItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // New Category property

        public MenuItem(string name, double price, string description, string category)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Price = price;
            Description = description;
            Category = category;
        }
    }


}

