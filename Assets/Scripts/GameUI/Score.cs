using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

}
