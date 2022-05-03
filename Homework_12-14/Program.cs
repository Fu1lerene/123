using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Homework_12_14
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Need more gold"); /// создаем прототип банковоской системы со случайными данными
            bank.PrintClients(); /// отображаем список клиентов

            /// Проверка функционала банка (перевод денежных средств, взятие кредита, открытие вклада с капитализацией и без)
            /// Также проверка системы оповещений для клиентов производящие операции
            /// и автоматическое ведение журнала обо всех операциях банка в файле log.txt
            bank.TransferMoney(0, 8, 5000);
            bank.Credit(5, 75000, 24);
            bank.OpenDeposit(16, 50000, 4);
            bank.OpenDepositCap(35, 82000, 7);

            /// Создаем двух новых клиентов
            Client newClient = new Entity("Тест", "Тестович");
            Client newClient2 = new VIP("Александр", "Ковалев");

            /// Проверка расширений
            newClient.AddToList(bank.clients);
            newClient2.AddToList(bank.clients);
            newClient.Print();
            100000000.0.GiveMoneyTo("Тест", "Тестович", bank);
            500000.0.TakeMoneyFrom("Александр", "Ковалев", bank);

            /// Проверка перегрузки операторов
            double res;
            if (newClient > newClient2)
                res = newClient2 + newClient;
            else res = newClient2 - newClient;
            Console.WriteLine($"Результат сложение или вычитания двух клиентов: {res} $");

            /// Сериализация
            string jsonString = JsonSerializer.Serialize(bank);
            File.WriteAllText("Need more gold.json", jsonString);

            /// Десериализация
            //string json = File.ReadAllText("Need more gold.json");
            //Bank bank = JsonSerializer.Deserialize<Bank>(json);

        }
    }
}
