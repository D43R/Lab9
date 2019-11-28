using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Time
    {
        public static int ObjectsCount = 0;
        Random rand = new Random();
        private int hours, minutes, seconds;
        public Time()
        {
            hours = rand.Next(0, 23);
            minutes = rand.Next(0, 59);
            seconds = rand.Next(0, 59);
            ObjectsCount++;
        } // рандом конструктор
        public Time(int s)
        {
            if (s < 0) s = 0; // проверка на отрицательное значение;
            Seconds = s;
            ObjectsCount++; // считаем созданный объект
        } // с одним парам.
        public Time(int m, int s)
        {
            if (m < 0) m = 0; // проверка на отрицательные числа
            if (s < 0) s = 0;
            Minutes = m;
            Seconds = s;
            ObjectsCount++;
        } // с двумя парам.
        public Time(int h,int m,int s)
        {
            if (m < 0) m = 0;
            if (s < 0) s = 0;
            if (h < 0) h = 0;
            Hours = h;
            Minutes = m;
            Seconds = s;
                ObjectsCount++;
        }
        public int Hours
        {
            get { return this.hours; }
            set
            {
                if (value < 0) this.hours = 0;
                else this.hours = value;
            }
        }
        public int Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value < 0 && this.hours > 0)
                {
                    this.hours--;
                    this.minutes = 60 + value;
                }
                else if (value < 0 && this.hours == 0)
                {
                    this.minutes = 0;
                    this.seconds = 0;
                }
                else
                {
                    while (value >= 60)
                    {
                        this.hours++;
                        value -= 60;
                    }
                    this.minutes = value;
                }
            }
        }
        public int Seconds
        {
            get { return this.seconds; }
            set
            {
                if (value < 0 && this.minutes > 0)
                {
                    this.minutes--;
                    this.seconds = this.seconds +60 + value;
                }
                else if (value < 0 && this.minutes == 0)
                {
                    this.seconds = 0;
                }
                else
                {
                    while (value >= 60)
                    {
                        this.minutes++;
                        value = value - 60;
                    }
                    while (this.Minutes >= 60)
                    {
                        this.hours++;
                        this.Minutes -= 60;
                    }
                    this.seconds = value;
                }
            }
        }
        public void Show()
        {
            Console.WriteLine(this.hours.ToString("00.") + ":" + this.minutes.ToString("00.") + ":" + this.seconds.ToString("00.") + "\n\n");
        }
        public Time AddSeconds(int b)
        {
            this.Seconds += b;
            return this;
        }
        public static Time StaticAddSeconds(Time a, int b)
        {
            a.Seconds += b;
            return a;
        }
        public static Time operator ++(Time a)
        {
            a.Minutes++;
            return a;
        }
        public static Time operator --(Time a)
        {
            if (a.minutes != 0)
            {
                a.Minutes--;
                return a;
            }
            else if (a.hours != 0)
            {
                a.hours--;
                a.Minutes = 59;
                return a;
            }
            else
            {
                Console.WriteLine("Нельзя вычесть");
                return a;
            }
        }
        public static explicit operator int(Time a)
        {
            return a.minutes;
        }
        public static implicit operator bool(Time a)
        {
            if (a.minutes != 0 && a.seconds != 0) return true;
            else return false;
        }
        public static Time operator + (Time a, int b)
        {
            a.Minutes += b;
            return a;
        }
        public static Time operator -(Time a, int b)
        {
            a.Minutes -= b;
            return a;
        }
        public void ToSeconds()
        {
            while (this.hours > 0)
            {
                this.minutes += 60;
                this.hours--;
            }
            while (this.minutes > 0)
            {
                this.minutes--;
                this.seconds += 60;
            }
        }
    }
}
