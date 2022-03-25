using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsWeeksChallenge
{

    abstract class Challenge
    {
        protected string _name;
        public string name { get { return _name; } }

        protected string _discription;
        public string discription { get { return _discription; } }

        //
        abstract public bool Active();

        //
        abstract protected void Main();

        //
        abstract public bool Reset();
    }


    class mass
    {
        //Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера
        //и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива,
        //метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),
        //метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
        //б) Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
        //е) * Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)


        Double[] arr;

        //Свойство выдающее сумму
        public Double sum 
        {            
            get 
            {
                Double res = 0;

                foreach(int num in arr)
                {
                    res += num;
                }
                return res;
            }
        }

        //Конструктор по размеру с начальным значением и шагом
        public mass(int leght, Double startNum, Double step)
        {           
            arr = new Double[leght];
            //значение элемента массива равно сумме начального значения и произведения номера элемента на шаг
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = startNum + step * i;
            }
        }

        //Метод возвращающий новый массив с отрицанием
        public Double[] Inverse()
        {
            Double[] res = new double[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = -arr[i];
            }
            return res;
        }

        //Метод возвращающий новый массив измененный в n раз
        public Double[] Multply(Double n)
        {
            Double[] res = new double[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i] * n;
            }

            return res;
        }
    }
}
