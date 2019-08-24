using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
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
            }
        }

        public void AddCategoryToList(CategoryViewModel _cat)
        {
            Categories.Add(_cat);
            UpdateCategoryCount();
            Console.WriteLine("added: " + manager.Categories.Count);
            foreach (CategoryViewModel c in manager.Categories)
                Console.WriteLine(c.ToString());

        }

        public void RemoveCategoryFromList(CategoryViewModel _cat)
        {
            Categories.Remove(_cat);
            UpdateCategoryCount();
            Console.WriteLine("remove: " + manager.Categories.Count);
            foreach (CategoryViewModel c in manager.Categories)
                Console.WriteLine(c.ToString());
        }

        public void AddNewItemToCategory(CategoryViewModel _cat, ItemViewModel _item)
        {
            Categories[Categories.IndexOf(_cat)].AddItem(_item);
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
