using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUps : MonoBehaviour
{
    private playerController pC;

    //Speed buff
    //public float sBuffDuration;

    //Fire rate buff
    //public float fBuffDuration;

    //Particles
    public GameObject sParticle;
    public GameObject fParticle;
    public GameObject hParticle;

    public float waitTime;

    void Start()
    {
        pC = FindObjectOfType<playerController>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && this.gameObject.tag == "SpeedPickUp")
        {
            Instantiate(sParticle, gameObject.transform.position, gameObject.transform.rotation);
            //pC.speedBuff = true;
            pC.sBuffDuration += 5;
            Destroy(gameObject);
        }
        if (col.tag == "Player" && this.gameObject.tag == "FireRatePickUp")
        {
            Instantiate(fParticle, gameObject.transform.position, gameObject.transform.rotation);
            //pC.fireRateBuff = true;
            pC.fBuffDuration += 4;
            Destroy(gameObject);
        }
        if (col.tag == "Player" && this.gameObject.tag == "HPPickUp")
        {
            pC.health += 1;
            Instantiate(hParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
