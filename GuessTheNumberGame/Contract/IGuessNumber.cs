namespace GuessTheNumberGame.Contract
{
    /// <summary>
    /// Интерфейс, предоставляющий контракт для отгадывания числа
    /// </summary>
    public interface IGuessNumber
    {
        /// <summary>
        /// Проверка, отгадано ли число
        /// </summary>
        /// <param name="number">Число в формате строки</param>
        /// <returns>True - число отгадано; False - число не отгадано</returns>
        public bool IsTrueNumber(string number);
    }
}
