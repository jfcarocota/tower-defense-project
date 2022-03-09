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

    public GameMode CurrentGameMode {get => gameMode; set => gameMode = value;}
    public LevelManager GetLevelManager => levelManager;
}
