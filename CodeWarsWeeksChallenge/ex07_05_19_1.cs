using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsWeeksChallenge
{
    class ex07_05_19_1 : Challenge 
    {
        //new private string _name = "ex07_05_19_1";
        public string name { get { return _name; } }

        //new string _discription = "Первый входной массив содержит правильные ответы на экзамен, например  [\"a\", \"a\", \"b\", \"d\"]. Второй-массив \"ответы\" и содержит ответы студента.\n Эти два массива не являются пустыми и имеют одинаковую длину.Верните оценку для этого массива ответов, давая +4 для каждого правильного ответа, -1 для каждого неправильного ответа и +0 для каждого пустого ответа (пустая строка). \nЕсли результат < 0, возвращается 0.";
        public string discription { get { return _discription; } }

        private int _answerCount;

        //
        private string[] _rightAnswers;
        private string[] _studentAnswers;


        public ex07_05_19_1()
        {
            _name = "ex07_05_19_1";
            _discription = "Первый входной массив содержит правильные ответы на экзамен, например  [\"a\", \"a\", \"b\", \"d\"]. Второй-массив \"ответы\" и содержит ответы студента.\n Эти два массива не являются пустыми и имеют одинаковую длину.Верните оценку для этого массива ответов, давая +4 для каждого правильного ответа, -1 для каждого неправильного ответа и +0 для каждого пустого ответа (пустая строка). \nЕсли результат < 0, возвращается 0.";
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

        //
        override protected void Main()
        {
            Console.WriteLine("Количество проверяемых ответов");
            if (Int32.TryParse(Console.ReadLine(), out _answerCount))
            {

                _rightAnswers = new string[_answerCount];
                _studentAnswers = new string[_answerCount];

                //
                Random random = new Random();

                for (int i = 0; i < _answerCount; i++)
                {
                    // генерация правильных ответов
                    _rightAnswers[i] = "" + (random.NextDouble() * 1000);
                    
                    // генерация ответов учеников по принципу: пустой ответ в 30%, иначе с 70% шансом ответить правильно, в другом случае ответить случайно
                    _studentAnswers[i] = (random.NextDouble() < 0.3) ? ("") : ((random.NextDouble() > 0.7) ? (_rightAnswers[i]) : ("" + random.NextDouble() * 1000));
                }

                // вывод правильных ответов и ответов учеников
                string consoleString = "";
                foreach (string answer in _rightAnswers)
                {
                    consoleString += "|" + answer + "| ";
                }
                consoleString += "\n";
                foreach (string answer in _studentAnswers)
                {
                    if (answer != "") consoleString += "|" + answer + "| ";
                    else consoleString += "| | ";
                }
                Console.WriteLine(consoleString + "\n===========");

                // подсчет количества очков
                int score = CheckAnswer(_rightAnswers, _studentAnswers);
                Console.WriteLine("Оценка/количество очков равно " + score);
            } 
            else Console.WriteLine("something is broken");

        }

        //
        private int CheckAnswer(string[] rightAnswers, string[] studentAnswers)
        {
            int res = 0;

            for (int i = 0; i < rightAnswers.Count(); i++)
            {
                if (studentAnswers[i] != "")
                    if (studentAnswers[i] == rightAnswers[i])
                        res += 4;
                    else res--;
            }

            if (res < 0) res = 0;

            return res;
        }
    }
}
