using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class ItemFormViewModel : ItemViewModel
    {
        public void Reset()
        {
            base.Item = new Item();
            Console.WriteLine("cleared: " + Id);
        }

    }
}
