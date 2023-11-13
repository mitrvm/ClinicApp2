using ClinicApp.AddEditPages;
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

namespace ClinicApp.TablePages
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();
            UpdPatients();
        }

        private void UpdPatients()
        {
            var currentPats = ClinicEntities.GetContext().Patients.ToList();
            currentPats = currentPats.Where(p => p.Full_name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            currentPats = currentPats.Where(p => p.SNILS.ToLower().Contains(TBoxSearchS.Text.ToLower())).ToList();

            DGrid_Patients.ItemsSource = currentPats;
        }

        private void Btn_DelPat_Click(object sender, RoutedEventArgs e)
        {
            var patForRemoving = DGrid_Patients.SelectedItems.Cast<Patients>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {patForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Patients.RemoveRange(patForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Patients.ItemsSource = ClinicEntities.GetContext().Patients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddPat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AE_Patient((sender as Button).DataContext as Patients));
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdPatients();
        }
    }
}
