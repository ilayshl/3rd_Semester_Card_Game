using System;
using UnityEngine;

/// <summary>
/// Unused for now.
/// </summary>
public class PlayerInputListener : MonoBehaviour
{
    public Action<PlayerData> OnInputPress;
    public KeyCode PlayerInput { get => input; }
    [SerializeField] private KeyCode input;
    private PlayerData playerData;

    void Awake()
    {
        playerData = GetComponent<PlayerData>();
    }

    void Update()
    {
        if (Input.GetKeyDown(input))
        {
            OnInputPress?.Invoke(playerData);
            Debug.Log($"[{gameObject.name}] Input pressed");
        }
    }
}
