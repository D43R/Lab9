using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab9
{

    class TimeArray
    {
        Time[] arr;
        int size;
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
        public TimeArray()
        {
            arr = null;
            size = 0;
        }
        public TimeArray(int s)
        {
            size = s;
            arr = new Time[size];
            for (int i = 0;i < size; i++)
            {
                arr[i] = new Time();
                Thread.Sleep(20);
                
            }
        }
        public TimeArray(int s, bool k)
        {
            size = s;
            arr = new Time[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(i + 1 + " объект");
                arr[i] = CreateObjectByHand();
            }
        }
        public Time this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
        public void Show()
        {
            foreach (Time a in arr)
            {
                a.Show();
            }
        }
        public Time Average()
        {
            
            int resSeconds = 0;
            foreach (Time a in arr)
            {
                a.ToSeconds();
                resSeconds += a.Seconds;
                a.Seconds = a.Seconds;
            }
            resSeconds /= arr.Length;
            Time res = new Time(resSeconds);
            return res;
        }
        public Time CreateObjectByHand()
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
    }
}
