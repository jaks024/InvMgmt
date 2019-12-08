using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InvMgmt.Information.Objects;
namespace InvMgmt.Information.ViewModels
{
    public class QuantityViewModel : ViewModelBase
    {
        private Quantity quantity;

        public QuantityViewModel() { quantity = new Quantity(); }
        public QuantityViewModel(int _total, int _today, int _weekly, int _monthly, int _annually, int _usedTotal)
        {
            quantity = new Quantity();
            Total = _total;
            Today = _today;
            Weekly = _weekly;
            Monthly = _monthly;
			Annually = _annually;
			UsedTotal = _usedTotal;
        }
		public QuantityViewModel(QuantityViewModel q)
		{
			quantity = new Quantity();
			Total = q.Total;
			Today = q.Today;
			Weekly = q.Weekly;
			Monthly = q.Monthly;
			Annually = q.Annually;
			UsedTotal = q.UsedTotal;
		}

        public int Total
        {
            get { return quantity.totalAvailable; }
            set
            {
                if (quantity.totalAvailable == value)
                    return;
                quantity.totalAvailable = value;
                Console.WriteLine("quantity " + quantity.totalAvailable);
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

        public int Annually
        {
            get { return quantity.usedAnnually; }
            set
            {
                if (quantity.usedAnnually == value)
                    return;
                quantity.usedAnnually = value;
                NotifyPropertyChanged("Annually");
            }
        }

		public int UsedTotal
		{
			get { return quantity.usedTotal; }
			set
			{
				if (quantity.usedTotal == value)
					return;
				quantity.usedTotal = value;
				NotifyPropertyChanged("UsedTotal");
			}
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Total, Today, Weekly, Monthly, Annually, UsedTotal);
		}

		public string ToStringDetailed()
		{
			return string.Format("Quantities -\t Total: {0},  Today: {1},  Weekly: {2},  Monthly: {3},  Annually: {4},  Used Total: {5}", Total, Today, Weekly, Monthly, Annually, UsedTotal);
		}

		public string SearchQuery()
		{
			return Today.ToString() + "/" + Weekly.ToString() + "/" + Monthly.ToString() + "/" + Annually.ToString() + "/" + UsedTotal.ToString();
		}

		//public override bool Equals(object obj)
		//{
		//	QuantityViewModel q = (QuantityViewModel)obj;
		//	if (Total == q.Total && Today == q.Today && Weekly == q.Weekly
		//		&& Monthly == q.Monthly && Annually == q.Annually && UsedTotal == q.UsedTotal)
		//		return true;
		//	return false;
		//}
	}
}
