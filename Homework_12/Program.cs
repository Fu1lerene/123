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
            Bank bank = new Bank("Need more gold");

            //bank.Credit(20, 1_000_000, 24);
            //bank.OpenDeposit(1, 500000, 6);

            string jsonString = JsonSerializer.Serialize(bank);
            File.WriteAllText("Need more gold.json", jsonString);

            //string json = File.ReadAllText("Need more gold.json");
            //Bank bank = JsonSerializer.Deserialize<Bank>(json);
            //bank.PrintClients();

            // Создать прототип банковской системы, позвляющей управлять клиентами и клиентскими счетами.
            // В информационной системе есть возможность перевода денежных средств между счетами пользователей
            // Открывать вклады, с капитализацией и без

            // * Продумать возможность выдачи кредитов
            // Продумать использование обобщений

            // Продемонстрировать работу созданной системы

            // Банк
            // ├── Отдел работы с обычными клиентами
            // ├── Отдел работы с VIP клиентами
            // └── Отдел работы с юридическими лицами

            // Дополнительно: клиентам с хорошей кредитной историей предлагать пониженую ставку по кредиту и 
            // повышенную ставку по вкладам
        }
    }
}
