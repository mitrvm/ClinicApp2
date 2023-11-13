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
    /// Логика взаимодействия для MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        public MedicinePage()
        {
            InitializeComponent();
            UpdMedicine();
        }

        private void UpdMedicine()
        {
            var currentMed = ClinicEntities.GetContext().Medicines.ToList();

            currentMed = currentMed.Where(p => p.Medicine.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            DGrid_Medicine.ItemsSource = currentMed;
        }


        private void Btn_DelMedicine_Click(object sender, RoutedEventArgs e)
        {
            var medicineForRemoving = DGrid_Medicine.SelectedItems.Cast<Medicines>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {medicineForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Medicines.RemoveRange(medicineForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Medicine.ItemsSource = ClinicEntities.GetContext().Medicines.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddMed_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AE_Medicine((sender as Button).DataContext as Medicines));
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdMedicine();
        }
    }
}
