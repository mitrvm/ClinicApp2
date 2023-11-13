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
    /// Логика взаимодействия для AE_Service.xaml
    /// </summary>
    public partial class AE_Service : Page
    {

        private Services _currentServ = new Services();
        public AE_Service(Services currentServ)
        {
            InitializeComponent();
            if (currentServ != null)
                _currentServ = currentServ;
            DataContext = _currentServ;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentServ.Service.ToString().Length == 0 || _currentServ.Cost.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentServ.ID == 0)
            {
                ClinicEntities.GetContext().Services.Add(_currentServ);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new ServicesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
