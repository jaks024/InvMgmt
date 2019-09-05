using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;
namespace InvMgmt.Information.ViewModels
{
    public class ItemFormViewModel : ViewModelBase
    {
        private ItemViewModel item;

        public ItemFormViewModel()
        {
            item = new ItemViewModel();
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

        public ItemViewModel GetItem
        {
            get { return item; }
        }
        public void Reset()
        {
            item = new ItemViewModel();
            NotifyPropertyChanged("");
        }

        public bool IsDetailFull
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Detail.Company) &&
                    !string.IsNullOrWhiteSpace(Detail.Address) &&
                    Detail.Date != null &&
                    !string.IsNullOrWhiteSpace(Detail.Company) ? true : false;
            }
        }

        public bool IsItemFull
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Id) &&
                    !string.IsNullOrWhiteSpace(Name) &&
                    !string.IsNullOrWhiteSpace(Description) ? true : false;
            }
        }
		public bool IsIdValid(CategoryManagerViewModel _man)
		{
			for (int i = 0; i < _man.CategoryCount; i++)
			{
				_man.CurrentCategoryIndex = i;
				for (int j = 0; j < _man.SelectedCategoryItems.Count; j++)
				{
					if (_man.SelectedCategoryItems[j].Id.Equals(Id))
						return false;
				}
			}
			return true;
		}

		public bool CanAddItem
        {
            get
            {
                return IsItemFull ? true : false;
            }
        }
    }
}
