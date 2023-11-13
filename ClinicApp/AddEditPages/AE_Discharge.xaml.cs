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
    /// Логика взаимодействия для AE_Discharge.xaml
    /// </summary>
    public partial class AE_Discharge : Page
    {

        private Discharges _currentDischarges = new Discharges();
        public AE_Discharge(Discharges currentDischarges)
        {
            InitializeComponent();
            if (currentDischarges != null)
                _currentDischarges = currentDischarges;
            DataContext = _currentDischarges;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentDischarges.Doctor_ID.ToString().Length == 0 || _currentDischarges.Patient_ID.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");

            if (_currentDischarges.Discharge_date.Year < 1950)
                errors.AppendLine("Invalid date.");



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentDischarges.ID == 0)
            {
                ClinicEntities.GetContext().Discharges.Add(_currentDischarges);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new DischargePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
