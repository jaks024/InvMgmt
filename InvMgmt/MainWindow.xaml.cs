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
		public HistoryManagerViewModel historyManager { get; } = new HistoryManagerViewModel();

		private HistoryFileWriter historyFileWriter = new HistoryFileWriter();
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
			dgRecentHistory.DataContext = historyManager;

			SaveDataHandler.InitializeConnection("data.sqlite", settingManager.SaveFileManager.FirstLaunch);
			if (settingManager.SaveFileManager.FirstLaunch)
				settingManager.NoLongerFirstLaunch();

			//SaveDataHandler.InitializeConnection("data.sqlite");
			//temp data
			//SaveDataHandler.InsertCategoryToTable(categoryManager.Categories[0]);
			//SaveDataHandler.CreateItemTable(categoryManager.Categories[0].Items[0]);
			AddCategoryToListDataBase();
			AddNewItemToCategoryFromDatabase();

			historyFileWriter.CreatePdf();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			settingManager.WriteToSetting();
			RewriteAllData();
		}


		#region add menu category section
		private void BtnSubmitNewCat_Click(object sender, RoutedEventArgs e)
        {
			if (!form.IsAllFieldFull())
			{
				MessageBox.Show("All fields with asterisk must be filled.");
				return;
			}
			if (!form.IsIdValid(categoryManager))
			{
				MessageBox.Show("An item with the same ID already exists. ID must be unique.");
				return;
			}
            AddCategoryToList();
        }

        private void AddCategoryToList()
        {
            categoryManager.AddCategoryToList(form.GetCategory);
			SaveDataHandler.InsertCategoryToTable(form.GetCategory);
			SaveDataHandler.CreateItemTable(form.GetCategory.IdDb);

			HistoryAddNewCategory(form.GetCategory);

            form.Reset();
        }
		private void AddCategoryToListDataBase()
		{
			categoryManager.AddCategoryToListFromDatabase(SaveDataHandler.ReadCategoryTable());
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
			CategoryViewModel temp = (CategoryViewModel)dgExistingCat.SelectedItem;
			HistoryRemoveCategory(temp);
			foreach(ItemViewModel item in temp.Items)
			{
				HistoryRemoveItem(item);
			}
			SaveDataHandler.RemoveCategoryInTable(temp);
            categoryManager.RemoveCategoryFromList((CategoryViewModel)dgExistingCat.SelectedItem);
        }
		#endregion

		#region add menu item selection
		private void BtnSubmitNewItem_Click(object sender, RoutedEventArgs e)
        {
			Console.WriteLine("selected index " + cbNewItemCategory.SelectedIndex);

			if (cbNewItemCategory.SelectedIndex == -1 || !itemForm.CanAddItem || categoryManager.IsCategoryEmpty())
			{
				MessageBox.Show("All fields with asterisk must be filled.");
				return;
			}
			if (!itemForm.IsIdValid(categoryManager))
			{
				MessageBox.Show("An item with the same ID already exists. ID must be unique.");
				return;
			}
			AddNewItemToCategory((CategoryViewModel)cbNewItemCategory.SelectedItem);
            
        }
        private void AddNewItemToCategory(CategoryViewModel _cat)
        {
            categoryManager.AddNewItemToCategory(_cat, itemForm.GetItem);
			SaveDataHandler.InsertItemToTable(itemForm.GetItem);

			HistoryAddNewItem(itemForm.GetItem);

			NewItemReset();
        }
		private void AddNewItemToCategoryFromDatabase()
		{
			for(int i = 0; i < categoryManager.CategoryCount; i++)
			{
				categoryManager.AddListItemToCategoryFromDatabase(i, SaveDataHandler.ReadItemTable(categoryManager.Categories[i].IdDb));
			}
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
			categoryManager.RefreshInventoryItemCount();
		}

        private void TextBoxDoubleOnlyValidation_LostFocus(object sender, RoutedEventArgs e)
        {
			e.Handled = true;
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
			((TextBox)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();

			ItemViewModel x = (ItemViewModel)dgItemList.SelectedItem;
			if (x != null)
				DgItemList_CellTextboxEditEnding(x);
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
			((TextBox)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();

			ItemViewModel x = (ItemViewModel)dgItemList.SelectedItem;
			if (x != null)
				DgItemList_CellTextboxEditEnding(x);
		}

		#endregion

		#region item menu item list modification

		private void DgItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgItemList.SelectedItem == null)
                return;
            cmbChangeItemCategory.SelectedItem = categoryManager.FindCategoryUsingId(((ItemViewModel)dgItemList.SelectedItem).Category);

			
			HistoryRecord();

			ItemViewModel x = (ItemViewModel)dgItemList.SelectedItem;
			if(x != null)
				historyTempItem = new ItemViewModel(x);
        }

        private void CmbChangeItemCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgItemList.SelectedItem == null)
                return;
			ItemViewModel temp = new ItemViewModel();

			categoryManager.ChangeSingleItemCategory((ItemViewModel)dgItemList.SelectedItem, (CategoryViewModel)cmbChangeItemCategory.SelectedItem, out temp);
			if (historyTempItem != null)
				DgItemList_CellTextboxEditEnding(temp);
			//HistoryChangeItemCategory(temp);

			HistoryRecord();
		}

		#endregion

		#region settings menu save file section


		private void BtnChangeFolder_Click(object sender, RoutedEventArgs e)
		{
			settingManager.SaveFileManager.SaveFolderPath = settingManager.GetPathFolderDialog;
		}

		#endregion

		#region database changes
		private void RewriteAllData()
		{
			SaveDataHandler.OpenConnection();
			for(int i = 0; i < categoryManager.CategoryCount; i++)
			{
				SaveDataHandler.UpdateCategoryInTableManualConnection(categoryManager.Categories[i]);
				for(int x = 0; x < categoryManager.Categories[i].Items.Count; x++)
				{
					SaveDataHandler.UpdateItemInTableManualConnection(categoryManager.Categories[i].Items[x]);
				}
			}
			SaveDataHandler.CloseConnection();
		}

		private void DgExistingCat_LostFocus(object sender, RoutedEventArgs e)
		{
			SaveDataHandler.OpenConnection();
			for (int i = 0; i < categoryManager.CategoryCount; i++)
				SaveDataHandler.UpdateCategoryInTableManualConnection(categoryManager.Categories[i]);

			SaveDataHandler.CloseConnection();
		}

		private void BtnInventoryDelete_Click(object sender, RoutedEventArgs e)
		{
			if (dgItemList.SelectedIndex == -1)
				return;
			ItemViewModel temp = (ItemViewModel)dgItemList.SelectedItem;
			HistoryRemoveItem(temp);
			SaveDataHandler.RemoveItemInTable(temp);
			categoryManager.Categories[categoryManager.CurrentCategoryIndex].RemoveItem((ItemViewModel)dgItemList.SelectedItem);
		}

		private void DgItemList_LostFocus(object sender, RoutedEventArgs e)
		{
			SaveDataHandler.OpenConnection();
			for(int i = 0; i < categoryManager.SelectedCategoryItems.Count; i++)
			{
				SaveDataHandler.UpdateItemInTableManualConnection(categoryManager.SelectedCategoryItems[i]);
			}
			SaveDataHandler.CloseConnection();

			HistoryRecord();
		}
		#endregion

		#region search
		private void BtnSearch_Click(object sender, RoutedEventArgs e)
		{
			SearchSystem s = new SearchSystem();
			categoryManager.SetCurrentItemToSeached(s.GetSearchedItem(tbItemSearch.Text, categoryManager.SelectedCategoryItems));
		}

		private void BtnClear_Click(object sender, RoutedEventArgs e)
		{
			tbItemSearch.Clear();
			categoryManager.SetCurrentItemAllToVisible();
		}

		#endregion

		#region history
		private ItemViewModel historyTempItem;
		private ItemViewModel accumTempItem;
		private CategoryViewModel historyTempCategory;
		private CategoryViewModel accumTempCategory;
		private void HistoryAddNewCategory(CategoryViewModel cat)
		{
			historyManager.AddNewHistoryEntry(HistoryActionType.Added, cat.Id, cat.ToStringDetailed(), "Added new category");
		}
		private void HistoryAddNewItem(ItemViewModel item)
		{
			historyManager.AddNewHistoryEntry(HistoryActionType.Added, item.Name, item.ToStringDetailed(), "Added to: " + item.Category);
		}
		private void HistoryChangeItem(ItemViewModel item, string changes)
		{
			historyManager.AddNewHistoryEntry(HistoryActionType.Changed, item.Name, changes, "Child of: " + item.Category);
		}
		private void HistoryChangeItemCategory(ItemViewModel item)
		{
			if(!historyTempItem.Category.Equals(item.Category))
				historyManager.AddNewHistoryEntry(HistoryActionType.Changed, item.Name, string.Format("\nCATEGORY changed from '{0}' to '{1}'", historyTempItem.Category, item.Category), "Child of " + item.Category);
		}
		private void HistoryChangeCategoryDetail(CategoryViewModel cat, string changes)
		{
			historyManager.AddNewHistoryEntry(HistoryActionType.Changed, cat.Id, changes, "Changed category details");
		}
		private void HistoryRemoveItem(ItemViewModel item)
		{
			historyManager.AddNewHistoryEntry(HistoryActionType.Removed, item.Name, item.ToStringDetailed(), "Removed from category: " + item.Category);
		}
		private void HistoryRemoveCategory(CategoryViewModel cat)
		{
			historyManager.AddNewHistoryEntry(HistoryActionType.Removed, cat.Id, cat.ToStringDetailed(), "Removed this category");
		}
		#endregion

		private void DgItemList_CellEditEnding(object sender, DataGridRowEditEndingEventArgs e)
		{
			HistoryRecord();
		}

		private void HistoryRecord()
		{
			if (historyTempItem == null || accumTempItem == null)
				return;
			if (!historyTempItem.Id.Equals(accumTempItem.Id))
				return;

					Console.WriteLine("called");
			string changes = historyManager.GetCompareItemChanges(historyTempItem, accumTempItem).Trim();
			if (!changes.Equals(""))
				HistoryChangeItem(historyTempItem, changes);
			historyTempItem = null;
			accumTempItem = null;
		}
		private void DgItemList_CellTextboxEditEnding(ItemViewModel i)
		{
			accumTempItem = i;
			Console.WriteLine("accum");
		}

		private void DgItemList_CellEditEnding_Accum(object sender, DataGridCellEditEndingEventArgs e)
		{
			accumTempItem = (ItemViewModel)e.Row.Item;
			Console.WriteLine("accum");
		}

		private void DgExistingCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgExistingCat.SelectedItem == null)
				return;

			historyTempCategory = new CategoryViewModel((CategoryViewModel)dgExistingCat.SelectedItem);
		}

		private void DgExistingCat_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
		{
			Console.WriteLine("category history called");
			string changes = historyManager.GetCompareCategoryChange(historyTempCategory, accumTempCategory).Trim();
			if (!changes.Equals(""))
				HistoryChangeCategoryDetail(historyTempCategory, changes);
		}

		private void DgExistingCat_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			accumTempCategory = (CategoryViewModel)e.Row.Item;
		}

		private void DgRowDetail_LostFocus(object sender, RoutedEventArgs e)
		{
			ItemViewModel x = (ItemViewModel)dgItemList.SelectedItem;
			if (x != null)
				DgItemList_CellTextboxEditEnding(x);
		}
	}
}
