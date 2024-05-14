﻿using GuessTheNumberGame.Contract;

namespace GuessTheNumberGame.Impl
{
    public class GuessNumberInt : IGuessNumber
    {
        private int _myNumber;
        public GuessNumberInt() 
        {

        }

        public bool? IsTrueNumber(string number)
        {
            if (int.TryParse(number, out var num))
            {
                if (_myNumber == num)
                {
                    return true;
                }

                return false;
            }
            else
            {
                return null;
            }
        }

        public void PrepareNumber(string leftNumber, string rightNumber)
        {
            //Валидация переданных границ числа
            if (!int.TryParse(leftNumber, out var firstNum))
            {
                Console.WriteLine("Левое число передано неверно, либо выходит за пределы допустимого");
            }

            if (!int.TryParse(rightNumber, out var secondNum))
            {
                Console.WriteLine("Правое число передано неверно, либо выходит за пределы допустимого");
            }

            // Генерируем случайн коэффициент
            var simpleRnd = (new Random()).Next(1, 10);

            // Строим случайный корень генерации случаности для игрового числа
            var seed = firstNum * simpleRnd - secondNum / simpleRnd;

            // Инициализируем генератор случаности для игры
            var rnd = new Random(seed);

            // Задаём число к игре на заданном отрезке
            _myNumber = rnd.Next(firstNum, secondNum);
        }
    }
}
