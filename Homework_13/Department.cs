using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework_13
{ 
    /// <summary>
    /// Отдел
    /// </summary>
    /// <typeparam name="T">Шаблон клиента</typeparam>
    public class Department<T>
        where T : Client, new()
    {
        public Department()
        {

        }

        /// <summary>
        /// Создание отдела
        /// </summary>
        /// <param name="name">Название отдела</param>
        public Department(string name)
        {
            Name = name;
            NumberClients = 0;
            Clients = new List<Client>();

            /// В зависимости от типо созданного отдела, создаются клиенты такого же типа
            T t = new T();
            if (t is Individual)
                CreateClientsInd();
            else if (t is VIP)
                CreateClientsVIP();
            else CreateClientsEnt();

        }

        #region Свойства

        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество клиентов в отделе
        /// </summary>
        public int NumberClients { get; set; }
        /// <summary>
        /// Спсиок клиентов
        /// </summary>
        public List<Client> Clients { get; set; }
        /// <summary>
        /// Случайное число
        /// </summary>
        private Random rng = new Random();

        #endregion

        #region Методы

        /// <summary>
        /// Вывод информации об отделе
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"{Name,20} {NumberClients,10}");
        }

        /// <summary>
        /// Создание клиентов (физические лица)
        /// </summary>
        public void CreateClientsInd()
        {
            int tem = rng.Next(10, 31);
            for (int i = 0; i < tem; ++i)
            {
                Clients.Add(new Individual($"Имя_{Client.staticId + 1}", $"Фамилия_{Client.staticId + 1}"));
            }
            NumberClients = Clients.Count();
        }

        /// <summary>
        /// Создание VIP клиентов
        /// </summary>
        public void CreateClientsVIP()
        {
            Thread.Sleep(15);
            int tem = rng.Next(10, 31);
            for (int i = 0; i < tem; ++i)
            {
                Clients.Add(new VIP($"Имя_{Client.staticId + 1}", $"Фамилия_{Client.staticId + 1}"));
            }
            NumberClients = Clients.Count();
        }

        /// <summary>
        /// Создание клиентов (юридические лица)
        /// </summary>
        public void CreateClientsEnt()
        {
            Thread.Sleep(15);
            int tem = rng.Next(10, 31);
            for (int i = 0; i < tem; ++i)
            {
                Clients.Add(new Entity($"Имя_{Client.staticId + 1}", $"Фамилия_{Client.staticId + 1}"));
            }
            NumberClients = Clients.Count();
        }

        #endregion
    }
}
