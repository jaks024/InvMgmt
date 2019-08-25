using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
namespace InvMgmt.Information.Objects
{
    public class Category
    {
        public string Id;
        public string Name;
        public string Description;
        public ObservableCollection<ItemViewModel> Items = new ObservableCollection<ItemViewModel>();

    }
}
