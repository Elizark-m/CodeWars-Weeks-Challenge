using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsWeeksChallenge
{
    class ex07_05_19_2 : Challenge
    {
        public string name { get { return _name; } }

        public string discription { get { return _discription; } }

        //
        private int _n;

        private int[] _schoolsNum;
        private bool[] _schoolsPass;

        private double _TravelPrice;
        private int _current;

        //
        public ex07_05_19_2()
        {
            _name = "ex07_05_19_2";
            _discription = "Несколько лет назад Аарон оставил свою старую школу и зарегистрировался в другой из соображений безопасности. Теперь он хочет найти Джейн, одну из своих школьных подруг и хороших друзей. Есть n школ, пронумерованные от 1 до n. Можно путешествовать между каждой парой школ, купив билет. Билет между школами ij(i + j) module(n + 1) стоит дорого и может быть использован несколько раз. Помогите Аарону найти минимальную общую стоимость посещения всех школ. Он может начать и закончить в любой школе.";
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
            Console.WriteLine("кол-во школ?");
            if(Int32.TryParse(Console.ReadLine(), out _n))
            {
                _schoolsNum = new int[_n];
                _schoolsPass = new bool[_n];
                _TravelPrice = 0;

                for(int i = 0; i < _n; i++)
                {
                    _schoolsNum[i] = i+1;
                    _schoolsPass[i] = false;
                }

                Random rnd = new Random();
                int start = rnd.Next(0, _n - 1);

                double res = Travel(start);

                Console.WriteLine($"{res}");
            }            
        }

        private double Travel(int current)
        {
            _current = current;
            _schoolsPass[_current] = true;

            Console.WriteLine($"start: {_current}");

            for (int k = 0; true; k++)
            {
                if (_current == (int)(_n / 2))
                    {
                        Console.WriteLine($"debug: _current = {_current}, ride: {0}");
                        if (Ride(0)) break;                    
                    }
                else
                {
                    if (_current < (int)(_n / 2))
                        {
                        Console.WriteLine($"debug: _current = {_current}, ride: {_n - _current}");
                        if (Ride(_n - _current))
                        {
                            Console.WriteLine($"debug: _current = {_current}, ride: {_n - _current}");
                            break;
                        }
                        else { Console.WriteLine("i'm fuck up my programm");
                            
                        }
                    }
                    else
                        {
                            Console.WriteLine($"debug: _current = {_current}, ride: {_n - (_current + 1)}");
                            if (Ride(_n - (_current + 1))){ break; } }
                }
            }

            for(int i = 0; i < _n; i++)
            {
                Console.Write($"{_schoolsNum[i]}, ");
                Console.Write($"{_schoolsPass[i]}, ");
            }

            Console.WriteLine();

            return _TravelPrice;
        }

        private double TicketPrice(int i, int j)
        {
            double res = 0;

            res = (double)(i + j) / (double)(_n + 1);

            return res;
        }

        private bool Ride(int next)
        {
            Console.WriteLine($"debug: {_current}");
            _schoolsPass[_current] = true;

            if (next == _n)
                next = _n - 1;

            if (_schoolsPass[next])
            {
                return true;
            }                

            _TravelPrice += TicketPrice(_current, next - 1);
            _current = next;            

            return false;
        }

        //private int 

    }
}
