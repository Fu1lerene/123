using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12
{
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
            History = rng.Next(1, 8)+1; /// случайная кредтная история от 2 до 8 из 10
        }
    }
}
