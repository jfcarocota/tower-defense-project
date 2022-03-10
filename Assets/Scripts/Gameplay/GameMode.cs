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
    UpgradeSystem upgradeSystem;
    [SerializeField]
    Spawner spawner;

    /// <summary>
    /// This basically is the Player
    /// </summary>
    public Base GetCurrentBase => currentBase;
    /// <summary>
    /// The UI Health Bar in the game
    /// </summary>
    public HealthBar GetHealthBar => healthBar;
    /// <summary>
    /// The UI Score in the game
    /// </summary>
    public Score GetScore => score;
    /// <summary>
    /// Returns the Upgrame stuffs for check if upgrade is available
    /// </summary>
    public UpgradeSystem GetUpgradeSystem => upgradeSystem;
    /// <summary>
    /// It's job is spawn enemis and tell you about the Horde
    /// </summary>
    public Spawner GetSpawner => spawner;

    //Need know if I can still playing the game
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

    /// <summary>
    /// Literaly checks if I Won
    /// </summary>
    public bool WinGame => spawner.BossDefeated && !currentBase.ImDead;

    //Starts after boss created
    private IEnumerator Start()
    {

        while(true)
        {
            if(!spawner.BossDefeated)
            {
                GameManager.Instance.CurrentGameMode = this;
                StartCoroutine(CheckGameplayStatus());
                break;
            }
            yield return null;
        }
    }
}
