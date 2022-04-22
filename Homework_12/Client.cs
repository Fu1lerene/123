using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client
    {
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
            Cash = rng.Next(1,1000001);
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
            Console.WriteLine($"{Id,5} {Firstname,10} {Lastname,15} {History,5}/10 {Status, 15} {Cash, 10}$");
        }

        #endregion
    }
}
