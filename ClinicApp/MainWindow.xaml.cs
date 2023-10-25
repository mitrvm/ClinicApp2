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
using System.Windows.Threading;

namespace ClinicApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        double panelWidth;
        bool hidden;
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,10);
            timer.Tick += Timer_Tick;
            panelWidth = sidePanel.Width;
            sidePanel.Width = 55;
            hidden = true;


            MainFrame.Navigate(new Login());
            Manager.MainFrame = MainFrame;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 4;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 4;
                if (sidePanel.Width <= 55)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void topPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private async void Tab_Pat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new PatientsPage());
        }

        private async void Tab_Appoint_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new AppointmentPage());
        }

        private async void Tab_Appoint_Fin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new AppointmnetResultPage());
        }

        private async void Tab_Med_Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MedicalCardPage());
        }

        private async void Tab_Dis_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new DischargePage());
        }

        private async void Tab_Medicine_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MedicinePage());
        }

        private async void Tab_Sched_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new SchedulePage());
        }

        private async void Tab_Emp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new EmployeesPage());
        }

        private async void Tab_Job_T_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new JobTitlesPage());
        }

        private async void Tab_Spec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new SpecialitiesPage());
        }

        private async void Tab_Serv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new ServicesPage());
        }

        private async void Tab_Home_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MainPage_ForPatients());
        }

        private async void Tab_Home_D_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MainPage_ForDocs());
        }

        private async void Tab_Home_A_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Manager.MainFrame.Navigate(new LoadingPage());
            await Task.Delay(1000);
            Manager.MainFrame.Navigate(new MainPage_ForAdmin());
        }
    }
   
}
