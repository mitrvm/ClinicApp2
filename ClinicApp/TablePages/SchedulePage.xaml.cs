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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();

            
            var currentSch = ClinicEntities.GetContext().Schedules.ToList();
            var currentSch1 = currentSch.Select(p => new
            {
                ID = p.ID,
                Employee_ID = p.Employees.Full_name,
                Date_and_time = p.Date_and_time,
                Booked = p.Booked
            });

            DGrid_Schedule.ItemsSource = currentSch1;
        }

        private void Btn_DelSch_Click(object sender, RoutedEventArgs e)
        {
            var schForRemoving = DGrid_Schedule.SelectedItems.Cast<Schedules>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {schForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Schedules.RemoveRange(schForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Schedule.ItemsSource = ClinicEntities.GetContext().Schedules.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddSch_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AE_Schedule((sender as Button).DataContext as Schedules));
        }
    }
}
