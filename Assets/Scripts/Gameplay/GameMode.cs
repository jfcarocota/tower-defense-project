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
    [SerializeField]
    WinLose winLose;
    [SerializeField]
    Spawner spawner;

    public Base GetCurrentBase => currentBase;
    public HealthBar GetHealthBar => healthBar;
    public Score GetScore => score;

    IEnumerator CheckGameplayStatus()
    {
        while(true)
        {
            if(WinGame || LoseGame)
            {
                winLose.gameObject.SetActive(true);
                break;
            }
            yield return null;
        }
    }

    public bool WinGame => spawner.GetEnemiesQueue.Count == 0;
    public bool LoseGame => currentBase.GetHealth == 0;

    private void Start()
    {
        GameManager.Instance.CurrentGameMode = this;
        StartCoroutine(CheckGameplayStatus());
    }
}
