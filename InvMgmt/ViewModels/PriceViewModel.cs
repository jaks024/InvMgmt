using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;
namespace InvMgmt.Information.ViewModels
{
    public class PriceViewModel : ViewModelBase
    {
        private Price price;

        public PriceViewModel() { price = new Price(); }
        public PriceViewModel(double _currentPrice, double _regularPrice, double _salePrice, bool _onSale)
        {
            price = new Price();
			IsOnSale = _onSale; //infront to prevent value override
			CurrentPrice = _currentPrice;
            RegularPrice = _regularPrice;
            SalePrice = _salePrice;
        }
		public PriceViewModel(PriceViewModel p)
		{
			price = new Price();
			IsOnSale = p.IsOnSale;
			CurrentPrice = p.CurrentPrice;
			RegularPrice = p.RegularPrice;
			SalePrice = p.SalePrice;
		}
        public double CurrentPrice
        {
            get { return price.CurrentPrice; }
            set
            {
                if (price.CurrentPrice == value)
                    return;
                price.CurrentPrice = value;
                NotifyPropertyChanged("CurrentPrice");
            }
        }
        public double RegularPrice
        {
            get { return price.RegularPrice; }
            set
            {
                if (price.RegularPrice == value)
                    return;
                price.RegularPrice = value;
                NotifyPropertyChanged("RegularPrice");
            }
        }
        public double SalePrice
        {
            get { return price.SalePrice; }
            set
            {
                if (price.SalePrice == value)
                    return;
                price.SalePrice = value;
                NotifyPropertyChanged("SalePrice");
            }
        }

        public bool IsOnSale
        {
            get { return price.IsOnSale; }
            set
            {
                if (price.IsOnSale == value)
                    return;
                price.IsOnSale = value;
                CurrentPrice = value ? SalePrice : RegularPrice;
                NotifyPropertyChanged("IsOnSale");
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", CurrentPrice, RegularPrice, SalePrice, IsOnSale ? 1 : 0);
        }

		public string ToStringDetailed()
		{						
			return string.Format("Prices -\t\t Current: {0},  Regular: {1},  Sale: {2},  On Sale: {3}", CurrentPrice, RegularPrice, SalePrice, IsOnSale ? 1 : 0);
		}
		public string SearchQuery()
		{
			return CurrentPrice.ToString() + "/" + SalePrice.ToString() + "/" + RegularPrice.ToString() + "/" + (IsOnSale ? "sale" : "not");
		}


		//public override bool Equals(object obj)
		//{
		//	PriceViewModel p = (PriceViewModel)obj;
		//	if (CurrentPrice == p.CurrentPrice && RegularPrice == p.RegularPrice
		//		&& SalePrice == p.SalePrice && IsOnSale == p.IsOnSale)
		//		return true;
		//	return false;
		//}
	}
}
