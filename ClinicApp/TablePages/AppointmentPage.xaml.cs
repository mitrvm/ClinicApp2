using ClinicApp.AddEditPages;
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

namespace ClinicApp
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        public AppointmentPage()
        {
            InitializeComponent();
            DGrid_Appointments.ItemsSource = ClinicEntities1.GetContext().Appointments.ToList();
        }

        private void Btn_DelApp_Click(object sender, RoutedEventArgs e)
        {
            var appForRemoving = DGrid_Appointments.SelectedItems.Cast<Appointments>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {appForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Appointments.RemoveRange(appForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Appointments.ItemsSource = ClinicEntities1.GetContext().Appointments.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddApp_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AE_Appointments((sender as Button).DataContext as Appointments));
        }
    }
}
