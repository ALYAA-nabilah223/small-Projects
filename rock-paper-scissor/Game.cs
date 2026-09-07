class Game
{
    private int rounds; 
    private int mode;

    Random rnd = new Random(); 
    
    Player player1 = new Player("Player 1", 0, 0);
    Player player2 = new Player("Player 2", 0, 0);
    // Properties
    public int Rounds
    {
        get { return rounds; }
        set { if (value < 1) rounds = 1; else rounds = value; }
    }

    public int Mode
    {
        get {return mode;}
        set{ mode = value;}
    }

    // Constructor
    public Game(int _rounds, int _mode)
    {
        Rounds = _rounds;
        Mode = _mode; 
    }


    public void Start()
    {
        string holder;
        Console.WriteLine("Welcome to Rock-Paper-Scissors Game!");
        // Chosing Mode
        do
        {
            Console.WriteLine("Please choose a mode: \n1. Player vs Computer\n2. Player vs Player\n>> ");
            holder = Console.ReadLine();
            TryParseInput(holder, out Mode);
        }while(Mode <= 0 || Mode > 2);

        do
        {
            Console.WriteLine("Please enter the number of rounds you want to play: ");
            holder = Console.ReadLine();
            TryParseInput(holder, out Rounds);
        }while(Rounds <= 0);
       

         for( int i = 0; i < Rounds; i++)
            {
                Console.WriteLine($"Round {i + 1}:\n{player1.Name}'s turn:");
            do
            {
                Console.WriteLine("1. Rock\n2. Paper\n3. Scissors\nEnter your choice (1-3): ");
                holder = Console.ReadLine();
                TryParseInput(holder, out player1.Choices);
            }while(player1.Choices <= 0 || player1.Choices > 3);

            if(Mode == 1)
                {
                    Console.WriteLine($"\nRound {i + 1}:\n{player2.Name}'s turn:");
                    player2.Name = "Computer";
                    player2.Choices = rnd.Next(1,4);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\nRound {i + 1}:\n{player2.Name}'s turn:");

                do
                {
                Console.WriteLine("1. Rock\n2. Paper\n3. Scissors\nEnter your choice (1-3): ");
                holder = Console.ReadLine();
                TryParseInput(holder, out player2.Choices);
                }while(player2.Choices <= 0 || player2.Choices > 3);

                }
                    Console.WriteLine($"\nRound Summary: ");
                    Console.WriteLine($"{player1.Name} chose: {player1.Choices}");
                    Console.WriteLine($"{player2.Name} chose: {player2.Choices}");
                    DetermineWinner(player1.Choices, player2.Choices);
            }
    }

    public void DetermineWinner(int choice1, int choice2)
    {
        if(choice1 == choice2)
        {
            Console.WriteLine("It's a tie!");
            }else if( (choice1 ==  1 && choice2 ==3) || (choice1 == 2 && choice2 == 1) || (choice1 == 3 && choice2 == 2))
        {
            Console.WriteLine($"{player1.Name} wins this round!");
            player1.Score++;
        }else
        {
            Console.WriteLine($"{player2.Name} wins this round!");
            player2.Score++;
        }
    }


    public void DisplayResults()
    {
        Console.WriteLine($"\nFinal Scores:\n{player1.Name}: {player1.Score}\n{player2.Name}: {player2.Score}");
        if(player1.Score > player2.Score)
        {
            Console.WriteLine($"{player1.Name} wins the game with a score of {player1.Score}!");
        }
        else if(player2.Score > player1.Score)
        {
            Console.WriteLine($"{player2.Name} wins the game with a score of {player2.Score}!");
        }
        else
        {
            Console.WriteLine("The game is a tie!");
        }
    }

    public void TryParseInput( string holder, out int result)
    {
        if (!int.TryParse( holder, out result))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            result = 0; 
        }
    }


}