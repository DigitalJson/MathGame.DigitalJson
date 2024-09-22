/* 
 * REQUIREMENTS
 * ----------------------------------------------------------------------------------
 * 1. Create a math game containing the 4 basic operations (+,-,/,*)
 * 2. Division should result on integers only and dividends should go from 0 to 100
 *      Eg. 7/2 should not be shown as it's quotient is not a whole number
 * 3. User should be presented with a menu to choose operation
 * 4. Previous games should be recorded on a list and there should be an option in 
 *      the menu for the user to visualize history of games
 * ----------------------------------------------------------------------------------
 * 
 * TODO:
 * 1. Create menu
 * 2. Create logic for math game
 * 3. Create history of games done
 */

string choice = "";
string input = "";

List<string> gameHistory = new List<string>();
do
{

    Console.WriteLine("MATH GAME");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Please enter a number on what to do.");
    Console.WriteLine("1. Play\n2. Check previous games\n3. Quit");

    input = Console.ReadLine();
    if (input != null)
    {
        choice = input.Trim();
    }
    switch (choice)
    {
        case "1":
            PlayGame();
            break;
        case "2":
            Console.Clear();
            CheckHistory();
            Console.WriteLine();
            break;
        case "3":
            Console.WriteLine("Quitting application...");
            Console.ReadLine();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Invalid input. Please try again.");
            break;
    }
} while (choice != "3");

void PlayGame()
{
    string operation = "";

    do
    {
        Console.WriteLine("Please choose what operation you would like to do.");
        Console.WriteLine("Options: +, -, /, * (Type q if you want to quit.)");

        input = Console.ReadLine();
        if (input != null)
        {
            operation = input.Trim().ToLower();
        }
        switch (operation)
        {
            case "+":
                MathGame(operation);
                break;
            case "-":
                MathGame(operation);
                break;
            case "*":
                MathGame(operation);
                break;
            case "/":
                MathGame(operation);
                break;
            case "q":
                Console.Clear();
                Console.WriteLine("Returnng to main menu...\n");
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.\n");
                break;
        }
    } while (operation != "q");
}

void MathGame(string operation)
{
    int num1 = 0;
    int num2 = 0;
    int correctAnswer = 0;
    int inputtedAnswer = 0;
    bool isNumber = false;
    bool isCorrect = false;
    Random random = new Random();

    Console.WriteLine("Enter the correct answer.");

    switch (operation)
    {
        case "+":
            num1 = random.Next(1, 101);
            num2 = random.Next(1, 101);
            correctAnswer = num1 + num2;
            Console.WriteLine($"{num1} {operation} {num2} = ?");
            input = Console.ReadLine();
            if (input != null)
            {
                isNumber = int.TryParse(input, out inputtedAnswer);
                if (inputtedAnswer == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("That's incorrect. Please try again.");
                }
                if (isNumber)
                {
                    AddGameToHistory(num1, num2, operation, inputtedAnswer, isCorrect);
                }
                
            }
            break;
        case "-":
            num1 = random.Next(1, 101);
            num2 = random.Next(1, 101);
            correctAnswer = num1 - num2;
            Console.WriteLine($"{num1} {operation} {num2} = ?");
            input = Console.ReadLine();
            if (input != null)
            {
                isNumber = int.TryParse(input, out inputtedAnswer);
                if (inputtedAnswer == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("That's incorrect. Please try again.");
                }
                if (isNumber)
                {
                    AddGameToHistory(num1, num2, operation, inputtedAnswer, isCorrect);
                }
            }
            break;
        case "*":
            num1 = random.Next(1, 101);
            num2 = random.Next(1, 101);
            correctAnswer = num1 * num2;
            Console.WriteLine($"{num1} {operation} {num2} = ?");
            input = Console.ReadLine();
            if (input != null)
            {
                isNumber = int.TryParse(input, out inputtedAnswer);
                if (inputtedAnswer == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("That's incorrect. Please try again.");
                }
                if (isNumber)
                {
                    AddGameToHistory(num1, num2, operation, inputtedAnswer, isCorrect);
                }
            }
            break;
        case "/":
            do
            {
                num1 = random.Next(1, 101);
                num2 = random.Next(1, 101);
            } while (num1 % num2 != 0);
            correctAnswer = num1 / num2;
            Console.WriteLine($"{num1} {operation} {num2} = ?");
            input = Console.ReadLine();
            if (input != null)
            {
                isNumber = int.TryParse(input, out inputtedAnswer);
                if (inputtedAnswer == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("That's incorrect. Please try again.");
                }
                if (isNumber)
                {
                    AddGameToHistory(num1, num2, operation, inputtedAnswer, isCorrect);
                }
            }
            break;
    }
}

void CheckHistory()
{
    foreach (string game in gameHistory)
    {
        Console.WriteLine(game);
    }
}

void AddGameToHistory(int num1, int num2, string operation, int answer, bool isCorrect)
{
    string checkMark = "\u2713";
    string crossMark = "X";
    if (isCorrect)
    {
        gameHistory.Add($"{num1} {operation} {num2} = {answer} {checkMark}");
    }
    else
    {
        gameHistory.Add($"{num1} {operation} {num2} = {answer} {crossMark}");
    }
    
}