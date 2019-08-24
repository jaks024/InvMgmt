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
        }

        public bool IsDetailFull
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Detail.Company) &&
                    !string.IsNullOrWhiteSpace(Detail.Address) &&
                    Detail.Date != null &&
                    !string.IsNullOrWhiteSpace(Detail.Company) ? true : false;
            }
        }

        public bool IsItemFull
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Id) &&
                    !string.IsNullOrWhiteSpace(Name) &&
                    !string.IsNullOrWhiteSpace(Description) ? true : false;
            }
        }

        public bool CanAddItem
        {
            get
            {
                return IsItemFull ? true : false;
            }
        }
    }
}
