using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class CategoryManager
    {
        public ObservableCollection<CategoryViewModel> Categories = new ObservableCollection<CategoryViewModel>();
        public int currentCategoryIndex = 0;
    }
}
