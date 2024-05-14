using GuessTheNumberGame.CustomConsole;

namespace GuessTheNumberGame.GuessNumber
{
    public class GuessNumberDouble : IGuessNumber
    {
        private double _myNumber;

        public bool? IsTrueNumber(string number)
        {
            if (double.TryParse(number.Replace('.', ','), out var num))
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
            if (!double.TryParse(leftNumber.Replace('.', ','), out var firstNum))
            {
                CustomConsolePrint.PrintWarningInfo("\nЛевое число передано неверно, либо выходит за пределы допустимого (первое число в настройках)");
            }

            if (!double.TryParse(rightNumber.Replace('.', ','), out var secondNum))
            {
                CustomConsolePrint.PrintWarningInfo("\nПравое число передано неверно, либо выходит за пределы допустимого (второе число в настройках)");
            }

            // Генерируем случайн коэффициент
            var simpleRnd = new Random().NextDouble();

            // Строим случайный корень генерации случаности для игрового числа
            var seed = (int)(firstNum * simpleRnd - secondNum / simpleRnd);

            // Инициализируем генератор случаности для игры
            var rnd = new Random(seed);

            // Задаём число к игре на заданном отрезке
            _myNumber = rnd.NextDouble() * (secondNum - firstNum) + firstNum;
        }
    }
}
