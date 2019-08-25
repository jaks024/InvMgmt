using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
namespace InvMgmt.Information.Objects
{
    public class CategoryManager
    {
        public ObservableCollection<CategoryViewModel> Categories = new ObservableCollection<CategoryViewModel>();
        public int currentCategoryIndex = 0;
    }
}
