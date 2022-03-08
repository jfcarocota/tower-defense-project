using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField]
    Score score;
    [SerializeField]
    HealthBar healthBar;
    [SerializeField]
    Base currentBase;

    public Base GetCurrentBase => currentBase;

    private void Start()
    {
        GameManager.Instance.CurrentGameMode = this;
    }
}
