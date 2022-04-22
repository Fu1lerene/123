using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12
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
            if (clients[index1].Cash - money >= 0) /// проверка на возможность перевода по балансу
            {
                clients[index1].Cash -= money; /// вычитаем у отправителя
                clients[index2].Cash += money; /// прибавляем получателю
            }
            else Console.WriteLine("Недостаточно средств");
        }

        /// <summary>
        /// Открытие вклада с капитализацией
        /// </summary>
        /// <param name="index">ID клиента, который открывает вклад</param>
        /// <param name="sum">Сумма, которую клиент желает положить</param>
        /// <param name="month">Срок вклада в месяцах</param>
        public double OpenDepositCap(int index, double sum, int month)
        {
            if (month > 2 && month < 25) /// срок от 3 до 24 месяцев
            {
                if (clients[index - 1].Status == "Физ лицо") /// если клиент физическое лицо
                    for (int i = 0; i < month; i++)
                        sum += sum * (0.12 + clients[index - 1].History / 100.0) / 12; /// ставка 12 % + кредитная история от 0,01 до 0,07

                else if (clients[index - 1].Status == "VIP клиент") /// если VIP клиент
                    for (int i = 0; i < month; i++)
                        sum += sum * (0.15 + clients[index - 1].History / 100.0) / 12; /// ставка 15 % + кредитная история от 0,04 до 0,1

                else if (clients[index - 1].Status == "Юр лицо") /// если клиент юридическое лицо
                    for (int i = 0; i < month; i++)
                        sum += sum * (0.08 + clients[index - 1].History / 100.0) / 12; /// ставка 8 % + кредитная история от 0,02 до 0,08
            }
            else Console.WriteLine("Выберите другой срок");

            if (clients[index].Cash > sum)
                clients[index].Cash -= sum; /// вычитаем введенную сумму, словно клиент согласился вложить деньги
            else Console.WriteLine("Недостаточно средств");

            /*Console.WriteLine(sum);*/ /// вывод суммы, которую получит клиент по истечению заданного срока
            return sum;
        }

        /// <summary>
        /// Открытие вклада без капитализации
        /// </summary>
        /// <param name="index">ID клиента, который открывает вклад</param>
        /// <param name="sum">Сумма, которую клиент желает положить</param>
        /// <param name="month">Срок вклада в месяцах</param>
        public double OpenDeposit(int index, double sum, int month)
        {
            if (month > 2 && month < 25) /// срок от 3 до 24 месяцев
            {
                if (clients[index].Status == "Физ лицо") /// если клиент физическое лицо
                    sum += sum * (0.12 + clients[index].History / 100.0) / (12 / month); /// ставка 12 % + кредитная история от 0,01 до 0,07

                else if (clients[index].Status == "VIP клиент") /// если VIP клиент
                    sum += sum * (0.15 + clients[index].History / 100.0) / (12 / month); /// ставка 15 % + кредитная история от 0,04 до 0,1

                else if (clients[index].Status == "Юр лицо") /// если клиент юридическое лицо
                    sum += sum * (0.08 + clients[index].History / 100.0) / (12 / month); /// ставка 8 % + кредитная история от 0,02 до 0,08
            }
            else Console.WriteLine("Выберите другой срок");

            if (clients[index].Cash > sum)
                clients[index].Cash -= sum; /// вычитаем введенную сумму, словно клиент согласился вложить деньги
            else Console.WriteLine("Недостаточно средств");

            /*Console.WriteLine(sum);*/ /// вывод суммы, которую получит клиент по истечению заданного срока
            return sum;
        }

        /// <summary>
        /// Выдача кредита с аннуитетным порядком погашения
        /// </summary>
        /// <param name="index">ID клиента, которому выдается кредит</param>
        /// <param name="sum">Сумма кредита</param>
        /// <param name="month">Срок кредита в месяцах</param>
        public double Credit(int index, double sum, int month)
        {
            double dp = 0; /// Коэффициент аннуитета

            if (month > 11 && month < 85) /// срок от 1 года до 7 лет
            {
                if (clients[index].Status == "Физ лицо") /// если клиент физическое лицо
                {
                    double p = Math.Pow(1.12 -clients[index].History / 100.0, 1.0 / 12.0) - 1; /// процентная ставка за один период
                    for (int i = 0; i < month; ++i)
                        dp = p * Math.Pow(1 + p, month) / (Math.Pow(1 + p, month) - 1); /// 12 % - кредитная история от 0,01 до 0,07
                }

                else if (clients[index].Status == "VIP клиент") /// если VIP клиент
                {
                    double p = Math.Pow(1.15 - clients[index].History / 100.0, 1.0 / 12.0) - 1; /// процентная ставка за один период
                    for (int i = 0; i < month; ++i)
                        dp = p * Math.Pow(1 + p, month) / (Math.Pow(1 + p, month) - 1); /// 15 % - кредитная история от 0,04 до 0,1
                }

                else if (clients[index].Status == "Юр лицо")  /// если клиент юридическое лицо
                {
                    double p = Math.Pow(1.08 - clients[index].History / 100.0, 1.0 / 12.0) - 1; /// процентная ставка за один период
                    for (int i = 0; i < month; ++i)
                        dp = p * Math.Pow(1 + p, month) / (Math.Pow(1 + p, month) - 1); /// 8 % - кредитная история от 0,02 до 0,08
                }
            }
            else Console.WriteLine("Выберите другой срок");

            clients[index].Cash += sum; /// прибавляем выданный кредит на счет клиенту
            /*Console.WriteLine(dp*sum);*/ /// вывод суммы, которую клиент обязан платить ежемесячно
            return dp * sum;
        }

        #endregion
    }
}
