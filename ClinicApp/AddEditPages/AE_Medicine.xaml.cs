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
    /// Логика взаимодействия для AE_Medicine.xaml
    /// </summary>
    public partial class AE_Medicine : Page
    {

        private Medicines _currentMedicines = new Medicines();
        public AE_Medicine(Medicines currentMedicines)
        {
            InitializeComponent();
            if (currentMedicines != null)
                _currentMedicines = currentMedicines;
            DataContext = _currentMedicines;
        }

        private void BtnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentMedicines.Medicine.ToString().Length == 0 || _currentMedicines.Purpose.ToString().Length == 0)
                errors.AppendLine("Please fill out all the fields and try again.");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMedicines.ID == 0)
            {
                ClinicEntities.GetContext().Medicines.Add(_currentMedicines);
            }
            try
            {
                ClinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved.");

                Manager.MainFrame.Navigate(new MedicinePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
