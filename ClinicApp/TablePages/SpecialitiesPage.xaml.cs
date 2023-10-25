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
            DGrid_Specialities.ItemsSource = ClinicEntities1.GetContext().Specialities.ToList();
        }

        private void Btn_DelSpec_Click(object sender, RoutedEventArgs e)
        {
            var specForRemoving = DGrid_Specialities.SelectedItems.Cast<Specialities>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {specForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Specialities.RemoveRange(specForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Specialities.ItemsSource = ClinicEntities1.GetContext().Specialities.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
