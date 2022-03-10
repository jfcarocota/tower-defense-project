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

    //Init queues
    private void Start()
    {
        nextUpgrade = new Queue<GameObject>();
        towersQueue = new Queue<GameObject>(towers);
        StartCoroutine(CheckForUpgrades());
    }

    int upgradesAvailable;

    //Check if exist new tower to enable
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

    /// <summary>
    /// Check if is posibble still creating towers
    /// </summary>
    public bool MaxLevel => towersQueue.Count == 0;
    /// <summary>
    /// Check if I canck activate a new tower
    /// </summary>
    public bool UpgradesAvailables => nextUpgrade.Count > 0;
    /// <summary>
    /// Returns the nex upgrade
    /// </summary>
    /// <returns></returns>
    public GameObject GetNextUpgrade => nextUpgrade.Dequeue();
}
