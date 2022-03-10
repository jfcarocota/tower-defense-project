using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField]
    Button btnUpgrade;

    private void Start()
    {
        btnUpgrade.onClick.AddListener(()=>{
            GameManager.Instance.CurrentGameMode.GetUpgradeSystem.GetNextUpgrade.SetActive(true);
            gameObject.SetActive(GameManager.Instance.CurrentGameMode.GetUpgradeSystem.UpgradesAvailables);
        });
    }
}
