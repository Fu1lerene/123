using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Homework_12_14;

namespace Homework_12_14_WPF
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
            clients[index1].MinusCash(money);
            clients[index2].PlusCash(money);
        }

        /// <summary>
        /// Открытие вклада с капитализацией
        /// </summary>
        /// <param name="index">ID клиента, который открывает вклад</param>
        /// <param name="sum">Сумма, которую клиент желает положить</param>
        /// <param name="month">Срок вклада в месяцах</param>
        public double OpenDepositCap(int index, double sum, int month)
        {
            double profit = 0;
           
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

            return profit;
        }

        /// <summary>
        /// Открытие вклада без капитализации
        /// </summary>
        /// <param name="index">ID клиента, который открывает вклад</param>
        /// <param name="sum">Сумма, которую клиент желает положить</param>
        /// <param name="month">Срок вклада в месяцах</param>
        public double OpenDeposit(int index, double sum, double month)
        {
            double profit = 0;

            if (clients[index].Status == "Физ лицо") /// если клиент физическое лицо
            {
                profit = sum + sum * (0.12 + clients[index].History / 100.0) / (12.0 / month); /// ставка 12 % + кредитная история от 0,01 до 0,07
                clients[index].GetDeposit(sum, month, profit);
            }

            else if (clients[index].Status == "VIP клиент") /// если VIP клиент
            {
                profit = sum + sum * (0.15 + clients[index].History / 100.0) / (12.0 / month); /// ставка 15 % + кредитная история от 0,04 до 0,1
                clients[index].GetDeposit(sum, month, profit);
            }

            else if (clients[index].Status == "Юр лицо") /// если клиент юридическое лицо
            {
                profit = sum + sum * (0.08 + clients[index].History / 100.0) / (12.0 / month); /// ставка 8 % + кредитная история от 0,02 до 0,08
                clients[index].GetDeposit(sum, month, profit);
            }

            return profit;
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

            return dp * sum;
        }

        #endregion
    }
}
