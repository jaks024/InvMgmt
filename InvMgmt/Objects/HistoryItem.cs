using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
namespace InvMgmt.Information.Objects
{
	public class HistoryItem
	{
		public int Id = 0;
		public DateTime Time = DateTime.Now;
		public string Path = "";
		public string Name = "";
		public string Detail = "";
	}
}
