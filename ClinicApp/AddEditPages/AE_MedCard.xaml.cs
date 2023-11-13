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
    /// Логика взаимодействия для AE_MedCard.xaml
    /// </summary>
    public partial class AE_MedCard : Page
    {
        private Medical_card _currentMCs = new Medical_card();
        public AE_MedCard(Medical_card currentMCs)
        {
            InitializeComponent();
            if (currentMCs != null)
                _currentMCs = currentMCs;
            DataContext = _currentMCs;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentMCs.Patient_ID.ToString().Length == 0 || _currentMCs.Illness.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");

            if(_currentMCs.Beginning_date.Year<1950 || AE_End_Date.SelectedDate.Value.Year<1950 || _currentMCs.Beginning_date.Year> AE_End_Date.SelectedDate.Value.Year || _currentMCs.Beginning_date.Year>DateTime.Now.Year|| AE_End_Date.SelectedDate.Value.Year > DateTime.Now.Year)
                errors.AppendLine("Invalid date.");

            if (_currentMCs.End_date.ToString().Length != 0)
            {
                if (_currentMCs.Beginning_date.Year < 1950 || AE_End_Date.SelectedDate.Value.Year < 1950 || _currentMCs.Beginning_date.Year > AE_End_Date.SelectedDate.Value.Year || _currentMCs.Beginning_date.Year > DateTime.Now.Year || AE_End_Date.SelectedDate.Value.Year > DateTime.Now.Year)
                    errors.AppendLine("Invalid date.");
            }
            else
            {
                if (_currentMCs.Beginning_date.Year < 1950 || _currentMCs.Beginning_date.Year > DateTime.Now.Year )
                    errors.AppendLine("Invalid date.");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentMCs.ID == 0)
            {
                ClinicEntities.GetContext().Medical_card.Add(_currentMCs);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new MedicalCardPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
