using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12
{
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
}
