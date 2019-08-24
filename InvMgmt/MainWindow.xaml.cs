using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        public ObservableCollection<ItemViewModel> items { get; } = new ObservableCollection<ItemViewModel>();
        public FormViewModel form { get; set; } = new FormViewModel();
        public ItemFormViewModel itemForm { get; set; } = new ItemFormViewModel();
        public CategoryManagerViewModel categoryManager { get; } = new CategoryManagerViewModel();
        public MainWindow()
        {
            InitializeComponent();

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

            dgItemList.DataContext = this;
            gridNewCat.DataContext = form;
            gridNewItem.DataContext = itemForm;
            gridExistingCat.DataContext = categoryManager;
            cbNewItemCategory.DataContext = categoryManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(items[dgItemList.SelectedIndex].Category.Id);
        }

        private void BtnSubmitNewCat_Click(object sender, RoutedEventArgs e)
        {
            if (!form.IsAllFieldFull())
                return;
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
            Console.WriteLine(string.Format("{0}, {1}, {2}",itemForm.CanAddItem.ToString(), categoryManager.IsCategoryEmpty.ToString(), cbNewItemCategory.SelectedItem != null));
            if (itemForm.CanAddItem && !categoryManager.IsCategoryEmpty && cbNewItemCategory.SelectedItem != null)
            {
                categoryManager.AddNewItemToCategory((CategoryViewModel)cbNewItemCategory.SelectedItem, itemForm);
                NewItemReset();
                dgExistingCat.Items.Refresh();
                Console.WriteLine("added");
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
    }
}
