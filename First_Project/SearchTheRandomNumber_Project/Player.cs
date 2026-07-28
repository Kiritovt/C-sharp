namespace Game;

public class Player
{
    public string Name { get; set; } = "";

    public int Score { get; private set; }

    public int Tries { get; private set; }

    public void ResetTries()
    {
        Tries = 0;
    }

    public void RegisterTry()
    {
        Tries++;
    }

    public void UpdateScore(int points)
    {
        Score += points;
    }

    public int ReadGuess(int min, int max)
    {
        while (true)
        {
            Console.Write($"Enter your guess ({min}-{max}): ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine(
                    "Invalid input. Please enter a valid integer."
                );

                continue;
            }

            if (guess < min || guess > max)
            {
                Console.WriteLine(
                    $"Please enter a number between {min} and {max}."
                );

                continue;
            }

            RegisterTry();

            return guess;
        }
    }

    public bool AskToPlayAgain()
    {
        while (true)
        {
            Console.Write("Do you want to play again? (yes/no): ");

            string input =
                Console.ReadLine()?.Trim().ToLowerInvariant() ?? "";

            if (input == "yes" || input == "y")
            {
                return true;
            }

            if (input == "no" || input == "n")
            {
                return false;
            }

            Console.WriteLine(
                "Invalid input. Please enter 'yes' or 'no'."
            );
        }
    }
}