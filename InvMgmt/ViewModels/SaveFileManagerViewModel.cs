using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.Objects;
using System.IO;
using System.Windows.Forms;
namespace InvMgmt.Information.ViewModels
{
	public class SaveFileManagerViewModel : ViewModelBase
	{
		private SaveFileManager manager;

		public SaveFileManagerViewModel() { manager = new SaveFileManager(); }
		public SaveFileManagerViewModel(string _path)
		{
			manager = new SaveFileManager();
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

		public string GetPathFolderDialog
		{
			get
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();
					if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						return fbd.SelectedPath;
					}
				}
				return "";
			}
		}
	}
}
