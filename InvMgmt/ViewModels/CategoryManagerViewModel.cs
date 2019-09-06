using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;
namespace InvMgmt.Information.ViewModels
{
    public class CategoryManagerViewModel : ViewModelBase
    {
        private CategoryManager manager;
        public CategoryManagerViewModel() { manager = new CategoryManager(); }
        public CategoryManagerViewModel(ObservableCollection<CategoryViewModel> _catCol)
        {
            manager = new CategoryManager();
            Categories = _catCol;
        }

        public ObservableCollection<CategoryViewModel> Categories
        {
            get { return manager.Categories; }
            set
            {
                if (manager.Categories == value)
                    return;
                manager.Categories = value;
                NotifyPropertyChanged("Categories");
            }
        }

		//used in xaml view
        public ObservableCollection<ItemViewModel> SelectedCategoryItems
        {
            get
            {
                if (IsCategoryEmpty() || CurrentCategoryIndex == -1)
                    return new ObservableCollection<ItemViewModel>();
                return manager.Categories[CurrentCategoryIndex].Items;
            }
        }

        public void ChangeSingleItemCategory(ItemViewModel _item, CategoryViewModel _changeTo)
        {
            FindCategoryUsingId(_item.Category).RemoveItem(_item);
			SaveDataHandler.SwapItemTable(_item, _changeTo.Id);
			_item.Category = _changeTo.Id;
            Categories[Categories.IndexOf(_changeTo)].AddItem(_item);
        }

		public CategoryViewModel FindCategoryUsingId(string _name)
		{
			for(int i = 0; i < categoryCount; i++)
			{
				if (Categories[i].Id.Equals(_name))
					return Categories[i];
			}
			return Categories[0];
		}

        private int categoryCount = 0;
        public int CategoryCount { get { return categoryCount; } set { categoryCount = value; NotifyPropertyChanged("CategoryCount"); } }

        public int CurrentCategoryIndex
        {
            get { return manager.currentCategoryIndex; }
            set
            {
                if (manager.currentCategoryIndex == value)
                    return;
                manager.currentCategoryIndex = value;
                NotifyPropertyChanged("CurrentCategoryIndex");
                NotifyPropertyChanged("SelectedCategoryItems");
            }
        }

		public CategoryViewModel CurrentSelectedCategory
		{
			get { return IsCategoryEmpty() || CurrentCategoryIndex == -1 ? new CategoryViewModel() : Categories[CurrentCategoryIndex]; }
		}
		public void RefreshInventoryItemCount()
		{
			if (CurrentSelectedCategory == null)
				return;
			CurrentSelectedCategory.RefreshItemCount();
		}
        public void AddCategoryToList(CategoryViewModel _cat)
        {
            Categories.Add(_cat);
            UpdateCategoryCount();
        }
		public void AddCategoryToListFromDatabase(ObservableCollection<CategoryViewModel> _cat)
		{
			for(int i = 0; i < _cat.Count; i++)
			{
				Categories.Add(_cat[i]);
			}
			UpdateCategoryCount();
			NotifyPropertyChanged("Categories");
		}

        public void RemoveCategoryFromList(CategoryViewModel _cat)
        {
            Categories.Remove(_cat);
            UpdateCategoryCount();
			NotifyPropertyChanged("Categories");
		}

        public void AddNewItemToCategory(CategoryViewModel _cat, ItemViewModel _item)
        {
            _item.Category = _cat.Id;
            Categories[Categories.IndexOf(_cat)].AddItem(_item);
			NotifyPropertyChanged("SelectedCategoryItems");
        }
		public void AddListItemToCategoryFromDatabase(int index, ObservableCollection<ItemViewModel> _item)
		{
			if (_item.Count == 0)
				return;
			Categories[index].AddItem(_item);
			NotifyPropertyChanged("SelectedCategoryItems");
		}
		private void UpdateCategoryCount()
        {
            CategoryCount = Categories.Count;
        }
        public bool IsCategoryEmpty()
        {
            return CategoryCount == 0 ? true : false; 
        }
    }
}
