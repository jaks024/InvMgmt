using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;
namespace InvMgmt.Information.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private Item item;
        public ItemViewModel() { item = new Item(); }
        public ItemViewModel(string _id, string _name, string _desc, string _cat, QuantityViewModel _quantity, PriceViewModel _price, ItemDetailViewModel _detail)
        {
            item = new Item();
            Id = _id;
            Name = _name;
            Description = _desc;
            Category = _cat;
            Quantity = _quantity;
            Price = _price;
            Detail = _detail;
        }

        public string Id
        {
            get { return item.Id; }
            set
            {
                if (item.Id == value)
                    return;
                item.Id = value;
                NotifyPropertyChanged("Id");
                Console.WriteLine(item.Id);
            }
        }

        public string Name
        {
            get { return item.Name; }
            set
            {
                if (item.Name == value)
                    return;
                item.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return item.Description; }
            set
            {
                if (item.Description == value)
                    return;
                item.Description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string Category
        {
            get { return item.Category; }
            set
            {
                if (item.Category == value)
                    return;
                item.Category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public QuantityViewModel Quantity
        {
            get { return item.Quantity; }
            set
            {
                if (item.Quantity == value)
                    return;
                item.Quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        public PriceViewModel Price
        {
            get { return item.Price; }
            set
            {
                if (item.Price == value)
                    return;
                item.Price = value;
                NotifyPropertyChanged("Price");
            }
        }

        public ItemDetailViewModel Detail
        {
            get { return item.Detail; }
            set
            {
                if (item.Detail == value)
                    return;
                item.Detail = value;
                NotifyPropertyChanged("Detail");
            }
        }

        public override string ToString()
        {
            return string.Format("'{0}', '{1}', '{2}', '{3}', {4}, {5}, {6}", 
				Id, Name, Description, Category, 
				Quantity.ToString(), Price.ToString(), Detail.ToString());
        }
    }
}
