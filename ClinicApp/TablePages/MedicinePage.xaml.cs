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
            DGrid_Medicine.ItemsSource = ClinicEntities1.GetContext().Medicines.ToList();
        }

        private void Btn_DelMedicine_Click(object sender, RoutedEventArgs e)
        {
            var medicineForRemoving = DGrid_Medicine.SelectedItems.Cast<Medicines>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {medicineForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Medicines.RemoveRange(medicineForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Medicine.ItemsSource = ClinicEntities1.GetContext().Medicines.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
