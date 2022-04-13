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
using Homework_10;
using System.IO;
using Microsoft.Win32;
using System.Text.Json;

namespace Homework_10_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Organization org;
        public MainWindow()
        {
            InitializeComponent();
            listViewDepts.Visibility = Visibility.Hidden; /// изначально listView с отделами скрыт
        }

        /// <summary>
        /// Событие при нажатии кнопки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); /// создание окна для указания пути к json файлу

            if (openFileDialog.ShowDialog() == true)
            {
                org = JsonSerializer.Deserialize<Organization>(File.ReadAllText(openFileDialog.FileName)); /// считываем файл

                listViewWorkers.ItemsSource = org.workers; /// отображаем сотрудников
                listViewDepts.ItemsSource = org.depts; /// отображаем отделы

                /// Вывод информация о данной компании
                textblockName.Text = $"Название компании:   {org.Name}";
                textblockWorkers.Text = $"Количество сотрудников:   {org.workers.Count}";
                textblockDepts.Text = $"Количество отделов:   {org.depts.Count}";

                listViewWorkers.Items.Refresh(); /// обновляем для отображения данных
            }
                
        }

        /// <summary>
        /// Событие при нажатии "Показать отделы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listViewWorkers.Visibility = Visibility.Hidden; /// скрываем lisView с рабочими
            listViewDepts.Visibility = Visibility.Visible; /// отображаем listView с отделами
        }

        /// <summary>
        /// Событие при нажатии "Показать сотрудников"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listViewDepts.Visibility = Visibility.Hidden; /// скрываем listView с отделами 
            listViewWorkers.Visibility = Visibility.Visible; /// отображаем lisView с рабочими
        }

    }
}
