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
    /// Логика взаимодействия для AE_Employees.xaml
    /// </summary>
    public partial class AE_Employees : Page
    {

        private Employees _currentEmployee = new Employees();
        public AE_Employees(Employees currentEmployees)
        {
            InitializeComponent();
            if (currentEmployees != null)
                _currentEmployee = currentEmployees;
            DataContext = _currentEmployee;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentEmployee.Full_name.ToString().Length < 5 || _currentEmployee.Job_title_ID.ToString().Length == 0 || _currentEmployee.DB_Password.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");
            if (_currentEmployee.Specialty_ID.ToString().Length == 0)
            {
                _currentEmployee.Specialty_ID = null;
            }
            if (_currentEmployee.DB_Password.ToString().Length<6)
            {
                errors.AppendLine("Password must be 6 or more characters long.");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentEmployee.ID == 0)
            {
                ClinicEntities.GetContext().Employees.Add(_currentEmployee);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new EmployeesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
