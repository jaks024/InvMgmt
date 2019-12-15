using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
namespace InvMgmt.Information.Objects
{
    public class Item 
    {
        public string Id = "";
        public string Name = "";
        public string Description = "";
        public string Category = "";
        public QuantityViewModel Quantity = new QuantityViewModel();
        public PriceViewModel Price = new PriceViewModel();
        public ItemDetailViewModel Detail = new ItemDetailViewModel();
    }
}
