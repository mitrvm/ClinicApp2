﻿using System;
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
            DGrid_Services.ItemsSource = ClinicEntities1.GetContext().Services.ToList();
        }

        private void Btn_DelSer_Click(object sender, RoutedEventArgs e)
        {
            var serForRemoving = DGrid_Services.SelectedItems.Cast<Services>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {serForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Services.RemoveRange(serForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Services.ItemsSource = ClinicEntities1.GetContext().Services.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
