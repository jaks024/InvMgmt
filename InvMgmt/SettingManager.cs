using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
using System.IO;
using System.Windows.Forms;
namespace InvMgmt
{
	public class SettingManager
	{
		public SaveSettingViewModel SaveFileManager { get; } = new SaveSettingViewModel();
		public SettingManager() { }
		public void ReadFromSetting()
		{
			Console.WriteLine("read");
			try
			{
				SaveFileManager.SaveFolderPath = Properties.Settings.Default["SaveFolderPath"].ToString();
				SaveFileManager.FirstLaunch = (bool)Properties.Settings.Default["FirstLaunch"];
			}
			catch (Exception e)
			{
				Console.Write(e.Message);
			}
		}
	
		public void NoLongerFirstLaunch()
		{
			SaveFileManager.FirstLaunch = false;
			Properties.Settings.Default["FirstLaunch"] = SaveFileManager.FirstLaunch;
			Properties.Settings.Default.Save();
		}
		public void WriteToSetting()
		{
			Properties.Settings.Default["SaveFolderPath"] = SaveFileManager.SaveFolderPath;
			Properties.Settings.Default["FirstLaunch"] = SaveFileManager.FirstLaunch;
			Properties.Settings.Default.Save();
		}
		public string GetPathFolderDialog
		{
			get
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();
					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						return fbd.SelectedPath;
					}
				}
				return "";
			}
		}
	}
}
