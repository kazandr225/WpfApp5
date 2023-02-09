using System;
using System.Collections.Generic;
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
using WpfApp5.Classes;

namespace WpfApp5.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            listViewService.ItemsSource = BaseClass.EM.Service.ToList();

            cbDiscount.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;
        }



        private void sortDataService() //сортировка и фильтрация
        { 
            
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            sortDataService();
        }

        private void tbDescriptiob_TextChanged(object sender, TextChangedEventArgs e)
        {
            sortDataService();
        }

        private void cbDiscount_Selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            sortDataService();
        }

        private void cbSort_Selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            sortDataService();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e) 
        {

        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleateService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
