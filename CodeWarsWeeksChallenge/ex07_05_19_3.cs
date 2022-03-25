using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsWeeksChallenge
{
    class ex07_05_19_3: Challenge
    {
        public string name { get { return _name; } }

        public string discription { get { return _discription; } }

        public ex07_05_19_3()
        {
            _name = "ex07_05_19_3";
            _discription = "Делители 42 являются : 1, 2, 3, 6, 7, 14, 21, 42. Эти делители в квадрате являются: 1, 4, 9, 36, 49, 196, 441, 1764. Сумма квадратов делителей равна 2500, что составляет 50 * 50, квадрат! Учитывая два целых числа m, n (1 <= m <= n), мы хотим найти все целые числа между m и n, сумма квадратов которых сама является квадратом. 42 - это такое число. Результатом будет массив массивов или кортежей(в C-массив пар) или строка, каждая подмножество которой имеет два элемента, сначала число, квадрат которого является квадратом, а затем сумма квадратов делителей";
        }

        override public bool Active()
        {
            Console.Clear();
            this.Main();

            return Reset();
        }

        override public bool Reset()
        {
            Console.WriteLine("Повторить программу? (y)/(n)");
            return (Console.Read() == 'y');
        }

        override protected void Main()
        {
            string _consoleStr = "";

            Console.WriteLine("Введите начало диапозона");
            if (Int32.TryParse(Console.ReadLine(), out int n))
            {
                if (Int32.TryParse(Console.ReadLine(), out int m))
                {
                    List<int[]> res = new List<int[]>();

                    List<int> dividers = FindDividers(m);
                    for (int i = n; i <= m; i++)
                    {
                        int[] consoleOut = SumDividers(FindDividers(i));

                        if (IsSqrt(consoleOut))
                            res.Add(consoleOut);
                    }

                    foreach (int[] someRes in res)
                    {
                        _consoleStr += $"[{someRes[0]}, {someRes[1]}], ";
                    }
                }
                else Console.WriteLine("это не число");
            }
            else Console.WriteLine("это не число");

            Console.WriteLine(_consoleStr);

        }

        private bool IsSqrt(int[] sumDividers)
        {
            double res = Math.Sqrt(sumDividers[1]);

            if (res == (int)res)
                return true;
            return false;
        }

        private int[] SumDividers(List<int> dividers)
        {
            int[] res = new int[2];
            if (dividers.Count == 0) Console.WriteLine("bad");
            res[0] = dividers.Last();
            res[1] = 0;

            foreach (int divider in dividers)
            {
                res[1] += divider * divider;
            }

            return res;
        }

        private List<int> FindDividers(int Num)
        {
            List<int> res = new List<int>();

            for (int i = 1; i <= Num; i++)
                if (Num % i == 0)
                    res.Add(i);

            return res;
        }



    }
}
