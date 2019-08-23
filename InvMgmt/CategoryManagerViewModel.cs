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
            Console.WriteLine("added: " + manager.Categories.Count);
            foreach (CategoryViewModel c in manager.Categories)
                Console.WriteLine(c.ToString());
        }
    }
}
