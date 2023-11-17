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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();

            var allJTs = ClinicEntities.GetContext().Job_titles.ToList();
            allJTs.Insert(0, new Job_titles {Job_title = "Все"});
            TBoxSearchJT.ItemsSource = allJTs;

            var allSpecs = ClinicEntities.GetContext().Specialities.ToList();
            allSpecs.Insert(0, new Specialities {Speciality  = "Все"});
            TBoxSearchSp.ItemsSource = allSpecs;

            UpdEmp();
        }
        
        private void UpdEmp()
        {
            var currentEmp = ClinicEntities.GetContext().Employees.ToList();

            if (TBoxSearchJT.SelectedIndex > 0)
            {
                currentEmp = currentEmp.Where(p => p.Job_title_ID.Equals(TBoxSearchJT.SelectedIndex)).ToList();
            }
            if (TBoxSearchSp.SelectedIndex > 0)
            {
                currentEmp = currentEmp.Where(p => p.Specialty_ID.Equals(TBoxSearchSp.SelectedIndex)).ToList();
            }
            if (TBoxSearch.Text.Length > 0)
            {
                currentEmp = currentEmp.Where(p => p.Full_name.ToString().ToLower().Contains(TBoxSearch.Text)).ToList();
            }


            var currentEmp1 = currentEmp.Select(p => new
            {
                ID = p.ID,
                Full_name = p.Full_name,
                Specialty_ID = p.Specialities?.Speciality,
                Job_title_ID = p.Job_titles.Job_title
            });



            DGrid_Employees.ItemsSource = currentEmp1;
        }

        private void Btn_DelEmp_Click(object sender, RoutedEventArgs e)
        {
            
            var EmpForRemoving = DGrid_Employees.SelectedItems;
            var EmpData = ClinicEntities.GetContext().Employees.ToList();
            List<Employees> exList = new List<Employees>();

            foreach (var expense in EmpData)
            {
                int idStarts = Convert.ToInt32(expense.ToString().Substring(7).Split()[0].Trim(new char[] { ',' }));
                exList.Add(EmpData.Find(p => p.ID == idStarts));
            }

            if (MessageBox.Show($"Вы точно хотите удалить следующие {exList.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Employees.RemoveRange(exList);
                    ClinicEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены.");

                    UpdEmp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext;
            int idStarts = Convert.ToInt32(context.ToString().Substring(7).Split()[0].Trim(new char[] { ',' })) - 1;
            var Emps = ClinicEntities.GetContext().Employees.ToList()[idStarts];
            Manager.MainFrame.Navigate(new AE_Employees(Emps as Employees));
        }

        private void TBoxSearchSp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdEmp();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdEmp();
        }

        private void BtnAddEmpfff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AE_Employees(null));
        }
    }
}
