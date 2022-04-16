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
using System.Windows.Shapes;
using Homework_10;

namespace Homework_11_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        public AddWorker()
        {
            InitializeComponent();
            workers = new List<Worker>(); /// создаем новый список сотрудников
        }

        /// <summary>
        /// Событие при нажатии "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (workers.Count == 0) /// если список пустой
            {
                workers.Add(GetWorker()); /// добавляем этого сотрудника
            }
            DialogResult = true; /// закрываем окно
        }

        /// <summary>
        /// Метод возрвращает нового сотрудника
        /// </summary>
        /// <returns></returns>
        public Worker GetWorker()
        {
            return new Worker(
                textbox_add_firstname.Text,
                textbox_add_lastname.Text,
                textbox_add_pos.Text,
                1,
                Convert.ToInt32(textbox_add_age.Text),
                textbox_add_dept.Text,
                Convert.ToDouble(textbox_add_salary.Text),
                Convert.ToInt32(textbox_add_project.Text));
        }

        /// <summary>
        /// Автоматическое свойство список сотрудников
        /// </summary>
        public List<Worker> workers { get; set; }

        /// <summary>
        /// Событие при нажатии "Добавить еще"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            workers.Add(GetWorker()); /// добавляем рабочего в список

            /// Очищаем поля
            textbox_add_firstname.Clear();
            textbox_add_lastname.Clear();
            textbox_add_pos.Clear();
            textbox_add_age.Clear();
            textbox_add_dept.Clear();
            textbox_add_salary.Clear();
            textbox_add_project.Clear();
        }
    }
}
