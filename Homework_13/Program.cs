using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    internal class Program
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
        }
    }
}
