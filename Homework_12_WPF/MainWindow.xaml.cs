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
using Homework_12;
using System.IO;
using Microsoft.Win32;
using System.Text.Json;

namespace Homework_12_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bank bank;
        bool flag;
        int indexGlobal;

        public MainWindow()
        {
            InitializeComponent();
            flag = true; /// переключатель для кнопки "Перевести"
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
                bank = JsonSerializer.Deserialize<Bank>(File.ReadAllText(openFileDialog.FileName)); /// считываем файл

                listViewClients.ItemsSource = bank.clients; /// добавляем данные в listview
            }

        }

        /// <summary>
        /// Событие при нажатии "Перевести"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_TransferMoney_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewClients.SelectedIndex; /// номер выбранного клиента
            int sum = Convert.ToInt32(textbox_Money.Text); /// введенная сумма

            if (flag) /// если кнопку нажали в первый раз
            {
                if (bank.clients[index].Cash >= sum) /// проверяем хватает ли денежных средств у клиента
                {
                    indexGlobal = index; /// запоминаем номер клиента
                    MessageBox.Show("Выберите клиента, которому хотите перевести деньги и нажмите \"Перевести\"");
                    flag = false; /// переключаем
                }
                else MessageBox.Show("Недостаточно средств");
            }
            else /// кнопку нажали во второй раз
            {
                bank.TransferMoney(indexGlobal, index, sum); /// перевод денежных средств
                flag = true; /// переключаем

                /// Обновляем listview
                listViewClients.ItemsSource = bank.clients;
                listViewClients.Items.Refresh();
            }
        }

        /// <summary>
        /// Событие при нажатии "Открыть вклад (без кап.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OpenDeposit_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewClients.SelectedIndex; /// номер выбранного клиента
            int sum = Convert.ToInt32(textbox_Money.Text); /// введенная сумма
            int month = Convert.ToInt32(textbox_Month.Text); /// введенный срок

            if (month > 2 && month < 25) /// проверка на допустимый срок вклада
            {
                if (sum > 0) /// проверка на корректность суммы
                {
                    double deposit = bank.OpenDeposit(index, sum, month); /// открытие вклада (возврат, того сколько сколько клиент получит по истечению срока)

                    if (bank.clients[index].Cash > deposit) /// проверяем есть ли такая сумма на счету
                        textbox_Sum.Text = $"{deposit}";
                    else MessageBox.Show("Недостаточно средств");
                }
                else MessageBox.Show("Некорректная сумма");
            }
            else MessageBox.Show("Срок вклада от 3 до 24 месяцев");

            listViewClients.Items.Refresh(); /// обновление listview
        }

        /// <summary>
        /// Событие при нажатии "Открыть вклад (с кап.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OpenDepositCap_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewClients.SelectedIndex; /// номер выбранного клиента
            int sum = Convert.ToInt32(textbox_Money.Text); /// введенная сумм
            int month = Convert.ToInt32(textbox_Month.Text); /// введенный срок

            if (month > 2 && month < 25)  /// проверка на допустимый срок вклада
            {
                if (sum > 0) /// проверка на корректность суммы
                {
                    double deposit = bank.OpenDeposit(index, sum, month); /// открытие вклада (возврат, того сколько сколько клиент получит по истечению срока)

                    if (bank.clients[index].Cash > deposit) /// проверяем есть ли такая сумма на счету
                        textbox_Sum.Text = $"{deposit}";
                    else MessageBox.Show("Недостаточно средств");
                }
                else MessageBox.Show("некорректная сумма");
            }
            else MessageBox.Show("Срок вклада от 3 до 24 месяцев");

            listViewClients.Items.Refresh(); /// обновление listview
        }

        /// <summary>
        /// Событие при нажатии "Выдать кредит"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Credit_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewClients.SelectedIndex; /// номер выбранного клиента
            int sum = Convert.ToInt32(textbox_Money.Text); /// введенная сумм
            int month = Convert.ToInt32(textbox_Month.Text); /// введенный срок

            if (month > 11 && month < 85) /// проверка на допустимый срок кредита
            {
                if (sum > 0) /// проверка на корректность суммы
                {
                    double credit = bank.Credit(index, sum, month); /// выдача кредита
                    textbox_Sum.Text = $"{credit}";  /// отображение информации об ежемесячной выплате
                }
                else MessageBox.Show("Некорректная сумма");
            }
            else MessageBox.Show("Срок кредита от 1 года до 7 лет");

            listViewClients.Items.Refresh(); /// обновление listview
        }

    }
}
