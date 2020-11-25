using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public float score;

    public const float drain = 1f;
    public float time;

    private playerController pC;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        pC = FindObjectOfType<playerController>();
    }

    void Update()
    {
        if(Application.loadedLevel == 1)
        {
            time += drain * Time.deltaTime;
        }
    }
}
