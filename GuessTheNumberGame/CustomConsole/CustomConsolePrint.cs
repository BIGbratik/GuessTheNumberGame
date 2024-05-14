namespace GuessTheNumberGame.CustomConsole
{
    /// <summary>
    /// Класс кастомизированного вывода сообщений в консоль
    /// </summary>
    public static class CustomConsolePrint
    {
        /// <summary>
        /// Вывод игровой информации
        /// </summary>
        /// <param name="message"></param>
        public static void PrintCommonInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод информации-реакции в ответ на предложение пользователя во время игры 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color">Цвет, с которыы должно быть выведено сообщение</param>
        public static void PrintReactionInfo(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод предупреждающей информации
        /// </summary>
        /// <param name="message"></param>
        public static void PrintWarningInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
