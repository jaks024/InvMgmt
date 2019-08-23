using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class CategoryViewModel : ViewModelBase
    {
        private Category category;

        public CategoryViewModel() { category = new Category(); }
        public CategoryViewModel(string _id, string _name, string _desc)
        {
            category = new Category();
            Id = _id;
            Name = _name;
            Description = _desc;
        }
        public string Id
        {
            get { return category.Id; }
            set
            {
                if (category.Id == value)
                    return;
                category.Id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return category.Name; }
            set
            {
                if (category.Name == value)
                    return;
                category.Name = value;
                NotifyPropertyChanged("Name");
                Console.WriteLine(category.Name);
            }
        }

        public string Description
        {
            get { return category.Description; }
            set
            {
                if (category.Description == value)
                    return;
                category.Description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public ObservableCollection<ItemViewModel> Items
        {
            get { return category.Items; }
            set
            {
                if (category.Items == value)
                    return;
                category.Items = value;
                NotifyPropertyChanged("Items");
            }
        }
        public string ItemCount { get { return Items.Count.ToString(); } }

        public void AddItem(ItemViewModel _item)
        {
            category.Items.Add(_item);
        }

        public override string ToString()
        {
            return string.Format("Id: {0},  Name: {1},  Desc: {2}", Id, Name, Description);
        }
    }
}
