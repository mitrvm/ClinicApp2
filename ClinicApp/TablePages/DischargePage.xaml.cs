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
    /// Логика взаимодействия для DischargePage.xaml
    /// </summary>
    public partial class DischargePage : Page
    {
        public DischargePage()
        {
            InitializeComponent();
            DGrid_Discharges.ItemsSource = ClinicEntities1.GetContext().Discharges.ToList();
        }

        private void Btn_DelDis_Click(object sender, RoutedEventArgs e)
        {
            var disForRemoving = DGrid_Discharges.SelectedItems.Cast<Discharges>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {disForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Discharges.RemoveRange(disForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Discharges.ItemsSource = ClinicEntities1.GetContext().Discharges.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
