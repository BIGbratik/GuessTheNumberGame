using GuessTheNumberGame.Contract;

namespace GuessTheNumberGame.Impl
{
    public class GuessNumberFloat : IGuessNumber
    {
        public bool IsTrueNumber(string number)
        {
            return true;
        }
    }
}
