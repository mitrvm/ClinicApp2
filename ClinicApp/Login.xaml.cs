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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        
        public Login()
        {
            InitializeComponent();
            
        }

        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            if (password_input.Password.Length != 0 && username_input.Text.Length != 0)
            {
                var User_D = ClinicEntities1.GetContext().Employees.FirstOrDefault(u => u.Full_name == username_input.Text && u.DB_Password == password_input.Password && u.Job_title_ID != 4);
                var User_P = ClinicEntities1.GetContext().Patients.FirstOrDefault(u => u.Full_name == username_input.Text && u.DB_Password == password_input.Password);
                var User_A = ClinicEntities1.GetContext().Employees.FirstOrDefault(u => u.Full_name == username_input.Text && u.DB_Password == password_input.Password && u.Job_title_ID==4);
                if (User_D != null)
                {
                    Manager.MainFrame.Navigate(new MainPage_ForDocs());
                    ugh.Tab_Home_D.Visibility = ugh.Tab_Pat.Visibility = ugh.Tab_Appoint.Visibility = ugh.Tab_Appoint_Fin.Visibility = ugh.Tab_Med_Card.Visibility = ugh.Tab_Dis.Visibility = ugh.Tab_Sched.Visibility = ugh.Tab_Medicine.Visibility = Visibility.Visible;
                }
                else if (User_P != null){
                    Manager.MainFrame.Navigate(new MainPage_ForPatients());
                    ugh.Tab_Home_P.Visibility = ugh.Tab_Appoint.Visibility = ugh.Tab_Appoint_Fin.Visibility = ugh.Tab_Dis.Visibility = ugh.Tab_Med_Card.Visibility = Visibility.Visible;
                }
                else if (User_A != null)
                {
                    Manager.MainFrame.Navigate(new MainPage_ForAdmin());
                    ugh.Tab_Home_A.Visibility = ugh.Tab_Pat.Visibility = ugh.Tab_Appoint.Visibility = ugh.Tab_Appoint_Fin.Visibility = ugh.Tab_Med_Card.Visibility = ugh.Tab_Dis.Visibility = ugh.Tab_Sched.Visibility = ugh.Tab_Medicine.Visibility = ugh.Tab_Emp.Visibility = ugh.Tab_Job_T.Visibility = ugh.Tab_Spec.Visibility = ugh.Tab_Serv.Visibility = Visibility.Visible;
                }
                else
                {
                    MSG_User_Idiot.Text = "Incorrect username or password.";
                    MSG_User_Idiot.Visibility = Visibility.Visible;
                    await Task.Delay(8000);
                    MSG_User_Idiot.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                MSG_User_Idiot.Text = "Please fill out all the fields and try again.";
                MSG_User_Idiot.Visibility = Visibility.Visible;
            }
        }

        private void SignUp_Btn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new Reg());
        }
    }
}
