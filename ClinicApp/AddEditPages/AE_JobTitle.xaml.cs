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
    /// Логика взаимодействия для AE_JobTitle.xaml
    /// </summary>
    public partial class AE_JobTitle : Page
    {
        private Job_titles _currentJTs = new Job_titles();
        public AE_JobTitle(Job_titles currentJTs)
        {
            InitializeComponent();
            if (currentJTs != null)
                _currentJTs = currentJTs;
            DataContext = _currentJTs;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentJTs.Job_title.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentJTs.ID == 0)
            {
                ClinicEntities.GetContext().Job_titles.Add(_currentJTs);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new JobTitlesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
