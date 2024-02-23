using System.ComponentModel;

namespace Treefrog.Models
{
    public class MenuItem : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }


        public decimal ItemTotalPrice => (decimal)(Price * Quantity);

        public MenuItem(int id, string name, double price, string description, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Quantity = 0;
        }

        private int _quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }


        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

}