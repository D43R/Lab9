using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab9
{
    class Program
    {
        public static Time CreateObjectByHand()
        {
            int h, m, sec;
            Console.WriteLine("Введите кол-во часов:");
            h = Proverka(Console.ReadLine());
            Console.WriteLine("Введите кол-во минут:");
            m = Proverka(Console.ReadLine());
            Console.WriteLine("Введите кол-во секунд:");
            sec = Proverka(Console.ReadLine());
            Time res = new Time(h, m, sec);
            return res;
        }
        public static int Proverka(string text)
        {
            int check = -1;
            bool ok;
            ok = Int32.TryParse(text, out check);
            while (!ok || check < 0)
            {
                Console.WriteLine("Ошибка! Повторите ввод: ");
                text = Console.ReadLine();
                ok = Int32.TryParse(text, out check);
            }
            return check;
        }
        static void Interface()
        {
            int answer = 0;
            while (answer != 3)
            {
                Console.WriteLine("1 - работа с основным классом\n2 - работа с классом контейнером\n3 - выход");
                answer = Proverka(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        WorkWithMainClass();
                        break;
                    case 2:
                        WorkWithCollectionClass();
                        break;
                    case 3: break;
                }
            }
        }
        static void WorkWithMainClass()
        {
            
            int answer = 0;
            Time a = null;
            while (answer != 10)
            {
                Console.Clear();
                Console.WriteLine("1 - создать объект\n2 - показать объект\n3 - добавть n-ое кол-во секунд\n4 - добавить минуту" +
                    "\n5 - вычесть минуту\n6 - привести к типу int\n7 - привести к типу bool\n8 - добавить n-ое число минут" +
                    "\n9 - вычесть n-ое число минут\n10 - Назад");
                answer = Proverka(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        int ans1 = 0;
                        while (ans1 != 3)
                        {
                            Console.Clear();
                            Console.WriteLine("1 - создать случайный объект\n2 - задать параметры объекты\n3 - Назад");
                            ans1 = Proverka(Console.ReadLine());
                            switch (ans1)
                            {
                                case 1:
                                    a = new Time();
                                    Console.WriteLine("Объект успешно создан");
                                    Thread.Sleep(500);
                                    ans1 = 3;
                                    break;

                                case 2:
                                    a = CreateObjectByHand();
                                    Console.WriteLine("Объект успешно создан");
                                    Thread.Sleep(500);
                                    ans1 = 3;
                                    break;
                                case 3:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        if (CheckIfExists(a))
                        {
                            Console.Clear();
                            a.Show();
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (CheckIfExists(a))
                        {
                            Console.Clear();
                            AddSeconds(a);
                        }
                        break;
                    case 4:
                        if (CheckIfExists(a))
                        {
                            a++;
                            Console.WriteLine("Успешно выполнено");
                            Thread.Sleep(500);
                        }
                        break;
                    case 5:
                        if (CheckIfExists(a))
                        {
                            a--;
                            Console.WriteLine("Успешно выполнено");
                            Thread.Sleep(500);
                        }
                        break;
                    case 6:
                        if (CheckIfExists(a))
                        {
                            Console.WriteLine((int)a);
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        if (CheckIfExists(a))
                        {
                            Console.WriteLine((bool)a);
                            Console.ReadKey();
                        }
                        break;
                    case 8:
                        if (CheckIfExists(a))
                        {
                            AddMinutes(a, true);
                            Console.WriteLine("Успешно выполнено");
                            Thread.Sleep(500);
                        }
                        break;
                    case 9:
                        if (CheckIfExists(a))
                        {
                            AddMinutes(a, false);
                            Console.WriteLine("Успешно выполнено");
                            Thread.Sleep(500);
                        }
                        break;
                    case 10:
                        Console.Clear();
                        break;

                }
            }
        }
        static void WorkWithCollectionClass()
        {
            int answer = 0;
            TimeArray a = null;
            while (answer != 4)
            {
                Console.Clear();
                Console.WriteLine("1 - создать коллекцию\n2 - показать элементы коллекции\n3 - показать среднее арифметическое элементов коллекции\n4 - назад");
                answer = Proverka(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        int ans1 = 0;
                        while (ans1 != 3)
                        {
                            Console.Clear();
                            Console.WriteLine("1 - создать коллекцию с случайными объектами\n2 - задать элементы коллекции в ручную\n3 - Назад");
                            ans1 = Proverka(Console.ReadLine());
                            switch (ans1)
                            {
                                case 1:
                                    int size;
                                    Console.WriteLine("Введите размерность коллекции:");
                                    size = Proverka(Console.ReadLine());
                                    a = new TimeArray(size);
                                    Console.WriteLine("Объект успешно создан");
                                    Thread.Sleep(500);
                                    ans1 = 3;
                                    break;

                                case 2:
                                    Console.WriteLine("Введите размерность коллекции:");
                                    size = Proverka(Console.ReadLine());
                                    a = new TimeArray(size, true);
                                    Console.WriteLine("Объект успешно создан");
                                    Thread.Sleep(500);
                                    ans1 = 3;
                                    break;
                                case 3:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        if (CheckIfExists(a))
                        {
                            Console.Clear();
                            a.Show();
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (CheckIfExists(a))
                        {
                            Console.Clear();
                            a.Average().Show();
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        break;


                }
            }
        }
        static void Main(string[] args)
        {
            Interface();
        }
        static bool CheckIfExists(object b)
        {
            if (b == null)
            {
                Console.WriteLine("Объект не существует");
                Thread.Sleep(500);
                return false;
            }
            else return true;
        }
        static void AddSeconds(Time item)
        {
            int sec;
            Console.WriteLine("Введите кол-во секунд, которое вы хотите добавить:");
            sec = Proverka(Console.ReadLine());
            item.AddSeconds(sec);
        }
        static void AddMinutes(Time item, bool k)
        {
            int mins;
            Console.WriteLine("Введите кол-во минут, которое вы хотите добавить/вычесть:");
            mins = Proverka(Console.ReadLine());
            if (k)
            {
                item = item + mins;
            }
            else
            {
                item = item - mins;
            }
        }
    }
}
