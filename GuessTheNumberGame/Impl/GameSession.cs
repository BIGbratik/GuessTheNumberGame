using GuessTheNumberGame.Contract;
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
        public GameSession(IGuessNumber guessNumber) 
        {
            _guessNumber = guessNumber;
        }
    }
}
