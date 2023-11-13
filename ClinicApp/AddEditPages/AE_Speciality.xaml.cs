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
    /// Логика взаимодействия для AE_Speciality.xaml
    /// </summary>
    public partial class AE_Speciality : Page
    {

        private Specialities _currentSpec = new Specialities();
        public AE_Speciality(Specialities currentSpec)
        {
            InitializeComponent();
            if (currentSpec != null)
                _currentSpec = currentSpec;
            DataContext = _currentSpec;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentSpec.Speciality.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentSpec.ID == 0)
            {
                ClinicEntities.GetContext().Specialities.Add(_currentSpec);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new SpecialitiesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
