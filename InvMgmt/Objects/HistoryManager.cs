using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;

namespace InvMgmt.Information.Objects
{
	public class HistoryManager
	{
		public ObservableCollection<HistoryItemViewModel> Histories = new ObservableCollection<HistoryItemViewModel>();
	}
}
