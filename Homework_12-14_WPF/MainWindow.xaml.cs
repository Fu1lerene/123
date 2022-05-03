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
using System.IO;
using Microsoft.Win32;
using System.Text.Json;
using Homework_12_14;

namespace Homework_12_14_WPF
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

            try 
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    bank = JsonSerializer.Deserialize<Bank>(File.ReadAllText(openFileDialog.FileName)); /// считываем файл

                    foreach (var item in bank.clients) /// оформляем подписку всех клиентов на рассылку уведомлений
                        item.Notify += HandleNotify;

                    listViewClients.ItemsSource = bank.clients; /// добавляем данные в listview
                }
            }
            catch /// если будет выбран не json файл с необходимой структурой
            {
                MessageBox.Show("Неверный формат, выберите json файл");
            }

        }

        /// <summary>
        /// Событие при нажатии "Перевести"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_TransferMoney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = listViewClients.SelectedIndex; /// номер выбранного клиента
                double sum = Convert.ToDouble(textbox_Money.Text); /// введенная сумма

                if (sum <= 0) throw new ArgumentException(); /// пробрасываем исключение, если введена отрицательная сумма

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
            catch (ArgumentException)
            {
                MessageBox.Show("Некорректная сумма");
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно");
            }
        }

        /// <summary>
        /// Событие при нажатии "Открыть вклад (без кап.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OpenDeposit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = listViewClients.SelectedIndex; /// номер выбранного клиента
                double sum = Convert.ToDouble(textbox_Money.Text); /// введенная сумма
                int month = Convert.ToInt32(textbox_Month.Text); /// введенный срок

                if (sum <= 0) throw new ArgumentException(); /// пробрасываем исключение, если введена отрицательная сумма

                if (month > 2 && month < 25) /// проверка на допустимый срок вклада
                {
                    if (bank.clients[index].Cash >= sum) /// проверка на корректность суммы
                    {
                        double deposit = bank.OpenDeposit(index, sum, month); /// открытие вклада (возврат, того сколько сколько клиент получит по истечению срока)

                        textbox_Sum.Text = $"Вы получите {deposit.ToString("#.###")} $";
                    }
                    else MessageBox.Show("Недостаточно средств на счете");
                }
                else MessageBox.Show("Срок вклада от 3 до 24 месяцев");

                listViewClients.Items.Refresh(); /// обновление listview
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Некорректная сумма");
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно");
            }

        }

        /// <summary>
        /// Событие при нажатии "Открыть вклад (с кап.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OpenDepositCap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = listViewClients.SelectedIndex; /// номер выбранного клиента
                double sum = Convert.ToDouble(textbox_Money.Text); /// введенная сумм
                int month = Convert.ToInt32(textbox_Month.Text); /// введенный срок

                if (sum <= 0) throw new ArgumentException(); /// пробрасываем исключение, если введена отрицательная сумма

                if (month > 2 && month < 25)  /// проверка на допустимый срок вклада
                {
                    if (bank.clients[index].Cash >= sum) /// проверка на корректность суммы
                    {
                        double deposit = bank.OpenDepositCap(index, sum, month); /// открытие вклада (возврат, того сколько сколько клиент получит по истечению срока)

                        textbox_Sum.Text = $"Вы получите {deposit.ToString("#.###")} $";
                    }
                    else MessageBox.Show("Недостаточно средств на счете");
                }
                else MessageBox.Show("Срок вклада от 3 до 24 месяцев");

                listViewClients.Items.Refresh(); /// обновление listview
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Некорректная сумма");
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно");
            }
        }

        /// <summary>
        /// Событие при нажатии "Выдать кредит"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Credit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = listViewClients.SelectedIndex; /// номер выбранного клиента
                double sum = Convert.ToDouble(textbox_Money.Text); /// введенная сумм
                int month = Convert.ToInt32(textbox_Month.Text); /// введенный срок

                if (sum <= 0) throw new ArgumentException(); /// пробрасываем исключение, если введена отрицательная сумма

                if (month > 11 && month < 85) /// проверка на допустимый срок кредита
                {
                    double credit = bank.Credit(index, sum, month); /// выдача кредита
                    textbox_Sum.Text = $"Ваш ежемесячный платеж {credit.ToString("#.###")} $";  /// отображение информации об ежемесячной выплате
                }
                else MessageBox.Show("Срок кредита от 1 года до 7 лет");

                listViewClients.Items.Refresh(); /// обновление listview
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Некорректная сумма");
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно");
            }

        }

        /// <summary>
        /// Обработчик событий уведомлений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleNotify(object sender, MoneyEventArgs e)
        {
            var client = sender as Client;
            e.MessageInfo += $"\nВремя операции: {e.Time}";
            e.MessageInfo += $"\nТекущий баланс: {client.Cash} $.";
            MessageBox.Show(e.MessageInfo, client.Firstname); /// показываем кому адресовано уведомление
        }
    }
}
