using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    List<GameObject> towers;
    [SerializeField]
    Queue<GameObject> towersQueue;
    [SerializeField, Range(0.1f, 10f)]
    float upgradeRate;
    Queue<GameObject> nextUpgrade;
    [SerializeField]
    UpgradeUI upgradeUI;

    private void Start()
    {
        nextUpgrade = new Queue<GameObject>();
        towersQueue = new Queue<GameObject>(towers);
        StartCoroutine(CheckForUpgrades());
        /*while(true)
        {
            if(!GameManager.Instance.CurrentGameMode.GetSpawner.BossDefeated)
            {
                StartCoroutine(CheckForUpgrades());
                break;
            }
            yield return null;
        }*/
    }

    int upgradesAvailable;
    IEnumerator CheckForUpgrades()
    {
        yield return new WaitForSeconds(upgradeRate);
        Debug.Log("hi");
        if(!MaxLevel)
        {
            upgradeUI.gameObject.SetActive(true);
            nextUpgrade.Enqueue(towersQueue.Dequeue());
            StartCoroutine(CheckForUpgrades());
        }
    }

    public bool MaxLevel => towersQueue.Count == 0;
    public bool UpgradesAvailables => nextUpgrade.Count > 0;
    public GameObject GetNextUpgrade => nextUpgrade.Dequeue();
}
