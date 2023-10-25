using ClinicApp.MainPages;
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

namespace ClinicApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage_ForAdmin.xaml
    /// </summary>
    public partial class MainPage_ForAdmin : Page
    {
        public MainPage_ForAdmin()
        {
            InitializeComponent();
        }

        public async void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new PatientsPage());
        }

        private async void Move_ToDischarges_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new DischargePage());
        }

        private async void Move_ToAppointmentsFin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new AppointmnetResultPage());
        }

        private async void Move_ToMedCards_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MedicalCardPage());
        }


        private async void Move_ToMedicines_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MedicinePage());
        }

        private async void Move_ToSchedules_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new SchedulePage());
        }

        private async void Move_ToEmployees_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new EmployeesPage());
        }

        private async void Move_ToJobTitles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new JobTitlesPage());
        }

        private async void Move_ToSpec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new SpecialitiesPage());
        }

        private async void Move_ToServices_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new ServicesPage());
        }

        private async void Move_ToAppointments_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new AppointmentPage());
        }
    }
}
