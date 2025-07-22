using System;
using UnityEngine;

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

    public void ChangeGameState(GameState newState = GameState.WaitingForInput)
    {
        switch (newState)
        {
        
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
