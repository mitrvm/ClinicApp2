using ClinicApp.TablePages;
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
    /// Логика взаимодействия для AE_Appointments_Res.xaml
    /// </summary>
    public partial class AE_Appointments_Res : Page
    {
        private Appointment_results _currentAppointmentRes = new Appointment_results();
        public AE_Appointments_Res(Appointment_results currentAppointmentRes)
        {
            InitializeComponent(); 
            if (currentAppointmentRes != null)
            _currentAppointmentRes = currentAppointmentRes;
            DataContext = _currentAppointmentRes;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentAppointmentRes.Appointment_ID.ToString().Length == 0 || _currentAppointmentRes.Diagnosis.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");
            if (_currentAppointmentRes.Prescribed_medecine_ID.ToString().Length == 0)
            {
                _currentAppointmentRes.Prescribed_medecine_ID = null;
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentAppointmentRes.ID == 0)
            {
                ClinicEntities.GetContext().Appointment_results.Add(_currentAppointmentRes);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new AppointmnetResultPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
