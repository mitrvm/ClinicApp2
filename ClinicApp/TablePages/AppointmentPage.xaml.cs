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
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {

        public AppointmentPage()
        {
            InitializeComponent();

            var allStatuses = new List<string> { "Все", "Не проведен", "Проведен", "Отменен" };
            SearchS.ItemsSource= allStatuses;

            SearchS.SelectedIndex = 0;

            UpdApps();

            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (ugh.UPat)
            {
                editBtnCol.Visibility = Visibility.Collapsed;
            }
        }
        private void UpdApps()
        {
            var currentApps = ClinicEntities.GetContext().Appointments.ToList();


            if (TBoxSearch.Text.Length > 0 ) {
                currentApps = currentApps.Where(p => p.ID.ToString().ToLower().Equals(TBoxSearch.Text)).ToList();
            }

            if (SearchS.SelectedIndex > 0)
            {
                currentApps = currentApps.Where(p => p.Status.ToLower().Equals(SearchS.SelectedItem.ToString().ToLower())).ToList();
            }

            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (ugh.UPat)
            {
                currentApps = currentApps.Where(p => p.Patient_ID.Equals(ugh.UID)).ToList();
                
            }

            var currentApps1 = currentApps.Select(p => new
            {
                ID = p.ID,
                Date = p.Date,
                Service_ID = p.Services.Service,
                Patient_ID = p.Patients.Full_name,
                Doctor_ID = p.Employees.Full_name,
                Status = p.Status

            });

            DGrid_Appointments.ItemsSource = currentApps1;
        }


        private void Btn_DelApp_Click(object sender, RoutedEventArgs e)
        {
           


            var appForRemoving = DGrid_Appointments.SelectedItems;
            var AFData = ClinicEntities.GetContext().Appointments.ToList();
            List<Appointments> exList = new List<Appointments>();

            foreach (var expense in appForRemoving)
            {
                int idStarts = Convert.ToInt32(expense.ToString().Substring(7).Split()[0].Trim(new char[] { ',' }));
                exList.Add(AFData.Find(p => p.ID == idStarts));
            }

            if (MessageBox.Show($"Вы точно хотите удалить следующие {exList.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Appointments.RemoveRange(exList);
                    ClinicEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены.");

                    UpdApps();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddApp_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext;
            int idStarts = Convert.ToInt32(context.ToString().Substring(7).Split()[0].Trim(new char[] { ',' }))-1;
            var App = ClinicEntities.GetContext().Appointments.ToList()[idStarts];
            Manager.MainFrame.Navigate(new AE_Appointments(App as Appointments));
        }

        private void TBoxSearchS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdApps();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdApps();
        }

        private void BtnAddAppfff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AE_Appointments(null));
        }
    }
}
