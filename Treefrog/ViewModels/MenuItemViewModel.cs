using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Treefrog.Services;
using Treefrog.Models;
using MenuItem = Treefrog.Models.MenuItem;

namespace Treefrog.ViewModels
{
    public class MenuItemViewModel : INotifyPropertyChanged
    {
        public MenuItem MenuItem { get; }

        // Quantity property to bind to the label in the view
        private int _quantity;
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

        
        public ICommand IncrementQuantityCommand { get; }
        public ICommand DecrementQuantityCommand { get; }

        public MenuItemViewModel(MenuItem menuItem, ICommand incrementCommand, ICommand decrementCommand)
        {
            MenuItem = menuItem;
            IncrementQuantityCommand = incrementCommand;
            DecrementQuantityCommand = decrementCommand;
            Quantity = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
