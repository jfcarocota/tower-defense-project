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
            if(WinGame || currentBase.ImDead)
            {
                winLose.gameObject.SetActive(true);
                break;
            }
            yield return null;
        }
    }

    public bool WinGame => spawner.GetBossClone == null && !currentBase.ImDead;

    private IEnumerator Start()
    {

        while(true)
        {
            if(spawner.GetBossClone != null)
            {
                GameManager.Instance.CurrentGameMode = this;
                StartCoroutine(CheckGameplayStatus());
                break;
            }
            yield return null;
        }
    }
}
