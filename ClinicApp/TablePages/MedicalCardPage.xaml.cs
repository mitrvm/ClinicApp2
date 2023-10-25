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
    /// Логика взаимодействия для MedicalCardPage.xaml
    /// </summary>
    public partial class MedicalCardPage : Page
    {
        public MedicalCardPage()
        {
            InitializeComponent();
            DGrid_MedicalCard.ItemsSource = ClinicEntities1.GetContext().Medical_card.ToList();
        }

        private void Btn_DelMedC_Click(object sender, RoutedEventArgs e)
        {
            var medCardsForRemoving = DGrid_MedicalCard.SelectedItems.Cast<Medical_card>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {medCardsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Medical_card.RemoveRange(medCardsForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_MedicalCard.ItemsSource = ClinicEntities1.GetContext().Medical_card.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
