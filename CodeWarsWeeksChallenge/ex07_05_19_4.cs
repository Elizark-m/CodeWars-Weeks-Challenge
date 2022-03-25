using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsWeeksChallenge
{
    class ex07_05_19_4: Challenge
    {
        public string name { get { return _name; } }

        public string discription { get { return _discription; } }

        private string _startStr;
        private string _resStr;

        public ex07_05_19_4()
        {
            _name = "ex07_05_19_4";
            _discription = "Цель этого ката-написать программу, которая может делать некоторую алгебру. Напишите функциюexpand, которая принимает выражение с одной, одной символьной переменной и расширяет его.Выражение находится в форме(ax+b)^ n, где aи bявляются целыми числами, которые могут быть положительными или отрицательными, xявляется любой переменной длиной в один символ и nявляется натуральным числом.\n expand(\"(x + 1) ^ 2\")   ||   // returns \"x ^ 2 + 2x + 1\"\n expand(\"(p - 1) ^ 3\");   ||   // returns \"p ^ 3 - 3p ^ 2 + 3p - 1\";";
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
            string str;
            int a, b, n;
            char x;

            Console.WriteLine("Введите выражение");
            str = Console.ReadLine();
            FindVariables(str, out a, out b, out x, out n);
            str = CreatePuzzle(a, b, x, n, 0);
            Console.WriteLine(str);
        }

        private string CreatePuzzle(int a, int b, char x, int n, int deep)
        {
            string res = "";

            if (deep == 0)
            {
                int i = (int)Math.Pow(a, n);
                if (i < 0) res += "-";
                if (Math.Abs(i) != 1)
                    res += $"{Math.Abs(i)}";
                res += $"{x}^{n}";
            }
            else if (deep == n)
            {
                int i = (int)Math.Pow(b, n);
                if (i < 0) res += "-";
                else res += "+";
                res += $"{Math.Abs(i)}";
                return res;
            }
            else
            {
                int i = (int)(Math.Pow(a, n - deep) * Math.Pow(b, deep));

                if (i < 0) res += $"{n * i}";
                else res += $"+{n * i}";

                res += $"{x}";

                if (n - deep > 1) res += $"^{ n - deep}";
            }

            return res += $"{ CreatePuzzle(a, b, x, n, deep + 1)}";
        }

        private void FindVariables(string str, out int a, out int b, out char x, out int n)
        {
            int a1 = 0, b1 = 0, n1 = 0;
            char x1 = 'h';

            bool startFlag = false;
            bool flagAisPositive = true;
            bool flagFlagAisPos = false;
            bool flagBisPositive = true;
            bool flagFlagBisPos = false;
            bool flagA = false;
            bool flagB = false;
            bool flagX = false;

            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    startFlag = true;

                if (startFlag)
                {
                    if (!flagA)
                    {
                        if (flagFlagAisPos && str[i] == '-')
                        {
                            flagAisPositive = false;
                        }                        
                        else if (Char.IsDigit(str[i]))
                        {
                            Int32.TryParse(""+str[i], out int num);
                            a1 = a1 * 10 + num;
                        }
                        else
                            flagA = true;

                        flagFlagAisPos = true;
                    }

                    if (!flagX)
                    {
                        if (char.IsLetter(str[i]))
                        {
                            x1 = str[i];
                            flagX = true;
                            continue;
                        }
                    }

                    if (flagX)
                    {
                        if (!flagFlagBisPos)
                        {
                            if (str[i] == '-')
                            {
                                flagFlagBisPos = true;
                                flagBisPositive = false;
                                continue;
                            }
                            if (str[i] == '+')
                            {   
                                flagFlagBisPos = true;
                                continue;
                            }
                        }
                    }

                    if(flagX && !flagB)
                    { 
                        if(str[i] == ')')
                        {
                            flagB = true;
                            continue;
                        }
                        else
                        {
                            if (Char.IsDigit(str[i]))
                            {
                                Int32.TryParse("" + str[i], out int num);
                                b1 = b1 * 10 + num;
                            }
                        }
                    }

                    if (flagB)
                    {
                        if (str[i] == '^')
                        {
                            Int32.TryParse(""+str[i + 1], out n1);
                        }
                            
                    }
                }
            }

            if (!flagAisPositive)
                a1 = -a1;
            if (!flagBisPositive)
                b1 = -b1;

            if (a1 == 0) a1 = 1;

            a = a1;
            b = b1;
            n = n1;
            x = x1;
        }

    }
}
