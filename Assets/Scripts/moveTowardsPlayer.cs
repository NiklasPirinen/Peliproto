using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardsPlayer : MonoBehaviour
{
    public float speed;
    private playerController pC;

    void Start()
    {
        pC = FindObjectOfType<playerController>();
    }

    void Update()
    {
        if(pC.atZero == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, pC.transform.position, speed * Time.deltaTime);
        }
    }
}
