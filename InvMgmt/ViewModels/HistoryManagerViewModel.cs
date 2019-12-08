using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;
namespace InvMgmt.Information.ViewModels
{
	public enum HistoryActionType
	{
		Added, Changed, Removed
	}

	public class HistoryManagerViewModel : ViewModelBase
	{
		private HistoryManager manager;
		public HistoryManagerViewModel() { manager = new HistoryManager(); }
		public HistoryManagerViewModel(ObservableCollection<HistoryItem> item)
		{
			manager = new HistoryManager();

		}

		public ObservableCollection<HistoryItemViewModel> Histories
		{
			get { return manager.Histories; }
			set
			{
				if (manager.Histories == value)
					return;
				manager.Histories = value;
				NotifyPropertyChanged("Histories");
			}
		}

		public void AddNewHistoryEntry(HistoryActionType action, string name, string detail, string path)
		{
			switch (action)
			{
				case HistoryActionType.Added:
					name = "Added " + name;
					break;
				case HistoryActionType.Changed:
					name = "Changed " + name;
					break;
				default:
					name = "Removed " + name;
					break;
			}
			Histories.Add(new HistoryItemViewModel(path, name, detail, DateTime.Now));
			NotifyPropertyChanged("Histories");
		}

		public string GetCompareItemChanges(ItemViewModel x, ItemViewModel y)
		{
			if (x == null || y == null)
				return "";

			string changes = "";
			if (!x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nNAME changed from '{0}' to '{1}'", x.Name, y.Name); 
			
			if (!x.Category.Equals(y.Category, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nCATEGORY changed from '{0}' to '{1}'", x.Category, y.Category);
			
			if (!x.Description.Equals(y.Description, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nDESCRIPTION changed from '{0}' to '{1}'", x.Description, y.Description);
			

			if (!x.Detail.Company.Equals(y.Detail.Company, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nCOMPANY changed from '{0}' to '{1}'", x.Detail.Company, y.Detail.Company);
			
			if (!x.Detail.Address.Equals(y.Detail.Address, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nADDRESS changed from '{0}' to '{1}'", x.Detail.Address, y.Detail.Address);
			
			if (!x.Detail.Phone.Equals(y.Detail.Phone, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nPHONE changed from '{0}' to '{1}'", x.Detail.Phone, y.Detail.Phone);
			
			if (!x.Detail.Email.Equals(y.Detail.Email, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nEMAIL changed from '{0}' to '{1}'", x.Detail.Email, y.Detail.Email);
			
			if (!x.Detail.Date.Equals(y.Detail.Date))
				changes += string.Format("\nDATE changed from '{0}' to '{1}'", x.Detail.Date, y.Detail.Date);

			Console.WriteLine("x " + x.Quantity.Total);
			Console.WriteLine("y " + y.Quantity.Total);
			if (x.Price.CurrentPrice != y.Price.CurrentPrice)
				changes += string.Format("\nCURRENT PRICE changed from '{0}' to '{1}'", x.Price.CurrentPrice, y.Price.CurrentPrice);
			
			if (x.Price.RegularPrice != y.Price.RegularPrice)
				changes += string.Format("\nREGULAR PRICE changed from '{0}' to '{1}'", x.Price.RegularPrice, y.Price.RegularPrice);
			
			if (x.Price.SalePrice != y.Price.SalePrice)
				changes += string.Format("\nSALE PRICE changed from '{0}' to '{1}'", x.Price.SalePrice, y.Price.SalePrice);
			
			if (x.Price.IsOnSale != y.Price.IsOnSale)
				changes += string.Format("\nIS ON SALE changed from '{0}' to '{1}'", x.Price.IsOnSale, y.Price.IsOnSale);
			

			if(x.Quantity.Total != y.Quantity.Total)
				changes += string.Format("\nQUANTITY TOTAL changed from '{0}' to '{1}'", x.Quantity.Total, y.Quantity.Total);
			
			if (x.Quantity.Today != y.Quantity.Today)
				changes += string.Format("\nQUANTITY TODAY changed from '{0}' to '{1}'", x.Quantity.Today, y.Quantity.Today);
			
			if (x.Quantity.Weekly != y.Quantity.Weekly)
				changes += string.Format("\nQUANTITY WEEKLY changed from '{0}' to '{1}'", x.Quantity.Weekly, y.Quantity.Weekly);
			
			if (x.Quantity.Monthly != y.Quantity.Monthly)
				changes += string.Format("\nQUANTITY MONTHLY changed from '{0}' to '{1}'", x.Quantity.Monthly, y.Quantity.Monthly);
			
			if (x.Quantity.Annually != y.Quantity.Annually)
				changes += string.Format("\nQUANTITY ANNUALLY changed from '{0}' to '{1}'", x.Quantity.Annually, y.Quantity.Annually);
			
			if (x.Quantity.UsedTotal != y.Quantity.UsedTotal)
				changes += string.Format("\nQUANTITY USED TOTAL changed from '{0}' to '{1}'", x.Quantity.UsedTotal, y.Quantity.UsedTotal);
			
			return changes;
		}

		public string GetCompareCategoryChange(CategoryViewModel x, CategoryViewModel y)
		{
			if (x == null || y == null)
				return "";
			string changes = "";
			if (!x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nNAME changed from '{0}' to '{1}'", x.Name, y.Name);
			Console.WriteLine("x: " + x.Name);
			Console.WriteLine("y: " + y.Name);
			if (!x.Description.Equals(y.Description, StringComparison.InvariantCultureIgnoreCase))
				changes += string.Format("\nDESCRIPTION changed from '{0}' to '{1}'", x.Description, y.Description);
			return changes;
		}

		public void RemoveHistoryEntry(HistoryItemViewModel h)
		{
			Histories.Remove(h);
			NotifyPropertyChanged("Histories");
		}
	}
}
