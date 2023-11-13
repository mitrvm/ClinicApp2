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
    /// Логика взаимодействия для AE_Schedule.xaml
    /// </summary>
    public partial class AE_Schedule : Page
    {

        private Schedules _currentSchedules = new Schedules();
        public AE_Schedule(Schedules currentSchedules)
        {
            InitializeComponent();
            if (currentSchedules != null)
                _currentSchedules = currentSchedules;
            DataContext = _currentSchedules;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentSchedules.Employee_ID.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");
            if (_currentSchedules.Date_and_time.Year < 1950)
                errors.AppendLine("Invalid date.");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentSchedules.ID == 0)
            {
                ClinicEntities.GetContext().Schedules.Add(_currentSchedules);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new SchedulePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
