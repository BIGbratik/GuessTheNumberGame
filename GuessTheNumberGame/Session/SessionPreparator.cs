using GuessTheNumberGame.CustomConsole;
using GuessTheNumberGame.DTO;
using GuessTheNumberGame.GuessNumber;

namespace GuessTheNumberGame.Session
{
    public static class SessionPreparator
    {
        /// <summary>
        /// Подготовка игровой сессии
        /// </summary>
        /// <returns>Готовый к игре экзмепляр сессии</returns>
        public static GameSession PrepareSession()
        {
            CustomConsolePrint.PrintCommonInfo("\nДавайте настроим игру? (Да - Y/Нет - N)");

            var isStartSettingUp = Console.ReadLine()?.ToUpper();

            IGuessNumber guessNumber;
            GameSession session;
            var leftNumber = "0";
            var rightNumber = "10";
            var attemptCount = "5";

            if (isStartSettingUp == SimpleRequest.Y.ToString())
            {
                CustomConsolePrint.PrintCommonInfo("\nВведите четыре числа через пробел, где:" +
                    "\n 1) Левая граница отрезка для загадываемого числа" +
                    "\n 2) Правая граница отрезка для загадываемого числа" +
                    "\n 3) Кол-во попыток" +
                    "\n 4) Тип числа (0, если целое и 1 если с плавающей точкой)");

                var settings = Console.ReadLine()?.Trim().Split();

                if (settings == null || settings.Length != 4)
                {
                    CustomConsolePrint.PrintWarningInfo("Переданно неверное кол-во настроек");
                    return null;
                }
                else if (int.TryParse(settings[3], out var numberType))
                {
                    if (numberType == (int)NumberType.IntNum)
                    {
                        guessNumber = new GuessNumberInt();
                    }
                    else if (numberType == (int)NumberType.DoubleNum)
                    {
                        guessNumber = new GuessNumberDouble();
                    }
                    else
                    {
                        CustomConsolePrint.PrintWarningInfo("\nПередан неверный тип числа (четвёртое число в настройках)");
                        return null;
                    }

                    leftNumber = settings[0];
                    rightNumber = settings[1];
                    attemptCount = settings[2];
                }
                else
                {
                    CustomConsolePrint.PrintWarningInfo("\nВ процессе валидации данных произошла ошибка");
                    return null;
                }
            }
            else
            {
                CustomConsolePrint.PrintCommonInfo($"\nБыла выбрана игра без предварительных настроек. Правила следующие:" +
                    $"\n Левая граница - {leftNumber}" +
                    $"\n Правая граница - {rightNumber}" +
                    $"\n Кол-во попыток - {attemptCount}");

                guessNumber = new GuessNumberInt();
            }

            guessNumber.PrepareNumber(leftNumber, rightNumber);

            session = new GameSession(guessNumber, attemptCount);

            return session;
        }
    }
}
