
public struct TilePassedTriggerEvent { }

public struct TileDeleteEvent { }



public struct GameStatusChangedEvent
{
    public GameStatus NewStatus;

    public GameStatusChangedEvent(GameStatus newStatus)
    {
        NewStatus = newStatus;
    }
}



public struct ScoreChangedEvent
{
    public int NewScore;

    public ScoreChangedEvent(int newScore)
    {
        NewScore = newScore;
    }
}

public struct LevelChangedEvent
{
    public int NewLevel;
    public LevelChangedEvent(int nextLevel)
    {
        NewLevel = nextLevel;
    }
}

public struct HealthChangedEvent
{
    public int CurrentHealth;

    public HealthChangedEvent(int currentHealth)
    {
        CurrentHealth = currentHealth;
    }
}

