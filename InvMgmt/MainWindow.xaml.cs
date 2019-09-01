using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using InvMgmt.Information.ViewModels;

namespace InvMgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<ItemViewModel> items { get; } = new ObservableCollection<ItemViewModel>();
        public FormViewModel form { get; set; } = new FormViewModel();
        public ItemFormViewModel itemForm { get; set; } = new ItemFormViewModel();
        public CategoryManagerViewModel categoryManager { get; } = new CategoryManagerViewModel();

		public SettingManager settingManager = new SettingManager();
        public MainWindow()
        {
            InitializeComponent();

			//setting loading
			settingManager.ReadFromSetting();

			//temp item start
			/*
            form.Id = "13123";
            form.Name = "dsfafdsfasf";
            form.Description = "dfjslkvja jdsflajvs afs";

            AddCategoryToList();

            itemForm.Name = "fdsvdnn";
            itemForm.Description = "fdsvsv";
            itemForm.Id = "1231";
            AddNewItemToCategory(categoryManager.Categories[0]);
			//temp item end
			*/

			//setting data contexts
            gridNewCat.DataContext = form;
            gridNewItem.DataContext = itemForm;
            gridExistingCat.DataContext = categoryManager;
            cbNewItemCategory.DataContext = categoryManager;
            tabInventory.DataContext = categoryManager;
            cmbChangeItemCategory.DataContext = categoryManager;
			tbSaveFolderPath.DataContext = settingManager.SaveFileManager;

			SaveDataHandler.InitializeConnection("data.sqlite", settingManager.SaveFileManager.FirstLaunch);
			if(settingManager.SaveFileManager.FirstLaunch)
				settingManager.NoLongerFirstLaunch();

			AddCategoryToListDataBase();
			AddNewItemToCategoryFromDatabase(SaveDataHandler.ReadItemTable(categoryManager.Categories[0].Name));
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			settingManager.WriteToSetting();
		}


		#region add menu category section
		private void BtnSubmitNewCat_Click(object sender, RoutedEventArgs e)
        {
            if (!form.IsAllFieldFull())
                return;
            AddCategoryToList();
        }

        private void AddCategoryToList()
        {
            categoryManager.AddCategoryToList(form.GetCategory);
            form.Reset();
        }
		private void AddCategoryToListDataBase()
		{
			categoryManager.AddCategoryToList(SaveDataHandler.ReadCategoryTable());
		}

        private void BtnClearNewCat_Click(object sender, RoutedEventArgs e)
        {
            if (!form.IsOneFieldFilled())
                return;
            form.Reset();
        }

        private void BtnRemoveExistingCat_Click(object sender, RoutedEventArgs e)
        {
            if (dgExistingCat.SelectedItem == null)
                return;
            categoryManager.RemoveCategoryFromList((CategoryViewModel)dgExistingCat.SelectedItem);
        }
		#endregion

		#region add menu item selection
		private void BtnSubmitNewItem_Click(object sender, RoutedEventArgs e)
        {
            if (itemForm.CanAddItem && !categoryManager.IsCategoryEmpty && cbNewItemCategory.SelectedItem != null)
            {
                AddNewItemToCategory((CategoryViewModel)cbNewItemCategory.SelectedItem);
                //Console.WriteLine("added: " + categoryManager.Items[0].ToString());
            }
        }
        private void AddNewItemToCategory(CategoryViewModel _cat)
        {
            categoryManager.AddNewItemToCategory(_cat, itemForm.GetItem);
            dgExistingCat.Items.Refresh();
            NewItemReset();
        }
		private void AddNewItemToCategoryFromDatabase(ObservableCollection<ItemViewModel> _items)
		{
			categoryManager.AddListItemToCategoryFromDatabase(_items);
			dgExistingCat.Items.Refresh();
			NewItemReset();
		}

		private void BtnClearNewItem_Click(object sender, RoutedEventArgs e)
        {
            NewItemReset();
        }

        private void NewItemReset()
        {
            itemForm.Reset();
        }

        private void CmbSortByCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgItemList.Items.Refresh();
        }

        private void TextBoxDoubleOnlyValidation_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                ((TextBox)sender).Text = "0";
                return;
            }

            double temp;
            if (!double.TryParse(((TextBox)sender).Text, out temp))
            {
                ((TextBox)sender).Text = "0";
                MessageBox.Show("This field is number only");
                return;
            }
            if (temp < 0)
            {
                ((TextBox)sender).Text = "0";
                MessageBox.Show("This field cannot be negative");
                return;
            }
            ((TextBox)sender).Text = temp.ToString();
        }

        private void TextBoxIntOnlyValidation_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                ((TextBox)sender).Text = "0";
                return;
            }

            int temp;
            if (!int.TryParse(((TextBox)sender).Text, out temp))
            {
                ((TextBox)sender).Text = "0";
                MessageBox.Show("This field is integer only");
                return;
            }
            if(temp < 0)
            {
                ((TextBox)sender).Text = "0";
                MessageBox.Show("This field cannot be negative");
                return;
            }
            ((TextBox)sender).Text = temp.ToString("N0");
        }

		#endregion

		#region item menu item list modification

		private void DgItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgItemList.SelectedItem == null)
                return;
            cmbChangeItemCategory.SelectedItem = categoryManager.FindCategoryUsingName(((ItemViewModel)dgItemList.SelectedItem).Category);
            
        }

        private void CmbChangeItemCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgItemList.SelectedItem == null)
                return;
            categoryManager.ChangeSingleItemCategory(((ItemViewModel)dgItemList.SelectedItem), ((CategoryViewModel)cmbChangeItemCategory.SelectedItem));
        }

		#endregion

		#region settings menu save file section


		private void BtnChangeFolder_Click(object sender, RoutedEventArgs e)
		{
			settingManager.SaveFileManager.SaveFolderPath = settingManager.GetPathFolderDialog;
		}

		#endregion

	}
}
