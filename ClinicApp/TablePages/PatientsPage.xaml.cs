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
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();
            DGrid_Patients.ItemsSource = ClinicEntities1.GetContext().Patients.ToList();
        }

        private void Btn_DelPat_Click(object sender, RoutedEventArgs e)
        {
            var patForRemoving = DGrid_Patients.SelectedItems.Cast<Patients>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {patForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    ClinicEntities1.GetContext().Patients.RemoveRange(patForRemoving);
                    ClinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_Patients.ItemsSource = ClinicEntities1.GetContext().Patients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
