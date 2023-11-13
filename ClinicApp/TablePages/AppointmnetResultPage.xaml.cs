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
    /// Логика взаимодействия для AppointmnetResultPage.xaml
    /// </summary>
    public partial class AppointmnetResultPage : Page
    {
        public AppointmnetResultPage()
        {
            InitializeComponent();


            UpdAppRes();
            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (ugh.UPat)
            {
                Btn_DelAppFin.Visibility = BtnAddAppResfff.Visibility = editBtnCol.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdAppRes()
        {
            var currentAppRes = ClinicEntities.GetContext().Appointment_results.ToList();
            var currentAppResTrue = ClinicEntities.GetContext().Appointment_results.ToList();

            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            if (ugh.UPat) { 
                foreach(int theId in ugh.appIDs)
                {
                    currentAppResTrue = currentAppRes.Where(p => p.Appointment_ID.Equals(theId)).ToList();
                }
            }

            if (TBoxSearch.Text.Length > 0)
            {
                currentAppResTrue = currentAppResTrue.Where(p => p.Appointment_ID.ToString().ToLower().Equals(TBoxSearch.Text)).ToList();
                currentAppRes = currentAppRes.Where(p => p.Appointment_ID.ToString().ToLower().Equals(TBoxSearch.Text)).ToList();
            }


            if (ugh.UPat)
            {
                var currentAppResTrueTrue = currentAppResTrue.Select(p => new
                {
                    ID = p.ID,
                    Appointment_ID = p.Appointment_ID,
                    Prescribed_medecine_ID = p.Medicines?.Medicine,
                    Diagnosis = p.Diagnosis

                });
                DGrid_Appointments_Res.ItemsSource = currentAppResTrueTrue;
            }
            else
            {
                var currentAppResPlus = currentAppRes.Select(p => new
                {
                    ID = p.ID,
                    Appointment_ID = p.Appointment_ID,
                    Diagnosis = p.Diagnosis,
                    Prescribed_medecine_ID = p.Medicines?.Medicine
                });


                DGrid_Appointments_Res.ItemsSource = currentAppResPlus;
            }
            
        }

        private void Btn_DelAppFin_Click(object sender, RoutedEventArgs e)
        {
            var appFForRemoving = DGrid_Appointments_Res.SelectedItems.Cast<Appointment_results>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {appFForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Appointment_results.RemoveRange(appFForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Appointments_Res.ItemsSource = ClinicEntities.GetContext().Appointment_results.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddAppRes_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext;
            int idStarts = Convert.ToInt32(context.ToString().Substring(7).Split()[0].Trim(new char[] { ',' }))-1;
            var AppR = ClinicEntities.GetContext().Appointment_results.ToList()[idStarts];
            Manager.MainFrame.Navigate(new AE_Appointments_Res(AppR as Appointment_results));

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdAppRes();
        }

        private void BtnAddAppResfff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AE_Appointments_Res(null));
        }
    }
}
