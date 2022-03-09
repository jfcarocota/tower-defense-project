using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Load scenes by build index order
    public void LoadScene(int level) => SceneManager.LoadScene(level);
}
