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
                items.Add(new ItemViewModel(i, "Dark Maple Cabinet", "Dark maple color kitchen cabinet", new Category() { Id = i, Description = "des", Name="Cat " +i }, i * 2, i * 3.33));
            }
            dgItemList.DataContext = this;
            //dgItemList.ItemsSource = items;
        }
    }
}
