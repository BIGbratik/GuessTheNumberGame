using GuessTheNumberGame.Contract;
using GuessTheNumberGame.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Impl
{
    public class GameSession : IGameSession
    {
        private IGuessNumber _guessNumber { get; set; }

        private int _attemptCount { get; set; }
        public GameSession(IGuessNumber guessNumber, string attemptCount) 
        {
            _guessNumber = guessNumber;

            if (!int.TryParse(attemptCount, out _))
            {
                Console.WriteLine("Кол-во попыток задано некорректно!");
            }
            else
            {
                _attemptCount = int.Parse(attemptCount);
            }
        }

        public void PlayGame()
        {
            if (_attemptCount == 0)
            {
                Console.WriteLine("А как играть с 0 попыток?!");
            }
            else
            {
                Console.WriteLine("Если желаешь завершить игру досрочно - введи N.\nИгра началась!!!");
                while(_attemptCount > 0)
                {
                    var request = Console.ReadLine();
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
                                    Console.WriteLine(SimpleAnswers.Success.ToString());
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(SimpleAnswers.Fail.ToString());
                                    _attemptCount--;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("ИГРА ЗАВЕРШЕНА!!!");
            }
        }
    }
}
