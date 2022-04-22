using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12
{
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
            History = rng.Next(1, 8)+3; /// случайная кредтная история от 3 до 10 из 10
        }
    }
}
