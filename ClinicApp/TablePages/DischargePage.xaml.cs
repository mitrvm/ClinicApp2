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

namespace ClinicApp
{
    /// <summary>
    /// Логика взаимодействия для DischargePage.xaml
    /// </summary>
    public partial class DischargePage : Page
    {
        public DischargePage()
        {
            InitializeComponent();
            var currentDis = ClinicEntities.GetContext().Discharges.ToList();

            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (ugh.UPat)
            {
                Btn_DelDis.Visibility = BtnAddDisfff.Visibility = editBtnCol.Visibility = Visibility.Collapsed;
            }

            if (ugh.UPat)
            {
                currentDis = currentDis.Where(p => p.Patient_ID.Equals(ugh.UID)).ToList();
            }

            var currentDis1 = currentDis.Select(p => new
            {
                ID = p.ID,
                Discharge_date = p.Discharge_date,
                Patient_ID = p.Patients.Full_name,
                Doctor_ID = p.Employees.Full_name

            });

            DGrid_Discharges.ItemsSource = currentDis1;

        }

        private void Btn_DelDis_Click(object sender, RoutedEventArgs e)
        {
            var disForRemoving = DGrid_Discharges.SelectedItems.Cast<Discharges>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {disForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Discharges.RemoveRange(disForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Discharges.ItemsSource = ClinicEntities.GetContext().Discharges.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddDis_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext;
            int idStarts = Convert.ToInt32(context.ToString().Substring(7).Split()[0].Trim(new char[] { ',' })) - 1;
            var Disc = ClinicEntities.GetContext().Discharges.ToList()[idStarts];
            Manager.MainFrame.Navigate(new AE_Discharge(Disc as Discharges));
        }

        private void BtnAddDisfff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AE_Discharge(null));
        }
    }
}
