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

namespace ClinicApp.AddEditPages
{
    /// <summary>
    /// Логика взаимодействия для AE_Appointments.xaml
    /// </summary>
    public partial class AE_Appointments : Page
    {

        private Appointments _currentAppointment = new Appointments();
        public AE_Appointments(Appointments currentAppointment)
        {
            InitializeComponent();
            if (currentAppointment != null)
                _currentAppointment = currentAppointment;
            DataContext = _currentAppointment;
            AE_Status.ItemsSource = new List<string> { "Не проведен", "Проведен", "Отменен" };
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentAppointment.Doctor_ID.ToString().Length == 0 || _currentAppointment.Patient_ID.ToString().Length == 0 || _currentAppointment.Service_ID.ToString().Length == 0 || _currentAppointment.Status==null)
                errors.AppendLine("Please fill out all the fields and try again.");

            if (_currentAppointment.Doctor_ID<1|| _currentAppointment.Patient_ID < 1|| _currentAppointment.Service_ID < 1)
                errors.AppendLine("Invalid ID.");

            if (_currentAppointment.Date.Year < 1950)
            {
                errors.AppendLine("Invalid date");
            }

            if (_currentAppointment.Date > DateTime.Now&& _currentAppointment.Status== "Проведен")
            {
                errors.AppendLine("Invalid date");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentAppointment.ID == 0)
            {
                ClinicEntities.GetContext().Appointments.Add(_currentAppointment);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");
                Manager.MainFrame.Navigate(new AppointmentPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
