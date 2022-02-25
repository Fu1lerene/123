# Домашние задания из курса Skillbox Профессия С# разработчик 
## 1 Домашнее задание

* Задание 1.Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников

* Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам которых в отделе болжно остаться не более 30 работников

* Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников чья зарплата превышает 30000руб

## 2 Домашнее задание

Заказчик просит написать программу «Записная книжка».

В данной программе, должна быть возможность изменения значений нескольких переменных для того, чтобы персонифецироватьвывод данных, под конкретного пользователя.

Для этого нужно: 
1. Создать несколько переменных разных типов, в которых могут храниться данные
- имя;
- возраст;
- рост;
- баллы по трем предметам: история, математика, русский язык;

2. Реализовать в системе автоматический подсчёт среднего балла по трем предметам, указанным в пункте 1.

3. Реализовать возможность печатки информации на консоли при помощи 
- обычного вывода;
- форматированного вывода;
- использования интерполяции строк;

4. Весь код должен быть откомментирован с использованием обычных и хml-комментариев

5. В качестве бонусной части, заказчик просит реализовать возможность вывода данных в центре консоли.
               
## 3 Домашнее задание

Предлагается решить следующую задачу.
            
- Написать игру, в которою могут играть два игрока.
- При старте, игрокам предлагается ввести свои никнеймы.
- Никнеймы хранятся до конца игры.
- Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
- Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
- Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
- введенное число вычитается из gameNumber
- Новое значение gameNumber показывается игрокам на экране.
- Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
- Игра поздравляет победителя, предлагая сыграть реванш
             
** Бонус:

Подумать над возможностью реализации разных уровней сложности. В качестве уровней сложности может выступать настраиваемое, в начале игры, значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

*** Сложный бонус:

Подумать над возможностью реализации однопользовательской игры, т е игрок должен играть с компьютером
            
## 4 Домашнее задание

  * Задание 1
  
          Заказчик просит вас написать приложение по учёту финансов и продемонстрировать его работу.
          Суть задачи в следующем: 
          - Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
          - За год получены два массива – расходов и поступлений.
          - Определить прибыли по месяцам
          - Количество месяцев с положительной прибылью.
          - Добавить возможность вывода трех худших показателей по месяцам с худшей прибылью, если в некоторых месяцах
            худшая прибыль совпала - вывести их все.
          - Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

          Пример
                   
          Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
              1              100 000             80 000                 20 000
              2              120 000             90 000                 30 000
              3               80 000             70 000                 10 000
              4               70 000             70 000                      0
              5              100 000             80 000                 20 000
              6              200 000            120 000                 80 000
              7              130 000            140 000                -10 000
              8              150 000             65 000                 85 000
              9              190 000             90 000                100 000
             10              110 000             70 000                 40 000
             11              150 000            120 000                 30 000
             12              100 000             80 000                 20 000
             
          Худшая прибыль в месяцах: 7, 4, 1, 5, 12
          Месяцев с положительной прибылью: 10

  * Задание 2*
            
          Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
          При N = 9. Треугольник выглядит следующим образом:
                                          1
                                      1       1
                                  1       2       1
                              1       3       3       1
                          1       4       6       4       1
                      1       5      10      10       5       1
                  1       6      15      20      15       6       1
              1       7      21      35      35       21      7       1                                                            
                                                                         
          Простое решение:                                                             
          1
          1       1
          1       2       1
          1       3       3       1
          1       4       6       4       1
          1       5      10      10       5       1
          1       6      15      20      15       6       1
          1       7      21      35      35       21      7       1
             
            Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля

  * Задание 3.1
            
          Заказчику требуется приложение позволяющщее умножать математическую матрицу на число:
          - Добавить возможность ввода количество строк и столцов матрицы и число, на которое будет производиться умножение.
          - Матрицы заполняются автоматически. 
          - Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            
          Пример
            
                |  1  3  5  |   |  5  15  25  |
            5 х |  4  5  7  | = | 20  25  35  |
                |  5  3  1  |   | 25  15   5  |
           
           
  * Задание 3.2**
            
          Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы:
          - Добавить возможность ввода количество строк и столцов матрицы.
          - Матрицы заполняются автоматически
          - Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            
          Пример
            |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
                   
            |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
            
  * Задание 3.3***
            
          Заказчику требуется приложение позволяющщее перемножать математические матрицы
          - Добавить возможность ввода количество строк и столцов матрицы.
          - Матрицы заполняются автоматически
          - Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
             
            |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            
             
                            | 4 |   
            |  1  2  3  | х | 5 | = | 32 |
                            | 6 |  
           
## 5 Домашнее задание

 * Требуется написать несколько методов
            
          Задание 1
          Воспользовавшись решением задания 3 четвертого модуля
          1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
          1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
          1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
         
          Задание 2.
          1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
          2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
          Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
            
          Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
          1. Ответ: А
          2. ГГГГ, ДДДД
            
          Задание 3. Создать метод, принимающий текст. 
          Результатом работы метода должен быть новый текст, в котором
          удалены все кратные рядом стоящие символы, оставив по одному 
            
          Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
          Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день
             
          Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
          является заданная последовательность элементами арифметической или геометрической прогрессии
            
          Задание 5*
          Вычислить, используя рекурсию, функцию Аккермана:
          A(2, 5), A(1, 2)
          A(n, m) = m + 1, если n = 0,
                  = A(n - 1, 1), если n <> 0, m = 0,
                  = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
             
          Весь код должен быть откоммментирован

## 6 Домашнее задание

          Группа начинающих программистов решила поучаствовать в хакатоне с целью демонстрации своих навыков. 

          Немного подумав они вспомнили, что не так давно на занятиях по математике они проходили тему 
          "свойства делимости целых чисел". На этом занятии преподаватель показывал пример с использованием фактов делимости. 
            
          Пример заключался в следующем: 
          Написав на доске все числа от 1 до N, N = 50, преподаватель разделил числа на несколько групп 
          так, что если одно число делится на другое, то эти числа попадают в разные руппы. 
          В результате этого разбиения получилось M групп, для N = 50, M = 6
            
          N = 50
          Группы получились такими: 
             
          Группа 1: 1
          Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
          Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
          Группа 4: 8 12 18 20 27 28 30 42 44 45 50
          Группа 5: 16 24 36 40
          Группа 6: 32 48
             
          M = 6
             
          ===========
            
          N = 10
          Группы получились такими: 
             
          Группа 1: 1
          Группа 2: 2 7 9
          Группа 3: 3 4 10
          Группа 4: 5 6 8
            
          M = 4
            
          Участники хакатона решили эту задачу, добавив в неё следующие возможности:
          1. Программа считыват из файла (путь к которому можно указать) некоторое N, 
             для которого нужно подсчитать количество групп
             Программа работает с числами N не превосходящими 1 000 000 000
              
          2. В ней есть два режима работы:
             2.1. Первый - в консоли показывается только количество групп, т е значение M
             2.2. Второй - программа получает заполненные группы и записывает их в файл используя один из
                           вариантов работы с файлами
                      
          3. После выполения пунктов 2.1 или 2.2 в консоли отображается время, за которое был выдан результат 
             в секундах и миллисекундах
             
          4. После выполнения пунта 2.2 программа предлагает заархивировать данные и если пользователь соглашается -
             делает это.
             
          Попробуйте составить конкуренцию начинающим программистам и решить предложенную задачу
          (добавление новых возможностей не возбраняется)
            
          * При выполнении текущего задания, необходимо документировать код 
            Как пометками, так и xml документацией
            В обязательном порядке создать несколько собственных методов
              
              
