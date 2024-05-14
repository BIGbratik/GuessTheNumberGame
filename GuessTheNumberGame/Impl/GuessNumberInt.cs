using GuessTheNumberGame.Contract;

namespace GuessTheNumberGame.Impl
{
    public class GuessNumberInt : IGuessNumber
    {
        public bool IsTrueNumber(string number)
        {
            return true;
        }
    }
}
