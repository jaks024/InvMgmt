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

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 20; i++)
            {
                items.Add(
                    new ItemViewModel(
                        i, 
                        "Dark Maple Cabinet", 
                        "Dark maple color kitchen cabinet", 
                        new CategoryViewModel(0, "des", "Cat " +i), 
                        new QuantityViewModel(i * 100, i * 2, i * 6, i*30), 
                        i * 3.33,
                        new ItemDetailViewModel("Kolier Inc", "492 McNicoll Cir. North York, M3P 3T2", "1-123-423-2123", DateTime.Now)));
            }

            dgItemList.DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(items[dgItemList.SelectedIndex].Category.Id);
        }
    }
}
