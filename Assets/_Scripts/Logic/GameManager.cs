using System;
using UnityEngine;

/// <summary>
/// Unused for now.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Action<GameState> OnGameStateChanged;
    public GameState state;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;

        //Awake logic
    }

    public void ChangeGameState(GameState newState = GameState.Active)
    {
        /* switch (newState)
        {
         
        } */
    }

}
