using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{
    private stats sT;
    public Text scoreText;
    public Text timeText;

    void Start()
    {
        sT = FindObjectOfType<stats>();
    }

    void Update()
    {
        scoreText.text = "Final score: " + sT.score.ToString("F0");
        timeText.text = "Total time: " + sT.time.ToString("F1");
    }
}
