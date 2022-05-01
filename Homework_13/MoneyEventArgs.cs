using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    /// <summary>
    /// Информация о денежной операции
    /// </summary>
    public class MoneyEventArgs : EventArgs
    {
        /// <summary>
        /// Время операции
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Сумма операции
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Информационное сообщение
        /// </summary>
        public string MessageInfo { get; set; }

        /// <summary>
        /// Создание денежной операции
        /// </summary>
        /// <param name="value">Сумма</param>
        /// <param name="msg">Сообщение</param>
        public MoneyEventArgs(double value, string msg)
        {
            Value = value;
            Time = DateTime.Now;
            MessageInfo = msg;
        }
    }
}
