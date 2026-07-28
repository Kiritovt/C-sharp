using Game;

public static class RandomGame
{
    public static void Main()
    {
        bool isGameRunning = true;

        Random random = new();
        Player player = new();

        Console.WriteLine(
            "Welcome to the Random Number Guessing Game!"
        );

        Console.Write("Please enter your name: ");
        player.Name = Console.ReadLine()?.Trim() ?? "Player";

        while (isGameRunning)
        {
            bool hasGuessed = false;
            player.ResetTries();

            Console.WriteLine();
            Console.WriteLine(
                $"Hello, {player.Name}! Let's start the game."
            );

            Console.WriteLine(
                "Select a difficulty level:\n" +
                "Easy (1-50 with unlimited tries)\n" +
                "Normal (1-100 with 10 tries)\n" +
                "Hard (1-500 with 8 tries)"
            );

            string difficulty =
                Console.ReadLine()?.Trim().ToLowerInvariant() ?? "";

            Console.WriteLine(
                $"Difficulty level selected: {difficulty}"
            );

            if (difficulty == "easy")
            {
                int randomNumber = random.Next(1, 51);

                Console.WriteLine(
                    "Time to guess! You have unlimited tries."
                );

                while (!hasGuessed)
                {
                    int answer = player.ReadGuess(1, 50);

                    if (answer == randomNumber)
                    {
                        Console.WriteLine(
                            $"Congratulations, {player.Name}! " +
                            $"You guessed the correct number " +
                            $"{randomNumber} in {player.Tries} tries."
                        );

                        hasGuessed = true;
                    }
                    else if (answer < randomNumber)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                }
            }
            else if (difficulty == "normal")
            {
                int randomNumber = random.Next(1, 101);

                Console.WriteLine(
                    "Time to guess! You have 10 tries."
                );

                for (int i = 0; i < 10; i++)
                {
                    int answer = player.ReadGuess(1, 100);

                    if (answer == randomNumber)
                    {
                        Console.WriteLine(
                            $"Congratulations, {player.Name}! " +
                            $"You guessed the correct number " +
                            $"{randomNumber} in {player.Tries} tries."
                        );

                        hasGuessed = true;
                        break;
                    }

                    if (answer < randomNumber)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                }

                if (!hasGuessed)
                {
                    Console.WriteLine(
                        $"Sorry, {player.Name}. " +
                        $"You've used all your tries. " +
                        $"The correct number was {randomNumber}."
                    );
                }
            }
            else if (difficulty == "hard")
            {
                int randomNumber = random.Next(1, 501);

                Console.WriteLine(
                    "Time to guess! You have 8 tries."
                );

                for (int i = 0; i < 8; i++)
                {
                    int answer = player.ReadGuess(1, 500);

                    if (answer == randomNumber)
                    {
                        Console.WriteLine(
                            $"Congratulations, {player.Name}! " +
                            $"You guessed the correct number " +
                            $"{randomNumber} in {player.Tries} tries."
                        );

                        hasGuessed = true;
                        break;
                    }

                    if (answer < randomNumber)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                }

                if (!hasGuessed)
                {
                    Console.WriteLine(
                        $"Sorry, {player.Name}. " +
                        $"You've used all your tries. " +
                        $"The correct number was {randomNumber}."
                    );
                }
            }
            else
            {
                Console.WriteLine(
                    "Invalid difficulty level selected."
                );

                continue;
            }

            isGameRunning = player.AskToPlayAgain();
        }

        Console.WriteLine(
            "Thank you for playing! Goodbye!"
        );
    }
}