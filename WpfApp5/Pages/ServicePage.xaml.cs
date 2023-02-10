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
            List<Service> servicelist = new List<Service>();

            switch (cbDiscount.SelectedIndex) //фильтрация по выбранной скидке
            {
                case 0:
                    servicelist = BaseClass.EM.Service.ToList();
                    break;

                case 1:
                    servicelist = BaseClass.EM.Service.Where(x => x.Discount >= 0 && x.Discount < 5).ToList();
                    break;

                case 2:
                    servicelist = BaseClass.EM.Service.Where(x => x.Discount >= 5 && x.Discount < 15).ToList();
                    break;

                case 3:
                    servicelist = BaseClass.EM.Service.Where(x => x.Discount >= 15 && x.Discount < 30).ToList();
                    break;

                case 4:
                    servicelist = BaseClass.EM.Service.Where(x => x.Discount >= 30 && x.Discount < 70).ToList();
                    break;

                case 5:
                    servicelist = BaseClass.EM.Service.Where(x => x.Discount >= 70 && x.Discount < 100).ToList();
                    break;

            }

            if (tbDescription.Text != " " && tbDescription.Text != "") //фильтрация по описанию
            {
                servicelist = servicelist.Where(x => x.Title_Service.ToLower().Contains(tbDescription.Text.ToLower())).ToList();
            }

            if (tbSearch.Text != " " && tbSearch.Text != "") //сортировака по имени
            {
                servicelist = servicelist.Where(x => x.Title_Service.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }

            listViewService.ItemsSource = servicelist; //отображаем изменения в листе
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

        private void tbMinute_Loaded(object sender, RoutedEventArgs e) //переаод секунд в минуты
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid); ;

            //ищем, где хранится количество секунд
            List<Service> S = BaseClass.EM.Service.Where(x => x.id_Service == index).ToList();

            int min = 0;

            foreach (Service ser in S) //переводим секунды в минуты
            {
                min += Convert.ToInt32(ser.DurationInSeconds / 60);
            }

            tb.Text = min.ToString() + " минут"; //присваиваем значение
        }
    }
}
