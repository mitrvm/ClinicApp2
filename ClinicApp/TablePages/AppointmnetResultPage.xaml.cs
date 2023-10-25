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

namespace ClinicApp.TablePages
{
    /// <summary>
    /// Логика взаимодействия для AppointmnetResultPage.xaml
    /// </summary>
    public partial class AppointmnetResultPage : Page
    {
        public AppointmnetResultPage()
        {
            InitializeComponent();

            DGrid_Appointments_Res.ItemsSource = ClinicEntities1.GetContext().Appointment_results.ToList();
        }

        private void Btn_DelAppFin_Click(object sender, RoutedEventArgs e)
        {
            var appFForRemoving = DGrid_Appointments_Res.SelectedItems.Cast<Appointment_results>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {appFForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Appointment_results.RemoveRange(appFForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Appointments_Res.ItemsSource = ClinicEntities1.GetContext().Appointment_results.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
