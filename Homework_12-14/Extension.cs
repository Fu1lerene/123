using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_12_14
{
    /// <summary>
    /// Методы расширения
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Вывод информации о клиенте в консоль
        /// </summary>
        /// <param name="item">Клиент</param>
        public static void Print(this Client item)
        {
            item.PrintinfoC();
        }

        /// <summary>
        /// Добавление клиента в общий список клиентов
        /// </summary>
        /// <param name="item">Клиент</param>
        /// <param name="collection">Список клиентов</param>
        public static void AddToList(this Client item, List<Client> collection)
        {
            collection.Add(item);
            item.Notify += HandleNotify;
        }

        /// <summary>
        /// Пополнение счета
        /// </summary>
        /// <param name="money">Сумма</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="bank">Банк</param>
        public static void GiveMoneyTo(this double money, string firstName, string lastName, Bank bank)
        {
            if (bank.clients.Exists(x => x.Firstname == firstName) && bank.clients.Exists(x => x.Lastname == lastName))
            {
                bank.clients.Find(x => x.Lastname == lastName).PlusCash(money);
            }
            else Console.WriteLine("Такого клиента не существует в нашем банке");
        }

        /// <summary>
        /// Снятие денег
        /// </summary>
        /// <param name="money">Сумма</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="bank">Банк</param>
        public static void TakeMoneyFrom(this double money, string firstName, string lastName, Bank bank)
        {
            if (bank.clients.Exists(x => x.Firstname == firstName) && bank.clients.Exists(x => x.Lastname == lastName))
            {
                bank.clients.Find(x => x.Lastname == lastName).MinusCash(money);
            }
            else Console.WriteLine("Такого клиента не существует в нашем банке");
        }

        /// <summary>
        /// Обработчик событий уведомлений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void HandleNotify(object sender, MoneyEventArgs e)
        {
            var client = sender as Client;
            e.MessageInfo += $"\n\tВремя операции: {e.Time}";
            e.MessageInfo += $"\n\tТекущий баланс: {client.Cash} $.";
            Console.WriteLine($"{client.Firstname} --> {e.MessageInfo}"); /// показываем кому адресовано уведомление
            File.AppendAllText("log.txt", $"{client.Firstname} --> " + e.MessageInfo + "\n");
        }
    }
}
