using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;

namespace InvMgmt.Information.ViewModels
{
    public class CategoryViewModel : ViewModelBase, ISearchable
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
		public CategoryViewModel(CategoryViewModel cat)
		{
			category = new Category();
			Id = cat.Id;
			Name = cat.Name;
			Description = cat.Description;
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
		public string IdDb
		{
			get { return "[" + Id + "]"; }
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

        public void AddItem(ItemViewModel _item)
        {
            category.Items.Add(_item);
			NotifyPropertyChanged("ItemCount");
			NotifyPropertyChanged("Item");
		}
		public void AddItem(ObservableCollection<ItemViewModel> _item)
		{
			for(int i = 0; i < _item.Count; i++)
			{
				category.Items.Add(_item[i]);
			}
			NotifyPropertyChanged("ItemCount");
			NotifyPropertyChanged("Item");
		}
		public void RemoveItem(ItemViewModel _item)
        {
            category.Items.Remove(_item);
			NotifyPropertyChanged("ItemCount");
			NotifyPropertyChanged("Item");
		}

        public override string ToString()
        {
            return string.Format("'{0}', '{1}', '{2}'", Id, Name, Description);
        }

		public string ToStringDetailed()
		{
			return string.Format("Id: {0}, Name: {1}, Description: {2}", Id, Name, Description);
		}

		public string SearchQuery()
		{
			return Id + "/" + Name + "/" + Description;
		}
    }
}
