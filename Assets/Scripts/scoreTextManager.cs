using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTextManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;

    private stats sT;

    void Start()
    {
        sT = FindObjectOfType<stats>();
    }

    void Update()
    {
        timeText.text = "Time: " + sT.time.ToString("F1");
        scoreText.text = "Score: " + sT.score.ToString("F0");
    }
}
