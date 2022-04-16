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
    /// Логика взаимодействия для AddDept.xaml
    /// </summary>
    public partial class AddDept : Window
    {
        public AddDept()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие при нажатии "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        /// <summary>
        /// Метод возвращает новый отдел
        /// </summary>
        /// <returns></returns>
        public Department GetDept()
        {
            return new Department(
                textbox_add_name.Text,
                DateTime.Now,
                Convert.ToInt32(textbox_add_workers.Text),
                Convert.ToInt32(textbox_add_level.Text),
                new List<Worker>());
        }

    }
}
