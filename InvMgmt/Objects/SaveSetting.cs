using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt.Information.Objects
{
	public class SaveSetting
	{
		public string saveFolderPath = "";
		public string historySaveFolderPath = System.AppDomain.CurrentDomain.BaseDirectory + "History";
		public bool firstLaunch = true;
	}
}
 