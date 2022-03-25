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
            _discription = "Цель этого ката-написать программу, которая может делать некоторую алгебру. Напишите функцию expand, которая принимает выражение с одной символьной переменной и расширяет его. Выражение находится в форме(ax+b)^n, где a и b являются целыми числами, которые могут быть положительными или отрицательными, x является любой переменной длиной в один символ и является натуральным числом.\n expand(\"(x + 1) ^ 2\")   ||   // returns \"x ^ 2 + 2x + 1\"\n expand(\"(p - 1) ^ 3\");   ||   // returns \"p ^ 3 - 3p ^ 2 + 3p - 1\";";
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
            // нахождение значений выражения
            FindVariables(str, out a, out b, out x, out n);
            // расширяет выражение в зависимости от степени
            str = CreatePuzzle(a, b, x, n, 0);
            // выводим полученное выражение
            Console.WriteLine(str);
        }
        
        // рекурсивное расширения выражения
        private string CreatePuzzle(int a, int b, char x, int n, int deep)
        {
            string res = "";
            
            // проверка на начало рекурсии
            if (deep == 0)
            {
                int i = (int)Math.Pow(a, n);
                // формирование знака для значения a
                if (i < 0) res += "-";
                // формирование значения а
                if (Math.Abs(i) != 1)
                    res += $"{Math.Abs(i)}";
                // формирование степени a
                res += $"{x}^{n}";
            }
            // проверка на границу рекурсии
            else if (deep == n)
            {          
                int i = (int)Math.Pow(b, n);
                // формирование знака для значения b
                if (i < 0) res += "-";
                else res += "+";
                // формирование значения b
                if (Math.Abs(i) != 1)
                    res += $"{Math.Abs(i)}";
                // формирование степени a
                res += $"{x}^{n}";
                return res;
            }
            else
            {
                // формирование промежуточного значения
                int i = (int)(Math.Pow(a, n - deep) * Math.Pow(b, deep));
                // формирование знака для промежуточного значения
                if (i < 0) res += $"{n * i}";
                else res += $"+{n * i}";
                
                res += $"{x}";
                // формирование степени для промежуточного значения
                if (n - deep > 1) res += $"^{ n - deep}";
            }
            
            // возвращает сумму рекурсивно-расширенных кусочков выражения
            return res += $"{ CreatePuzzle(a, b, x, n, deep + 1)}";
        }
        
        // Нахождение переменных выражения в строке
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
                // обнаружение начала ввыражения
                if (str[i] == '(')
                    startFlag = true;
                
                // проверка на наличие выражения
                if (startFlag)
                {   
                    // проверка отсутствие определения значения a1
                    if (!flagA)
                    {   
                        // проверка на знак a1
                        if (flagFlagAisPos && str[i] == '-')
                        {
                            // отмечает знак значения a1 как отрицательный 
                            flagAisPositive = false;
                        }
                        // проверка, что текущий символ является частью значения a1
                        else if (Char.IsDigit(str[i]))
                        {
                            // формирование значения a1
                            Int32.TryParse(""+str[i], out int num);
                            a1 = a1 * 10 + num;
                        }
                        else
                            // отмечает наличие значения a1
                            flagA = true;
                        
                        // отмечает наличие знака значения a1
                        flagFlagAisPos = true;
                    }
                    
                    // проверка на отсутствие определения символа переменной
                    if (!flagX)
                    {   
                        // проверка, что будущая переменная является символом
                        if (char.IsLetter(str[i]))
                        {
                            // запись текущего символа как символа переменной
                            x1 = str[i];
                            // отмечаем наличие символа переменной
                            flagX = true;
                            continue;
                        }
                    }
                    
                    // проверка на наличие символа переменной
                    if (flagX)
                    {
                        // проверка на наличия знака значения b1
                        if (!flagFlagBisPos)
                        {
                            if (str[i] == '-')
                            {
                                // отмечает наличие знака у значения b1
                                flagFlagBisPos = true;
                                // отмечает значение b1 как отрицательное
                                flagBisPositive = false;
                                continue;
                            }
                            if (str[i] == '+')
                            {   
                                // отмечает наличие знака у значение b1
                                flagFlagBisPos = true;
                                continue;
                            }
                        }
                    }
                    
                    // проверка наличия символа переменной и отсутвия значения b1
                    if(flagX && !flagB)
                    { 
                        // проверка на конец выражения в скобках
                        if(str[i] == ')')
                        {
                            // отмечает наличие значение b1
                            flagB = true;
                            continue;
                        }
                        else
                        {
                            // проверка, что текущее значение является цифрой
                            if (Char.IsDigit(str[i]))
                            {
                                // формирование значения b1
                                Int32.TryParse("" + str[i], out int num);
                                b1 = b1 * 10 + num;
                            }
                        }
                    }
                    
                    // проверка на наличие значения b1
                    if (flagB)
                    {
                        // проверка на начало значения n1 (степени)
                        if (str[i] == '^')
                        {
                            // формирование значения n1
                            Int32.TryParse(""+str[i + 1], out n1);
                        }                            
                    }
                }
            }
            
            // присоединение знака значений к значениям
            if (!flagAisPositive)
                a1 = -a1;
            if (!flagBisPositive)
                b1 = -b1;
            
            // проверка на отсутствие числового значения переменной
            if (a1 == 0) a1 = 1;
            if (b1 == 0) b1 = 1;
            
            //вывод результирующих значений
            a = a1;
            b = b1;
            n = n1;
            x = x1;
        }

    }
}
