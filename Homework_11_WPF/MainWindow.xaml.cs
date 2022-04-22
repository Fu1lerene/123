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


namespace Homework_11_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Organization org;
        private bool flag;

        public MainWindow()
        {
            InitializeComponent();
            
            flag = true; /// переключатель между таблицей сотрудников и отделов
            listViewDepts.Visibility = Visibility.Hidden; /// изначально listView с отделами скрыт
        }

        /// <summary>
        /// Событие при нажатии "Загрузить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); /// создание окна для указания пути к json файлу

            if (openFileDialog.ShowDialog() == true)
            {
                org = JsonSerializer.Deserialize<Organization>(File.ReadAllText(openFileDialog.FileName)); /// считываем файл

                RefreshListviewItems(); /// обновляем для отображения данных

                /// Вывод информация о данной компании
                textblockName.Text = $"Название компании:   {org.Name}";
                textblockWorkers.Text = $"Количество сотрудников:   {org.workers.Count}";
                textblockDepts.Text = $"Количество отделов:   {org.depts.Count}";

                /// Активируем кнопки "Добавить" и "Удалить"
                Button_Add.IsEnabled = true;
                Button_Delete.IsEnabled = true;
            }
                
        }

        /// <summary>
        /// Событие при нажатии "Показать отделы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ShowDepts_Click(object sender, RoutedEventArgs e)
        {
            flag = false; /// работаем с отделами

            /// Скрываем все из "Сотрудников" и отображаем "Отделы"
            listViewWorkers.Visibility = Visibility.Hidden;
            listViewDepts.Visibility = Visibility.Visible; 
            textblock_firstname.Visibility = Visibility.Hidden;
            textblock_lastname.Visibility = Visibility.Hidden;
            textblock_salary.Visibility = Visibility.Hidden;
            textblock_name.Visibility = Visibility.Visible;
            textbox_firstName.Visibility = Visibility.Hidden;
            textbox_lastName.Visibility = Visibility.Hidden;
            textbox_salary.Visibility = Visibility.Hidden;
            textbox_nameDept.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Событие при нажатии "Показать сотрудников"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ShowWorkers_Click(object sender, RoutedEventArgs e)
        {
            flag = true; /// работаем с сотрудниками

            /// Скрываем все из "Отделы" и отображаем "Сотрудников"
            listViewDepts.Visibility = Visibility.Hidden;
            listViewWorkers.Visibility = Visibility.Visible;
            textblock_firstname.Visibility = Visibility.Visible;
            textblock_lastname.Visibility = Visibility.Visible;
            textblock_salary.Visibility = Visibility.Visible;
            textblock_name.Visibility = Visibility.Hidden;
            textbox_firstName.Visibility = Visibility.Visible;
            textbox_lastName.Visibility = Visibility.Visible;
            textbox_salary.Visibility = Visibility.Visible;
            textbox_nameDept.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Событие при нажатии "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (flag) /// если открыты сотрудники
            {
                AddWorker addWorkerWindow = new AddWorker(); /// создаем окно с добавлением сотрудника

                if (addWorkerWindow.ShowDialog() == true)
                {
                    org.workers.AddRange(addWorkerWindow.workers); /// добавляем сотрудников
                    org.workers[org.workers.Count - 1].Id = org.workers[org.workers.Count - 2].Id + 1; /// изменяем индекс нового сотрудника
                }

            }
            else /// если открыты отделы
            {
                AddDept addDeptWindow = new AddDept(); /// создаем окно с добавлением отдела

                if(addDeptWindow.ShowDialog() == true)
                {
                    org.depts.Add(addDeptWindow.GetDept()); /// добавление отдела
                }
            }
            /// Обновляем все данные
            RefreshListviewItems();
            textblockWorkers.Text = $"Количество сотрудников:   {org.workers.Count}";
            textblockDepts.Text = $"Количество отделов:   {org.depts.Count}";
        }

        /// <summary>
        /// Событие при нажатии "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (flag) /// если открыты сотрудники
            {
                DeleteWorker();
            }
            else /// если открыты отделы
            {
                DeleteDept();
            }

            /// Обновляем информацию
            RefreshListviewItems();
            textblockWorkers.Text = $"Количество сотрудников:   {org.workers.Count}";
            textblockDepts.Text = $"Количество отделов:   {org.depts.Count}";
        }

        #region Сортировка

        private void TextBlock_MouseDown_ID(object sender, MouseButtonEventArgs e)
        {
            SortByID();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Firstname(object sender, MouseButtonEventArgs e)
        {
            SortByFirstname();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Lastname(object sender, MouseButtonEventArgs e)
        {
            SortByLastname();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Age(object sender, MouseButtonEventArgs e)
        {
            SortByAge();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Position(object sender, MouseButtonEventArgs e)
        {
            SortByPosition();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Dept(object sender, MouseButtonEventArgs e)
        {
            SortByDept();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Salary(object sender, MouseButtonEventArgs e)
        {
            SortBySalary();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Projects(object sender, MouseButtonEventArgs e)
        {
            SortByProject();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Name(object sender, MouseButtonEventArgs e)
        {
            SortByName();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Date(object sender, MouseButtonEventArgs e)
        {
            SortByDate();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Level(object sender, MouseButtonEventArgs e)
        {
            SortByLevel();
            RefreshListviewItems();
        }
        private void TextBlock_MouseDown_Workers(object sender, MouseButtonEventArgs e)
        {
            SortByWorkers();
            RefreshListviewItems();
        }


        /// <summary>
        /// Сортировка по номеру
        /// </summary>
        private void SortByID()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.Id).ToList();
        }
        /// <summary>
        /// Сортировка по имени
        /// </summary>
        private void SortByFirstname()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.Firstname).ToList();
        }
        /// <summary>
        /// Сортировка по фамилии
        /// </summary>
        private void SortByLastname()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.Lastname).ToList();
        }
        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        private void SortByAge()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.Age).ToList();
        }
        /// <summary>
        /// Сортировка по должности
        /// </summary>
        private void SortByPosition()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.Position).ToList();
        }
        /// <summary>
        /// Сортировка по отделам
        /// </summary>
        private void SortByDept()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.Dept).ToList();
        }
        /// <summary>
        /// Сортировка по оплате труда
        /// </summary>
        private void SortBySalary()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.Salary).ToList();
        }
        /// <summary>
        /// Сортировка по количеству проектов
        /// </summary>
        private void SortByProject()
        {
            foreach (var item in org.workers)
                org.workers = org.workers.OrderBy(x => x.NumberOfProjects).ToList();
        }
        /// <summary>
        /// Сортировка по названию
        /// </summary>
        private void SortByName()
        {
            foreach (var item in org.depts)
                org.depts = org.depts.OrderBy(x => x.Name).ToList();
        }
        /// <summary>
        /// Сортировка по дате создания
        /// </summary>
        private void SortByDate()
        {
            foreach (var item in org.depts)
                org.depts = org.depts.OrderBy(x => x.DateOfCreation).ToList();
        }
        /// <summary>
        /// Сортировака по уровню
        /// </summary>
        private void SortByLevel()
        {
            foreach (var item in org.depts)
                org.depts = org.depts.OrderBy(x => x.Lvl).ToList();
        }
        /// <summary>
        /// Сортировка по количеству сотрудников в отделе
        /// </summary>
        private void SortByWorkers()
        {
            foreach (var item in org.depts)
                org.depts = org.depts.OrderBy(x => x.NumberOfWorkers).ToList();
        }

        #endregion

        /// <summary>
        /// Обновление всех listview
        /// </summary>
        private void RefreshListviewItems()
        {
            listViewWorkers.ItemsSource = org.workers;
            listViewDepts.ItemsSource = org.depts;
            listViewWorkers.Items.Refresh();
            listViewDepts.Items.Refresh();
        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        private void DeleteDept()
        {
            int tempId = listViewDepts.SelectedIndex; /// индекс выбранного отдела

            if (tempId >= 0 && tempId <= org.depts.Count && org.depts.Count != 0) /// если отделов не 0 и индекс в допустимых пределах
            {
                if (org.depts[tempId].NumberOfWorkers != 0)  /// если сотрудников в данном отделе не 0 
                {
                    string caption = "Внимание";
                    string message = "В этом отделе остались сотрудники!\nВы уверены, что хотите продолжить?\n(Все сотрудники в этом отделе будут удалены)";

                    var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo); /// вызываем предупреждающее окно

                    if (result == MessageBoxResult.Yes) /// если ответ положительный
                    {
                        for (int i = 0; i < org.workers.Count; ++i) /// удаляем всех сотрудников
                        {
                            if (org.workers[i].Dept == org.depts[tempId].Name) /// которые принадлежат этому отделу
                            {
                                org.workers.RemoveAt(i);
                                i--;
                            }
                        }
                        org.depts.RemoveAt(tempId); /// удаляем сам отдел
                    }
                }
                else /// если сотрудников в этом отделе не было
                {
                    org.depts.RemoveAt(tempId); /// удаляем отдел
                }
            }
                
            
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        private void DeleteWorker()
        {
            int tempId = listViewWorkers.SelectedIndex; /// индекс выбранного сотрудника

            if (org.workers.Count != 0 && tempId >= 0 && tempId <= org.workers.Count) /// если сотрудников не 0 и индекс в допустимых пределах
            {
                foreach (var item in org.depts) /// находим в отделах
                {
                    if (org.workers[tempId].Dept == item.Name) /// совпадающее название
                    {
                        item.NumberOfWorkers--; /// и уменьшаем количество сотрудников в этом отделе
                    }
                }

                org.workers.RemoveAt(tempId); /// удаляем выбранного сотрудника

                foreach (var item in org.workers) /// меняем номер оставшихся сотрудников
                {
                    if (item.Id > tempId)
                        item.Id--;
                }
            }
        }

        /// <summary>
        /// Изменение названия отдела у сотрудников при смене названия отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_nameDept_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textbox_nameDept.Text.Length != 0) /// если строка пустая или отсуствует название
            {
                int tempId = listViewDepts.SelectedIndex; /// индекс выбранного отдела

                foreach (var item in org.workers) /// находим всех сотрудников в данном отделе
                {
                    if (item.Dept == org.depts[tempId].Name)
                    {
                        item.Dept = textbox_nameDept.Text; /// меняем название отдела
                    }
                }
                RefreshListviewItems();
            }
            else
            {
                textbox_nameDept.Text = "???";
            }
        }
    }
}
