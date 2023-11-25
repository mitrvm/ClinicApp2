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
    /// Логика взаимодействия для MedicalCardPage.xaml
    /// </summary>
    public partial class MedicalCardPage : Page
    {
        public MedicalCardPage()
        {
            InitializeComponent();
            UpdMCard();

            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (ugh.UPat)
            {
                Btn_DelMedC.Visibility = BtnAddMCardffff.Visibility  = editBtnCol.Visibility = Visibility.Collapsed;
                
            }
        }

        private void UpdMCard()
        {
            var currentMCards = ClinicEntities.GetContext().Medical_card.ToList();

            MainWindow ugh = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (ugh.UPat)
            {
                currentMCards = currentMCards.Where(p => p.Patient_ID.Equals(ugh.UID)).ToList();
            }

            var currentMCards1 = currentMCards.Select(p => new
            {
                ID = p.ID,
                Patient_ID = p.Patients.Full_name,
                Illness = p.Illness,
                End_date = p.End_date,
                Beginning_date = p.Beginning_date
            });

            if (TBoxSearch.Text.Length > 0)
            {
                currentMCards1 = currentMCards1.Where(p => p.Patient_ID.ToString().ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }

            DGrid_MedicalCard.ItemsSource = currentMCards1;
        }

        private void Btn_DelMedC_Click(object sender, RoutedEventArgs e)
        {

            var MCsForRemoving = DGrid_MedicalCard.SelectedItems;
            var AFData = ClinicEntities.GetContext().Medical_card.ToList();
            List<Medical_card> exList = new List<Medical_card>();

            foreach (var expense in MCsForRemoving)
            {
                int idStarts = Convert.ToInt32(expense.ToString().Substring(7).Split()[0].Trim(new char[] { ',' }));
                exList.Add(AFData.Find(p => p.ID == idStarts));
            }

            if (MessageBox.Show($"Вы точно хотите удалить следующие {exList.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Medical_card.RemoveRange(exList);
                    ClinicEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены.");

                    UpdMCard();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddMCard_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext;
            int idStarts = Convert.ToInt32(context.ToString().Substring(7).Split()[0].Trim(new char[] { ',' }))-1;
            var MCard = ClinicEntities.GetContext().Medical_card.ToList()[idStarts];
            Manager.MainFrame.Navigate(new AE_MedCard(MCard as Medical_card));
        }



        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            UpdMCard();
        }

        private void BtnAddMCardffff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AE_MedCard(null));
        }
    }
}
