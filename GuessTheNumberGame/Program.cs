using GuessTheNumberGame.Contract;
using GuessTheNumberGame.DTO;
using GuessTheNumberGame.Impl;

Console.WriteLine("Добро пожаловать в игру \"Угадай число\"");

while (true)
{
    Console.WriteLine("Играем или хватит (Играем - Y / Хватит - N):");
    var answer = Console.ReadLine()?.ToUpper();
    if (answer == SimpleRequest.N.ToString())
    {
        break;
    }
    else if (answer == SimpleRequest.Y.ToString())
    {
        PrepareSession();
    }
}

//НАПИСАТЬ ОТДЕЛЬНЫЙ ВАЛИДАТОР ВВОДА

void PrepareSession()
{
    Console.WriteLine("Давайте настроим игру? (Да - Y/Нет - N)");
    var isStartSettingUp = Console.ReadLine()?.ToUpper();

    IGuessNumber guessNumber;
    IGameSession session;

    if (isStartSettingUp == SimpleRequest.Y.ToString())
    {
        Console.WriteLine("Введите четыре числа через пробел, где" +
            "\n Первое число - левая граница отрезка для загадываемого числа" +
            "\n Второе число - правая граница отрезка для загадываемого числа" +
            "\n Третье число - кол-во попыток" +
            "\n Четвёртое число - 0, если целое и 1 если с плавающей точкой");

        var settings = Console.ReadLine()?.Trim().Split();

        if (settings.Length != 4)
        {
            Console.WriteLine("Переданно неверное кол-во настроек");
        }
        else
        {

            if (int.Parse(settings[3]) == 0)
            {
                guessNumber = new GuessNumberInt();
            }
            else
            {
                guessNumber = new GuessNumberDouble();
            }

            guessNumber.PrepareNumber(settings[0], settings[1]);

            session = new GameSession(guessNumber, settings[2]);
            session.PlayGame();
        }
    }
    else
    {
        var leftNumber = "0";
        var rightNumber = "10";
        var attemptCount = "5";
        Console.WriteLine($"Была выбрана игра без предварительных настроек. Правила следующие:" +
            $"\n Левая граница - {leftNumber}" +
            $"\n Правая граница - {rightNumber}" +
            $"\n Кол-во попыток - {attemptCount}");

        guessNumber = new GuessNumberInt();
        guessNumber.PrepareNumber(leftNumber, rightNumber);

        session = new GameSession(guessNumber, attemptCount);
        session.PlayGame();
    }    
}
