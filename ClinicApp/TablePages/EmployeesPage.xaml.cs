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
            DGrid_Employees.ItemsSource = ClinicEntities1.GetContext().Employees.ToList();
        }

        private void Btn_DelEmp_Click(object sender, RoutedEventArgs e)
        {
            var empForRemoving = DGrid_Employees.SelectedItems.Cast<Employees>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {empForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Employees.RemoveRange(empForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Employees.ItemsSource = ClinicEntities1.GetContext().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
