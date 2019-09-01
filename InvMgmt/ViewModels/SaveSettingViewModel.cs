using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;

namespace InvMgmt.Information.ViewModels
{
	public class SaveSettingViewModel : ViewModelBase
	{
		private readonly SaveSetting manager;

		public SaveSettingViewModel() { manager = new SaveSetting(); }
		public SaveSettingViewModel(string _path)
		{
			manager = new SaveSetting();
			SaveFolderPath = _path;
		}

		public string SaveFolderPath
		{
			get { return manager.saveFolderPath; }
			set
			{
				if (manager.saveFolderPath.Equals(value))
					return;
				manager.saveFolderPath = value;
				NotifyPropertyChanged("SaveFolderPath");
			}
		}

		public bool FirstLaunch
		{
			get { return manager.firstLaunch; }
			set { manager.firstLaunch = value; }
		}
	}
}
