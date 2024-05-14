using GuessTheNumberGame.CustomConsole;
using GuessTheNumberGame.DTO;
using GuessTheNumberGame.GuessNumber;

namespace GuessTheNumberGame.Session
{
    public class GameSession
    {
        private IGuessNumber _guessNumber { get; set; }

        private int _attemptCount { get; set; }

        public GameSession(IGuessNumber guessNumber, string attemptCount)
        {
            _guessNumber = guessNumber;

            if (!int.TryParse(attemptCount, out _))
            {
                CustomConsolePrint.PrintWarningInfo("\nКол-во попыток задано некорректно (третье число в настройках)");
            }
            else
            {
                _attemptCount = int.Parse(attemptCount);
            }
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        public void PlayGame()
        {
            if (_attemptCount == 0)
            {
                CustomConsolePrint.PrintCommonInfo("\nА как играть с 0 попыток?!");
            }
            else
            {
                CustomConsolePrint.PrintCommonInfo("\nЕсли желаешь завершить игру досрочно - введи N.\nИгра началась!!!");

                while (_attemptCount > 0)
                {
                    var request = Console.ReadLine()?.ToUpper();
                    if (request != null)
                    {
                        if (request == SimpleRequest.N.ToString())
                        {
                            break;
                        }
                        else
                        {
                            var isSuccess = _guessNumber.IsTrueNumber(request);
                            if (isSuccess.HasValue)
                            {
                                if (isSuccess.Value)
                                {
                                    CustomConsolePrint.PrintReactionInfo(SimpleAnswers.Success.ToString(), ConsoleColor.Green);
                                    break;
                                }
                                else
                                {
                                    CustomConsolePrint.PrintReactionInfo(SimpleAnswers.Fail.ToString(), ConsoleColor.Red);
                                    _attemptCount--;
                                }
                            }
                        }
                    }
                }
                CustomConsolePrint.PrintCommonInfo("\nИГРА ЗАВЕРШЕНА!!!\n");
            }
        }
    }
}
