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
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        Service SERVICE;
        bool flagUpdate = false;


        //подгружаем данные из БД
        public void uploadFields()
        {
            //tbNameService.Text = SERVICE.Title_Service;
            //tbPrice.Text = Convert.ToString(SERVICE.Cost_Service);
            //tbDiscount.Text = Convert.ToString(SERVICE.Discount);
            //tbDuration.Text = Convert.ToString(SERVICE.DurationInSeconds / 60);
            //tbDescription.Text = SERVICE.Description_Service;
        }

        //Конструктор для создания новой услуги
        public AddServicePage()
        {
            InitializeComponent();
            uploadFields();
        }

        public AddServicePage(Service service)
        {
            InitializeComponent();
            flagUpdate = true;
            SERVICE = service;

            //подгружаем данные из бд
            tbNameService.Text = service.Title_Service;
            tbPrice.Text = Convert.ToString(service.Cost_Service);
            tbDiscount.Text = Convert.ToString(service.Discount);
            tbDuration.Text = Convert.ToString(service.DurationInSeconds / 60);
            tbDescription.Text = service.Description_Service;
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            //если флаг рафен false, то создаем объект для добавления услуги
            try
            {
                if (flagUpdate == false)
                {
                    SERVICE = new Service();
                }

                //заполняем поля таблицы
                SERVICE.Title_Service = tbNameService.Text;
                SERVICE.Cost_Service = Convert.ToInt32(tbPrice.Text);
                SERVICE.DurationInSeconds = Convert.ToInt32(tbDuration.Text) * 60;
                SERVICE.Discount = Convert.ToInt32(tbDiscount.Text);
                SERVICE.Description_Service = tbDescription.Text;

                //если флаг равен false, то добавляем объект в базу
                if (flagUpdate == false)
                {
                    BaseClass.EM.Service.Add(SERVICE);
                }

                BaseClass.EM.SaveChanges();
                MessageBox.Show("Информация добавлена");
            }
            
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnServicePage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MaiFrame.Navigate(new ServicePage());
        }
    }
}
