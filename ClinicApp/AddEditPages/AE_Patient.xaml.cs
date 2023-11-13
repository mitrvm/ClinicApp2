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
    /// Логика взаимодействия для AE_Patient.xaml
    /// </summary>
    public partial class AE_Patient : Page
    {

        private Patients _currentPat = new Patients();
        public AE_Patient(Patients currentPat)
        {
            InitializeComponent();
            if (currentPat != null)
                _currentPat = currentPat;
            DataContext = _currentPat;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentPat.Full_name.ToString().Length == 0 || _currentPat.SNILS.ToString().Length == 0 || _currentPat.DB_Password.ToString().Length==0)
                errors.AppendLine("Please fill out all the fields and try again.");
            if (_currentPat.SNILS.ToString().Length < 11)
                errors.AppendLine("SNILS must consist of 11 digits.");
            if (_currentPat.Date_of_birth.Year > DateTime.Now.Year|| _currentPat.Date_of_birth.Year < 1900)
                errors.AppendLine("Invalid date.");
            if (_currentPat.DB_Password.ToString().Length < 6)
            {
                errors.AppendLine("Password must be 6 or more characters long.");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentPat.ID == 0)
            {
                ClinicEntities.GetContext().Patients.Add(_currentPat);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new PatientsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
