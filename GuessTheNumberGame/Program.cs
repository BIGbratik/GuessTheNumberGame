using GuessTheNumberGame.CustomConsole;
using GuessTheNumberGame.DTO;
using GuessTheNumberGame.Session;

CustomConsolePrint.PrintCommonInfo("\n\nДОБРО ПОЖАЛОВАТЬ В ИГРУ \"УГАДАЙ ЧИСЛО\"\n");

while (true)
{
    CustomConsolePrint.PrintCommonInfo("\nИграем или хватит (Играем - Y / Хватит - N):");

    var answer = Console.ReadLine()?.Trim().ToUpper();

    if (answer == SimpleRequest.N.ToString())
    {
        break;
    }
    else if (answer == SimpleRequest.Y.ToString())
    {
        var session = SessionPreparator.PrepareSession();

        if (session == null)
        {
            CustomConsolePrint.PrintWarningInfo("\nВо Время формирования сессии возникли проблемы. Попробуйте ещё раз.");
        }
        else
        {
            session.PlayGame();
        }
    }
}

