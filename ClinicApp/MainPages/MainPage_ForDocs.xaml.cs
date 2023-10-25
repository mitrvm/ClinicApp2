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
    /// Логика взаимодействия для MainPage_ForDocs.xaml
    /// </summary>
    public partial class MainPage_ForDocs : Page
    {
        public MainPage_ForDocs()
        {
            InitializeComponent();
        }

        private async void Move_ToPatients_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private async void Move_ToApp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new AppointmentPage());
        }

        private async void Move_ToAppFin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private async void Move_ToSched_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new SchedulePage());
        }

        private async void Move_ToMedicine_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MedicinePage());
        }
    }
}
