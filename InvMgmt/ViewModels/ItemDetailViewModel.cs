using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;
namespace InvMgmt.Information.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private ItemDetail itemDetail;

        public ItemDetailViewModel() { itemDetail = new ItemDetail(); }
        public ItemDetailViewModel(string _company, string _address, string _phone, DateTime _date)
        {
            itemDetail = new ItemDetail();
            Company = _company;
            Address = _address;
            Phone = _phone;
            Date = _date;
        }

        public string Company
        {
            get { return itemDetail.Company; }
            set
            {
                if (itemDetail.Company == value)
                    return;
                itemDetail.Company = value;
                NotifyPropertyChanged("Company");
            }
        }

        public string Address
        {
            get { return itemDetail.Address; }
            set
            {
                if (itemDetail.Address == value)
                    return;
                itemDetail.Address = value;
                NotifyPropertyChanged("Address");
            }
        }

        public string Phone
        {
            get { return itemDetail.Phone; }
            set
            {
                if (itemDetail.Phone == value)
                    return;
                itemDetail.Phone = value;
                NotifyPropertyChanged("Phone");
            }
        }

        public DateTime Date
        {
            get { return itemDetail.Date; }
            set
            {
                if (itemDetail.Date == value)
                    return;
                itemDetail.Date = value;
                NotifyPropertyChanged("Date");
            }
        }
    }
}
