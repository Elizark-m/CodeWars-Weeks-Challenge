using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsWeeksChallenge
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Challenge> _tasks = new List<Challenge>();

            //
            _tasks.Add(new ex07_05_19_1());

            //
            _tasks.Add(new ex07_05_19_2());

            //
            _tasks.Add(new ex07_05_19_3());

            //
            _tasks.Add(new ex07_05_19_4());

            //
            _tasks.Add(new ex14_05_19_1());

            //
            bool flag = true;

            while (flag)
            {
                // отрисовка вариантов заданий
                for (int i = 0; i < _tasks.Count(); i++)
                {
                    Console.WriteLine($"{i} : { _tasks[i].name } : \n\"{ _tasks[i].discription }\";");
                }

                // выбор задания
                int choice = Int32.Parse(Console.ReadLine());
                if (choice < 0) break;

                bool resetflag;
                do
                {
                    // инициализация задачи
                    resetflag = _tasks[choice].Active();
                } while (resetflag);
            }
        }
    }
}
