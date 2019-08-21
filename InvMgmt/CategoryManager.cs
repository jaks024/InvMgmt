using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    class CategoryManager
    {
        public ObservableCollection<CategoryViewModel> Categories { get; } = new ObservableCollection<CategoryViewModel>();
        public int currentCategoryIndex = 0;

        public void AddNewCategory(CategoryViewModel _cat)
        {
            Categories.Add(_cat);
        }
    }
}
