using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinLose : MonoBehaviour
{
    [SerializeField]
    Button btnPlayAgain;
    [SerializeField]
    Button btnExit;
    [SerializeField]
    TextMeshProUGUI message;


    private void Start()
    {
        //Reload gameplay
        btnPlayAgain.onClick.AddListener(()=>{
            GameManager.Instance.GetLevelManager.LoadScene(1);
        });

        //Back main menu
        btnExit.onClick.AddListener(()=>{
            GameManager.Instance.GetLevelManager.LoadScene(0);
        });
    }

    private void OnEnable()
    {
        message.text = GameManager.Instance.CurrentGameMode.WinGame ? "You won!" : "Game Over";
    }
}
