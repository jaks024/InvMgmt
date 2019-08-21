using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class Item 
    {
        public int Id;
        public string Name;
        public string Description;
        public CategoryViewModel Category;
        public QuantityViewModel Quantity;
        public PriceViewModel Price;
        public ItemDetailViewModel Detail;
    }
}
