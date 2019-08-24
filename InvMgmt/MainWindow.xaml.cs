using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainWindow()
        {
            InitializeComponent();

            /*
            for (int i = 0; i < 20; i++)
            {
                items.Add(
                    new ItemViewModel(
                        i.ToString(), 
                        "Dark Maple Cabinet", 
                        "Dark maple color kitchen cabinet", 
                        new CategoryViewModel("0", "des", "Cat " +i), 
                        new QuantityViewModel(i * 100, i * 2, i * 6, i*30), 
                        new PriceViewModel(i * 5, i * 6, i * 3),
                        new ItemDetailViewModel("Kolier Inc", "492 McNicoll Cir. North York, M3P 3T2", "1-123-423-2123", DateTime.Now)));
            }
            */
            form.Id = "13123";
            form.Name = "dsfafdsfasf";
            form.Description = "dfjslkvja jdsflajvs afs";

            AddCategoryToList();


            itemForm.Name = "fdsvdnn";
            itemForm.Description = "fdsvsv";
            itemForm.Id = "1231";
            AddNewItemToCategory(categoryManager.Categories[0]);

            Console.WriteLine("from main " + categoryManager.Categories[0].Items[0]);

            gridNewCat.DataContext = form;
            gridNewItem.DataContext = itemForm;
            gridExistingCat.DataContext = categoryManager;
            cbNewItemCategory.DataContext = categoryManager;
            tabInventory.DataContext = categoryManager;
            
        }

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

        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        public bool IntValidationAllow(string y)
        {
            if (!_regex.IsMatch(y))
            {
                int ignore;
                if (int.TryParse(y, out ignore))
                    return true;
                return false;
            }
            return false;
        }
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IntValidationAllow(e.Text);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (((TextBox)sender).Text.Length == 1)
                {
                    ((TextBox)sender).Text = "0";
                    ((TextBox)sender).SelectionStart = 1;
                    e.Handled = true;
                }
            }
        }
    }
}
