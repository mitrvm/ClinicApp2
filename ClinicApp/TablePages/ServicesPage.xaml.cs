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
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            UpdServ();
        }
        private void UpdServ()
        {
            var currentServs = ClinicEntities.GetContext().Services.ToList();

            currentServs = currentServs.Where(p => p.Service.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            DGrid_Services.ItemsSource = currentServs;
        }
        private void Btn_DelSer_Click(object sender, RoutedEventArgs e)
        {
            var serForRemoving = DGrid_Services.SelectedItems.Cast<Services>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {serForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Services.RemoveRange(serForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Services.ItemsSource = ClinicEntities.GetContext().Services.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddSer_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AE_Service((sender as Button).DataContext as Services));
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdServ();
        }
    }
}
