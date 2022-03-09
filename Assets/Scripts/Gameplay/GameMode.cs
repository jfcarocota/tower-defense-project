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
    public HealthBar GetHealthBar => healthBar;
    public Score GetScore => score;

    private void Start()
    {
        GameManager.Instance.CurrentGameMode = this;
    }
}
