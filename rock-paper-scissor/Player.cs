class Player
{
    private string name; 
    private int score;
    private int choices;

    // Properties 

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Score
    {
        get { return score; }
        set { if (value < 0 ) score = 0; else score = value; }
    }

    public int Choices //HERE
    {
        get { return choices; }
        set { if (value < 1 || value > 3) choices = 0; else choices = value;}
    }

    // Constructor
    public Player (string _name, int _score, int _choices)
    {
        Name = _name;
        Score = _score;
        Choices = _choices;
    }


}