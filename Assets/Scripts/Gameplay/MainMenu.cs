using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button btnPlayGame;
    [SerializeField]
    Button btnQuitGame;

    private void Start()
    {
        //Load gameplay
        btnPlayGame.onClick.AddListener(()=>{
            GameManager.Instance.GetLevelManager.LoadScene(1);
        });

        //Quit app
        btnQuitGame.onClick.AddListener(()=>{
            Application.Quit();
        });
    }

}
