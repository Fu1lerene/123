using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12_14
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client
    {
        public event EventHandler<MoneyEventArgs> Notify; /// событие (уведомление)

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Client()
        {

        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="lastname">Фамилия</param>
        /// <param name="status">Статус</param>
        public Client(string firstname, string lastname, string status)
        {
            Id = NextId();
            Firstname = firstname;
            Lastname = lastname;
            Status = status;
            Cash = rng.Next(1, 1000001);
        }

        /// <summary>
        /// Статический конструктор
        /// </summary>
        static Client()
        {
            staticId = 0;
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Статическое ID
        /// </summary>
        public static int staticId { get; set; }
        /// <summary>
        /// Случайное число
        /// </summary>
        protected static Random rng = new Random();
        /// <summary>
        /// ID клиента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public string Firstname { get; set; }
        /// <summary>
        /// фамилия клиента
        /// </summary>
        public string Lastname { get; set; }
        /// <summary>
        /// Кредитная история
        /// </summary>
        public int History { get; set; }
        /// <summary>
        /// Статус клиента
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Счет клиента
        /// </summary>
        public double Cash { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Статический метод возвращающий следующие Id
        /// </summary>
        /// <returns></returns>
        private static int NextId()
        {
            staticId++;
            return staticId;
        }

        /// <summary>
        /// Вывод информации о клиенте
        /// </summary>
        public void PrintinfoC()
        {
            Console.WriteLine($"{Id,5} {Firstname,10} {Lastname,15} {History,5}/10 {Status,15} {Cash,10} $");
        }

        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnNotify(MoneyEventArgs e)
        {
            Notify?.Invoke(this, e);
        }

        /// <summary>
        /// Пополнение счета переводом
        /// </summary>
        /// <param name="money">Сумма</param>
        public void PlusCash(double money)
        {
            Cash += money;
            OnNotify(new MoneyEventArgs(money, $"На ваш счет было зачислено {money} $."));
        }

        /// <summary>
        /// Снятие наличных переводом
        /// </summary>
        /// <param name="money">Сумма</param>
        public void MinusCash(double money)
        {
            Cash -= money;
            OnNotify(new MoneyEventArgs(money, $"С вашего счета было снято {money} $."));
        }

        /// <summary>
        /// Увелечение суммы на счете, взятием кредита
        /// </summary>
        /// <param name="money">Сумма</param>
        /// <param name="month">Срок</param>
        /// <param name="payment">Ежемесячный платеж</param>
        public void GetCredit(double money, int month, double payment)
        {
            Cash += money;
            OnNotify(new MoneyEventArgs(money, $"Вам одобрен кредит на сумму {money} на срок в {month} мес. Ваш ежемесячный платеж составляет {payment.ToString("#.###")} $."));
        }

        /// <summary>
        /// Уменьшение суммы на счете, открытием вклада
        /// </summary>
        /// <param name="money">Сумма</param>
        /// <param name="month">Срок</param>
        /// <param name="profit">Прибыль + вложенная сумма</param>
        public void GetDeposit(double money, double month, double profit)
        {
            Cash -= money;  /// вычитаем введенную сумму, словно клиент согласился вложить деньги
            OnNotify(new MoneyEventArgs(money, $"Вклад успешно открыт на срок {month} мес. Внесенная сумма: {money} $. Вы получите: {profit.ToString("#.###")} $."));

        }

        #endregion

        #region Операторы

        public static double operator +(Client c1, Client c2)
        {
            return c1.Cash + c2.Cash;
        }
        public static double operator -(Client c1, Client c2)
        {
            return c1.Cash - c2.Cash;
        }
        public static bool operator >(Client c1, Client c2)
        {
            return c1.Cash > c2.Cash;
        }
        public static bool operator <(Client c1, Client c2)
        {
            return c1.Cash < c2.Cash;
        }

        #endregion

    }

    /// <summary>
    /// Юридическое лицо
    /// </summary>
    public class Entity : Client
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Entity()
        {

        }

        /// <summary>
        /// Создание клиента (юридическое лицо)
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="lastname">Фамилия</param>
        public Entity(string firstname, string lastname)
             : base(firstname, lastname, "Юр лицо")
        {
            History = rng.Next(1, 8) + 1; /// случайная кредтная история от 2 до 8 из 10
        }
    }

    /// <summary>
    /// Физическое лицо
    /// </summary>
    public class Individual : Client
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Individual()
        {

        }

        /// <summary>
        /// Создание клиента (физическое лицо)
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="lastname">Фамилия</param>
        public Individual(string firstname, string lastname)
            : base(firstname, lastname, "Физ лицо")
        {
            History = rng.Next(1, 8); /// случайная кредтная история от 1 до 7 из 10
        }
    }

    /// <summary>
    /// VIP клиент
    /// </summary>
    public class VIP : Client
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public VIP()
        {

        }

        /// <summary>
        /// Создание VIP клиента
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="lastname">Фамилия</param>
        public VIP(string firstname, string lastname)
            : base(firstname, lastname, "VIP клиент")
        {
            History = rng.Next(1, 8) + 3; /// случайная кредтная история от 3 до 10 из 10
        }
    }

}
