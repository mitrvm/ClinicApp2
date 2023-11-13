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
    /// Логика взаимодействия для SpecialitiesPage.xaml
    /// </summary>
    public partial class SpecialitiesPage : Page
    {
        public SpecialitiesPage()
        {
            InitializeComponent();
            UpdSpec();
        }

        private void UpdSpec()
        {
            var currentSpecs = ClinicEntities.GetContext().Specialities.ToList();

            currentSpecs = currentSpecs.Where(p => p.Speciality.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            DGrid_Specialities.ItemsSource = currentSpecs;
        }
        private void Btn_DelSpec_Click(object sender, RoutedEventArgs e)
        {
            var specForRemoving = DGrid_Specialities.SelectedItems.Cast<Specialities>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {specForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) 
            {
                try
                {
                    ClinicEntities.GetContext().Specialities.RemoveRange(specForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Specialities.ItemsSource = ClinicEntities.GetContext().Specialities.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddSpec_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AE_Speciality((sender as Button).DataContext as Specialities));
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdSpec();
        }
    }
}
