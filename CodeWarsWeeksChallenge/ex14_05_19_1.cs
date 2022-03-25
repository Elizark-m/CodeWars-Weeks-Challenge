using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsWeeksChallenge
{
    class ex14_05_19_1: Challenge
    {
        public string name { get { return _name; } }

        public string discription { get { return _discription; } }

        public ex14_05_19_1()
        {
            _name = "ex07_05_19_4";
            _discription = "Напишите функцию, которая преобразует целое число в максимально возможное значение.\n superSize(123456) //654321\n superSize(105) // 510\n superSize(12) // 21";
        }

        public override bool Active()
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

        protected override void Main()
        {   
            Random rnd = new Random();
            // формирует случайное число
            string str = rnd.Next(100, 10000).ToString();
            Console.WriteLine(str);
            
            // формирование массива для цифр в числе str
            int[] start = new int[str.Length];
            // формирование массива для цифр результирующего числа
            int[] res = new int[str.Length];
            // перевод числа в массив
            for(int i = 0; i < str.Length; i++)
                Int32.TryParse(""+str[i],out start[i]);
            
            // сортировка полученного массива
            quicksort(start, 0, start.Length-1);
            
            // заполнение результирующего массива начальным в обратном порядке
            for (int i = 0; i < str.Length; i++)
                res[i] = start[str.Length-1 - i];

            foreach(int i in res)
            Console.Write(i);
            Console.WriteLine();

        }
        //
        int partition<T>(T[] m, int a, int b) where T : IComparable<T>
        {
            int i = a;
            // просматриваем с a по b
            for (int j = a; j <= b; j++)         
            {
                // если элемент m[j] не превосходит m[b],
                // меняем местами m[j] и m[a], m[a+1], m[a+2] и так далее...
                // то есть переносим элементы меньшие m[b] в начало,
                // а затем и сам m[b] «сверху»
                // таким образом последний обмен: m[b] и m[i], после чего i++
                if (m[j].CompareTo(m[b]) <= 0)  
                {
                    T t = m[i];                  
                    m[i] = m[j];                 
                    m[j] = t;                    
                    i++;                         
                }
            }
            // в индексе i хранится <новая позиция элемента m[b]> + 1
            return i - 1;                        
        }
        
        // a - начало подмножества, b - конец
        // для первого вызова: a = 0, b = <элементов в массиве> - 1
        void quicksort<T>(T[] m, int a, int b) where T : IComparable<T>
        {                                        
            if (a >= b) return;
            int c = partition(m, a, b);
            quicksort(m, a, c - 1);
            quicksort(m, c + 1, b);
        }

    }
}
