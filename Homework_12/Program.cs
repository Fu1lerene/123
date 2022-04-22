using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Homework_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Need more gold"); /// создание банка со случайным количеством клиентов

            /// Сериализация
            //string jsonString = JsonSerializer.Serialize(bank);
            //File.WriteAllText("Need more gold.json", jsonString);

            /// Десериализация
            //string json = File.ReadAllText("Need more gold.json");
            //Bank bank = JsonSerializer.Deserialize<Bank>(json);

            /// Демонстрация всех реализованных методов представлена в проекте Homework_12_WPF
        }
    }
}
