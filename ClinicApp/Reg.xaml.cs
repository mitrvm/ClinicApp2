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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        private Patients _newPat = new Patients();
        bool allGood;
        public Reg()
        {
            InitializeComponent();
            DataContext = _newPat;
        }

        private void Reg_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Reg_username_input.Text.Length>0 && Reg_password_input.Password.Length>0 && Reg_confirm_password_input.Password.Length>0&& Reg_SNILS_input.Text.Length > 0 && Reg_BD_input.Text.Length > 0)
            {
                allGood = true;

                if (Reg_password_input.Password!=Reg_confirm_password_input.Password)
                {
                    allGood= false;
                    ShowMSG("Passwords don't match.");
                }
                if (Reg_password_input.Password.Length < 6)
                {
                    allGood = false;
                    ShowMSG("Password must be 6 or more characters long.");
                }
                bool isNumeric = Reg_SNILS_input.Text.All(char.IsDigit);
                if (Reg_SNILS_input.Text.Length != 11||!isNumeric)
                {
                    allGood = false;
                    ShowMSG("SNILS must consist of 11 digits.");
                    
                }
                _newPat.Date_of_birth = DateTime.Parse(Reg_BD_input.SelectedDate.ToString());
                _newPat.SNILS = Reg_SNILS_input.Text;
                _newPat.DB_Password = Reg_password_input.Password;

                if (allGood)
                {
                    ClinicEntities.GetContext().Patients.Add(_newPat);
                    try
                    {
                        ClinicEntities.GetContext().SaveChanges();
                        ShowMSG("Your account has been succesfully created.");
                    }
                    catch (Exception ex)
                    {
                        ShowMSG(ex.Message + " tabarnak!!!!!!!!!");
                    }
                }
            }
            else
            {
                ShowMSG("Please fill out all the fields and try again.");
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new Login());
        }
        private async void ShowMSG(string msg)
        {
            MSG_User_Silly.Text = msg;
            MSG_User_Silly.Visibility = Visibility.Visible;
            await Task.Delay(5000);
            MSG_User_Silly.Visibility = Visibility.Hidden;
        }
    }
}
