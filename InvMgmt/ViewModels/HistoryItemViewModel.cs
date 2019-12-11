using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;

namespace InvMgmt.Information.ViewModels
{
	public class HistoryItemViewModel : ViewModelBase
	{
		public static int entryCount;
		private HistoryItem history;

		public HistoryItemViewModel() { history = new HistoryItem(); }
		public HistoryItemViewModel(string path, string name, string detail, DateTime time)
		{
			history = new HistoryItem();
			history.Id = entryCount;
			history.Path = path;
			history.Name = name;
			history.Detail = detail;
			history.Time = time;
			entryCount++;
		}

		public int Id
		{
			get { return history.Id; }
		}
		public string Path
		{
			get { return history.Path; }
		}
		public string Name
		{
			get { return history.Name; }
		}
		public string Detail
		{
			get { return history.Detail; }
		}
		public string Time
		{
			get { return history.Time.ToString(); }
		}

		public string ToSaveString()
		{
			//[ = split
			return string.Format("{0} - {1} --- {2}, {3}\n{4}", Id, Time, Name, Path, Detail);
		}
	}
}
