using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_12_14
{
    /// <summary>
    /// Банковская система
    /// </summary>
    public class Bank
    {
        public Bank()
        {
            DeptInd = new Department<Individual>("Отдел по работе с физическими лицами");
            DeptVIP = new Department<VIP>("Отдел по работе с VIP клиентами");
            DeptEnt = new Department<Entity>("Отдел по работе с юридическими лицами");
            clients = new List<Client>();

            foreach (var item in DeptInd.Clients)
                clients.Add(item);
            foreach (var item in DeptVIP.Clients)
                clients.Add(item);
            foreach (var item in DeptEnt.Clients)
                clients.Add(item);

            foreach (var item in clients)
                item.Notify += HandleNotify;
        }

        /// <summary>
        /// Создание банковской системы
        /// </summary>
        /// <param name="name">Название банка</param>
        public Bank(string name = "No name")
        {
            Name = name;
            DeptInd = new Department<Individual>("Отдел по работе с физическими лицами");
            DeptVIP = new Department<VIP>("Отдел по работе с VIP клиентами");
            DeptEnt = new Department<Entity>("Отдел по работе с юридическими лицами");
            clients = new List<Client>();

            /// Заполняем список клиентов из всех отделов
            foreach (var item in DeptInd.Clients)
                clients.Add(item);
            foreach (var item in DeptVIP.Clients)
                clients.Add(item);
            foreach (var item in DeptEnt.Clients)
                clients.Add(item);

            foreach (var item in clients) /// оформляем подписку всех клиентов на рассылку уведомлений
                item.Notify += HandleNotify;
        }

        #region Свойства

        /// <summary>
        /// Название банка
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отдел по работе с физическими лицами
        /// </summary>
        public Department<Individual> DeptInd { get; set; }
        /// <summary>
        /// Отдел по работе с VIP клиентами
        /// </summary>
        public Department<VIP> DeptVIP { get; set; }
        /// <summary>
        /// Отдел по работе с юридическими лицами
        /// </summary>
        public Department<Entity> DeptEnt { get; set; }
        /// <summary>
        /// Список всех клиентов
        /// </summary>
        public List<Client> clients { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Вывод всех клиентов в консоль
        /// </summary>
        public void PrintClients()
        {
            foreach (var item in clients)
                item.PrintinfoC();
        }

        /// <summary>
        /// Метод первода денежных средств между клиентами
        /// </summary>
        /// <param name="index1">ID клиента отправителя</param>
        /// <param name="index2">ID клиента получателя</param>
        /// <param name="money">Размер перевода денежных средств</param>
        public void TransferMoney(int index1, int index2, double money)
        {
            if (clients[index1].Cash - money >= 0)
            {
                clients[index1].MinusCash(money);
                clients[index2].PlusCash(money);
            }
            else Console.WriteLine("Недостаточно средств");
        }

        /// <summary>
        /// Открытие вклада с капитализацией
        /// </summary>
        /// <param name="index">ID клиента, который открывает вклад</param>
        /// <param name="sum">Сумма, которую клиент желает положить</param>
        /// <param name="month">Срок вклада в месяцах</param>
        public void OpenDepositCap(int index, double sum, int month)
        {
            double profit = 0;
            if (month > 2 && month < 25) /// срок от 3 до 24 месяцев
            {
                if (clients[index].Cash >= sum)
                {
                    if (clients[index].Status == "Физ лицо") /// если клиент физическое лицо
                    {
                        for (int i = 0; i < month; i++)
                            profit = sum + sum * (0.12 + clients[index].History / 100.0) / 12.0; /// ставка 12 % + кредитная история от 0,01 до 0,07
                        clients[index].GetDeposit(sum, month, profit);
                    }

                    else if (clients[index].Status == "VIP клиент") /// если VIP клиент
                    {
                        for (int i = 0; i < month; i++)
                            profit = sum + sum * (0.15 + clients[index].History / 100.0) / 12.0; /// ставка 15 % + кредитная история от 0,04 до 0,1
                        clients[index].GetDeposit(sum, month, profit);
                    }

                    else if (clients[index].Status == "Юр лицо") /// если клиент юридическое лицо
                    {
                        for (int i = 0; i < month; i++)
                            profit = sum + sum * (0.08 + clients[index].History / 100.0) / 12.0; /// ставка 8 % + кредитная история от 0,02 до 0,08
                        clients[index].GetDeposit(sum, month, profit);
                    }
                }
                else Console.WriteLine("Недостаточно средств");
            }
            else Console.WriteLine("Выберите другой срок (3 - 24 мес.)");
        }

        /// <summary>
        /// Открытие вклада без капитализации
        /// </summary>
        /// <param name="index">ID клиента, который открывает вклад</param>
        /// <param name="sum">Сумма, которую клиент желает положить</param>
        /// <param name="month">Срок вклада в месяцах</param>
        public void OpenDeposit(int index, double sum, double month)
        {
            if (month > 2 && month < 25) /// срок от 3 до 24 месяцев
            {
                if (clients[index].Cash >= sum)
                {
                    if (clients[index].Status == "Физ лицо") /// если клиент физическое лицо
                    {
                        double profit = sum + sum * (0.12 + clients[index].History / 100.0) / (12.0 / month); /// ставка 12 % + кредитная история от 0,01 до 0,07
                        clients[index].GetDeposit(sum, month, profit);
                    }

                    else if (clients[index].Status == "VIP клиент") /// если VIP клиент
                    {
                        double profit = sum + sum * (0.15 + clients[index].History / 100.0) / (12.0 / month); /// ставка 15 % + кредитная история от 0,04 до 0,1
                        clients[index].GetDeposit(sum, month, profit);
                    }

                    else if (clients[index].Status == "Юр лицо") /// если клиент юридическое лицо
                    {
                        double profit = sum + sum * (0.08 + clients[index].History / 100.0) / (12.0 / month); /// ставка 8 % + кредитная история от 0,02 до 0,08
                        clients[index].GetDeposit(sum, month, profit);
                    }
                }
                else Console.WriteLine("Недостаточно средств");
            }
            else Console.WriteLine("Выберите другой срок (3 - 24 мес.)");
        }

        /// <summary>
        /// Выдача кредита с аннуитетным порядком погашения
        /// </summary>
        /// <param name="index">ID клиента, которому выдается кредит</param>
        /// <param name="sum">Сумма кредита</param>
        /// <param name="month">Срок кредита в месяцах</param>
        public void Credit(int index, double sum, int month)
        {
            double dp = 0; /// Коэффициент аннуитета

            if (month > 11 && month < 85) /// срок от 1 года до 7 лет
            {
                if (clients[index].Status == "Физ лицо") /// если клиент физическое лицо
                {
                    double p = Math.Pow(1.12 - clients[index].History / 100.0, 1.0 / 12.0) - 1; /// процентная ставка за один период
                    for (int i = 0; i < month; ++i)
                        dp = p * Math.Pow(1 + p, month) / (Math.Pow(1 + p, month) - 1); /// 12 % - кредитная история от 0,01 до 0,07
                    clients[index].GetCredit(sum, month, dp * sum);
                }

                else if (clients[index].Status == "VIP клиент") /// если VIP клиент
                {
                    double p = Math.Pow(1.15 - clients[index].History / 100.0, 1.0 / 12.0) - 1; /// процентная ставка за один период
                    for (int i = 0; i < month; ++i)
                        dp = p * Math.Pow(1 + p, month) / (Math.Pow(1 + p, month) - 1); /// 15 % - кредитная история от 0,04 до 0,1
                    clients[index].GetCredit(sum, month, dp * sum);
                }

                else if (clients[index].Status == "Юр лицо")  /// если клиент юридическое лицо
                {
                    double p = Math.Pow(1.08 - clients[index].History / 100.0, 1.0 / 12.0) - 1; /// процентная ставка за один период
                    for (int i = 0; i < month; ++i)
                        dp = p * Math.Pow(1 + p, month) / (Math.Pow(1 + p, month) - 1); /// 8 % - кредитная история от 0,02 до 0,08
                    clients[index].GetCredit(sum, month, dp * sum);
                }
            }
            else Console.WriteLine("Выберите другой срок (1 - 7 лет)");
        }

        /// <summary>
        /// Обработчик событий уведомлений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleNotify(object sender, MoneyEventArgs e)
        {
            var client = sender as Client;
            e.MessageInfo += $"\n\tВремя операции: {e.Time}";
            e.MessageInfo += $"\n\tТекущий баланс: {client.Cash} $.";
            Console.WriteLine($"{client.Firstname} --> {e.MessageInfo}"); /// показываем кому адресовано уведомление
            Log(client, e);
        }

        /// <summary>
        /// Запись в журнал всех данных о совершенных операциях клиентами
        /// </summary>
        /// <param name="client"></param>
        /// <param name="e"></param>
        private void Log(Client client, MoneyEventArgs e)
        {
            File.AppendAllText("log.txt", $"{client.Firstname} --> " + e.MessageInfo + "\n");
        }

        #endregion
    }
}
