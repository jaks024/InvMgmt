using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class ItemViewModel : ViewModelBase
    {
        private Item item;

        public ItemViewModel() { }
        public ItemViewModel(int _id, string _name, string _desc, CategoryViewModel _cat, int _quantity, double _price)
        {
            item = new Item();
            Id = _id;
            Name = _name;
            Description = _desc;
            Category = _cat;
            Quantity = _quantity;
            Price = _price;
        }

        public int Id
        {
            get { return item.Id; }
            set
            {
                if (item.Id != value)
                {
                    item.Id = value;
                    NotifyPropertyChanged("Id");
                } 
            }
        }

        public string Name
        {
            get { return item.Name; }
            set
            {
                if(item.Name != value)
                {
                    item.Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return item.Description; }
            set
            {
                if(item.Description != value)
                {
                    item.Description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public CategoryViewModel Category
        {
            get { return item.Category; }
            set
            {
                if (item.Category != value)
                {
                    item.Category = value;
                    NotifyPropertyChanged("Category");
                }
            }
        }

        public int Quantity
        {
            get { return item.Quantity; }
            set
            {
                if(item.Quantity != value)
                {
                    item.Quantity = value;
                    NotifyPropertyChanged("Quantity");
                }
            }
        }

        public double Price
        {
            get { return item.Price; }
            set
            {
                if(item.Price != value)
                {
                    item.Price = value;
                    NotifyPropertyChanged("Price");
                }
            }
        }
    }
}
