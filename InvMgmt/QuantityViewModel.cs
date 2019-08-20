using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class QuantityViewModel : ViewModelBase
    {
        private Quantity quantity;

        public QuantityViewModel() { quantity = new Quantity(); }
        public QuantityViewModel(int _total, int _today, int _weekly, int _monthly)
        {
            quantity = new Quantity();
            Total = _total;
            Today = _today;
            Weekly = _weekly;
            Monthly = _monthly;
        }

        public int Total
        {
            get { return quantity.totalAvailable; }
            set
            {
                if (quantity.totalAvailable == value)
                    return;
                quantity.totalAvailable = value;
                NotifyPropertyChanged("Total");
            }
        }

        public int Today
        {
            get { return quantity.usedToday; }
            set
            {
                if (quantity.usedToday == value)
                    return;
                quantity.usedToday = value;
                NotifyPropertyChanged("Daily");
            }
        }

        public int Weekly
        {
            get { return quantity.usedWeekly; }
            set
            {
                if (quantity.usedWeekly == value)
                    return;
                quantity.usedWeekly = value;
                NotifyPropertyChanged("Weekly");
            }
        }

        public int Monthly
        {
            get { return quantity.usedMonthly; }
            set
            {
                if (quantity.usedMonthly == value)
                    return;
                quantity.usedMonthly = value;
                NotifyPropertyChanged("Monthly");
            }
        }
    }
}
