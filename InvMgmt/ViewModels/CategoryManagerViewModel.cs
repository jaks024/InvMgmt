﻿using System;
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

        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                if (IsCategoryEmpty)
                    return null;
                return manager.Categories[CurrentCategoryIndex].Items;
            }
        }

        public void ChangeSingleItemCategory(ItemViewModel _item, CategoryViewModel _changeTo)
        {
            FindCategoryUsingName(_item.Category).RemoveItem(_item);
            _item.Category = _changeTo.Name;
            Categories[Categories.IndexOf(_changeTo)].AddItem(_item);
        }

		public CategoryViewModel FindCategoryUsingName(string _name)
		{
			for(int i = 0; i < categoryCount; i++)
			{
				if (Categories[i].Name.Equals(_name))
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
                NotifyPropertyChanged("Items");
            }
        }

        public void AddCategoryToList(CategoryViewModel _cat)
        {
            Categories.Add(_cat);
            UpdateCategoryCount();
        }

        public void RemoveCategoryFromList(CategoryViewModel _cat)
        {
            Categories.Remove(_cat);
            UpdateCategoryCount();
        }

        public void AddNewItemToCategory(CategoryViewModel _cat, ItemViewModel _item)
        {
            _item.Category = _cat.Name;
            Categories[Categories.IndexOf(_cat)].AddItem(_item);
            NotifyPropertyChanged("Items");
        }
		public void AddListItemToCategoryFromDatabase(ObservableCollection<ItemViewModel> _item)
		{
			if (_item.Count == 0)
				return;
			FindCategoryUsingName(_item[0].Category).AddItem(_item);
			NotifyPropertyChanged("Items");
		}
		private void UpdateCategoryCount()
        {
            CategoryCount = Categories.Count;
        }
        public bool IsCategoryEmpty
        {
            get { return CategoryCount > 0 ? false : true; }
        }
    }
}
