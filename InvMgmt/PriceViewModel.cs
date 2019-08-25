using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class PriceViewModel : ViewModelBase
    {
        private Price price;

        public PriceViewModel() { price = new Price(); }
        public PriceViewModel(double _currentPrice, double _regularPrice, double _salePrice)
        {
            price = new Price();
            CurrentPrice = _currentPrice;
            RegularPrice = _regularPrice;
            SalePrice = _salePrice;
        }

        public double CurrentPrice
        {
            get { return price.CurrentPrice; }
            set
            {
                Console.WriteLine(value);
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
            return string.Format("Current Price: {0}, Regular Price: {1}, Sale Price: {2}", CurrentPrice, RegularPrice, SalePrice);
        }
    }
}
