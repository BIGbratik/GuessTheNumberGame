using GuessTheNumberGame.Contract;
using System.Security.Cryptography;

namespace GuessTheNumberGame.Impl
{
    public class GuessNumberDouble : IGuessNumber
    {
        private double _myNumber;

        public bool? IsTrueNumber(string number)
        {
            if (double.TryParse(number, out var num))
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
            if (!double.TryParse(leftNumber, out var firstNum))
            {
                Console.WriteLine("Левое число передано неверно, либо выходит за пределы допустимого");
            }

            if (!double.TryParse(rightNumber, out var secondNum))
            {
                Console.WriteLine("Правое число передано неверно, либо выходит за пределы допустимого");
            }

            // Генерируем случайн коэффициент
            var simpleRnd = (new Random()).NextDouble();

            // Строим случайный корень генерации случаности для игрового числа
            var seed = (int)(firstNum * simpleRnd - secondNum / simpleRnd);

            // Инициализируем генератор случаности для игры
            var rnd = new Random(seed);

            // Задаём число к игре на заданном отрезке
            _myNumber = rnd.NextDouble()*(secondNum-firstNum)+firstNum;
        }
    }
}
