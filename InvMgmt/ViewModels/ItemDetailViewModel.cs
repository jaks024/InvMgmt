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
        public ItemDetailViewModel(string _company, string _address, string _phone, string _email, DateTime _date)
        {
            itemDetail = new ItemDetail();
            Company = _company;
            Address = _address;
            Phone = _phone;
			Email = _email;
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

		public string Email
		{
			get { return itemDetail.Email; }
			set
			{
				if (itemDetail.Email == value)
					return;
				itemDetail.Email = value;
				NotifyPropertyChanged("Email");
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

		public override string ToString()
		{
			return string.Format("'{0}', '{1}', '{2}', '{3}', '{4}'", Company, Address, Phone, Email, DateTimeSQLite(Date));
		}
		public string ToStringDetailed()
		{						
			return string.Format("Details -\t\t Company: {0},  Address: {1},  Phone: {2},  Email: {3},  Date: {4}", Company, Address, Phone, Email, DateTimeSQLite(Date));
		}
		public string DateTimeSQLite(DateTime _datetime)
		{
			return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", _datetime.Year, _datetime.Month, _datetime.Day, _datetime.Hour, _datetime.Minute, _datetime.Second, _datetime.Millisecond);
		}

		public string SearchQuery()
		{
			return Company + "/" + Address + "/" + Phone + "/" + Email + "/" + Date.ToLongDateString() + "/" + DateTimeSQLite(Date);
		}

		//public override bool Equals(object obj)
		//{
		//	ItemDetailViewModel i = (ItemDetailViewModel)obj;
		//	if (Company.Equals(i.Company) && Address.Equals(i.Address) && Phone.Equals(i.Phone)
		//		&& Email.Equals(i.Email) && Date.Equals(i.Date))
		//		return true;
		//	return false;
		//}
	}
}
