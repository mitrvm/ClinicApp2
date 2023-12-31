﻿using ClinicApp.AddEditPages;
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
    /// Логика взаимодействия для JobTitlesPage.xaml
    /// </summary>
    public partial class JobTitlesPage : Page
    {
        public JobTitlesPage()
        {
            InitializeComponent();
            UpdJTs();
        }
        private void UpdJTs()
        {
            var currentJTs = ClinicEntities.GetContext().Job_titles.ToList();
            currentJTs = currentJTs.Where(p => p.Job_title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            DGrid_JobTitles.ItemsSource = currentJTs;
        }

        private void Btn_DelJT_Click(object sender, RoutedEventArgs e)
        {
            var JTsForRemoving = DGrid_JobTitles.SelectedItems.Cast<Job_titles>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {JTsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicEntities.GetContext().Job_titles.RemoveRange(JTsForRemoving);
                    ClinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid_JobTitles.ItemsSource = ClinicEntities.GetContext().Job_titles.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddJT_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AE_JobTitle((sender as Button).DataContext as Job_titles));
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdJTs();
        }
    }
}
