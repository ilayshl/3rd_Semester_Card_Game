public enum GameState
{
    MainMenu,
    Settings,
    Pause,
    WaitingForInput,
    Active,
    WarSequence,
    FloatMinigame,
    GameOver,
}

public enum WarGameState
{
    Inactive,
    DrawCards,
    Evaluate,
    PlayerOneWon,
    PlayerTwoWon,
}

public enum MinigameState
{
    Arranging,
    Playing,
    PlayerOneWon,
    PlayerTwoWon,
    Finish,
}