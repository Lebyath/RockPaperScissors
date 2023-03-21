namespace RockPaperScissors
{
    class HumanPlayer
    {   
        private int points;
    
        public HumanPlayer(int initial)
        {
            points = initial;
        }

        public int GetPoints()
        {
            return points;
        }

        public int WinRound()
        {
            return points += 5;
        }

        public int LoseRound()
        {
            return points -= 5; 
        }

        public string HumanDecision()
        {
            Console.WriteLine("Please input your choice: rock, paper, or scissors.");
            string choice = Console.ReadLine().ToLower();
            string[] options = new string[]{"rock", "paper", "scissors"};
            while (!options.Contains(choice))
            {
                Console.WriteLine("Please enter a valid choice!");
                choice = Console.ReadLine().ToLower();
            }
            return choice;
        }
    }

    class ComputerPlayer
    {
        public string ComputerDecision()
        {
            string[] compChoices = new string[]{"rock", "paper", "scissors"};
            Random rand = new Random();
            int select = rand.Next(compChoices.Length);
            return compChoices[select]; 
        } 
    }

    class RockPaperScissors 
    {
        static void Main(string[] args)
        {
            HumanPlayer player = new HumanPlayer(5);
            ComputerPlayer computer = new ComputerPlayer();

            while (player.GetPoints() > 0)
            {
                Console.WriteLine("****Rock, Paper, Scissors, Start!!****");
                Console.WriteLine($"You have {player.GetPoints()} points");
                string PD = player.HumanDecision();
                string CD = computer.ComputerDecision();
                Console.WriteLine($"Your Decision: {PD}");
                Console.WriteLine($"Computer Decision: {CD}");

                if (PD == CD)
                {
                        Console.WriteLine("It's a Tie");
                }
                else if ((PD == "rock" && CD == "scissors") ||
                        (PD == "paper" && CD == "rock") ||
                        (PD == "scissors" && CD == "paper"))
                {
                    Console.WriteLine("You Win!");
                    player.WinRound();
                }
                else
                {
                    Console.WriteLine("You Lose!");
                    player.LoseRound();
                }
                Console.WriteLine();
            
                Console.WriteLine("Play again? Input y to continue, or n to exit");
                string PA = Console.ReadLine().ToLower();
                while (PA != "y" && PA != "n")
                {
                    Console.WriteLine("Invalid input. Play again? Input y to continue, or n to exit");
                    PA = Console.ReadLine().ToLower();
                }
                if (PA == "n")
                {
                    break;
                }
                else if (PA == "y" && player.GetPoints() == 0)
                {
                    Console.WriteLine("Sorry, you don't have enough points!");
                }
                Console.WriteLine("**************************************");           
            }
            Console.WriteLine("Thank you for playing!");       
        }
    }
}