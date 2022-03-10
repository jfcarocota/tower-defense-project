using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    LevelManager levelManager;
    [SerializeField]
    GameMode gameMode;

    // Basically the Jesus Christ of the game, Just Call him in any place inside Gameplay Space.
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Returns a especial class who stores all important things of gameplay
    /// </summary>
    /// <value></value>
    public GameMode CurrentGameMode {get => gameMode; set => gameMode = value;}
    /// <summary>
    /// Returns a especial class for level loading
    /// </summary>
    public LevelManager GetLevelManager => levelManager;
}
