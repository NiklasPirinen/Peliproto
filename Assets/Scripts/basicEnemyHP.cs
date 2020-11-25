using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyHP : MonoBehaviour
{
    public float health;

    public bool immune;
    public float immunityTime;

    public Sprite normal;
    public Sprite hurt;

    public GameObject nameObject;
    public GameObject deathParticle;

    const float sDropChance = 1f / 5f;
    public GameObject speedPickUp;

    const float fDropChance = 1f / 7f;
    public GameObject fireRatePickUp;

    const float hDropChance = 1f / 3f;
    public GameObject healthPickUp;

    private stats sT;
    private spawnManager sM;
    private spawnManager2 sM2;

    public AudioSource eHit;
    public AudioSource mHit;
    public AudioSource bHit;

    public AudioSource eDeath;
    public AudioSource mDeath;
    public AudioSource bDeath;

    public float deathTime;
    public bool hasDied;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        sT = FindObjectOfType<stats>();
        sM = FindObjectOfType<spawnManager>();
        sM2 = FindObjectOfType<spawnManager2>();

        hasDied = false;
    }

    void Update()
    {
        if(health <= 0 && this.gameObject.tag == "BasicEnemy")
        {
            if(hasDied == false)
            {
                sT.score += 200;
                health = 0;
                Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                nameObject.SetActive(false);
                eDeath.Play();
                if (Random.Range(0f, 1f) <= sDropChance)
                {
                    Instantiate(speedPickUp, this.gameObject.transform.position, this.gameObject.transform.rotation);
                }
                sM.spawnInterval -= 0.03f;
                sM2.spawnInterval -= 0.03f;
                hasDied = true;
            }
            StartCoroutine(deathDelay());
        }
        if (health <= 0 && this.gameObject.tag == "MagicEnemy")
        {
            if(hasDied == false)
            {
                sT.score += 300;
                health = 0;
                Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                nameObject.SetActive(false);
                mDeath.Play();
                if (Random.Range(0f, 1f) <= fDropChance)
                {
                    Instantiate(fireRatePickUp, this.gameObject.transform.position, this.gameObject.transform.rotation);
                }
                sM.spawnInterval -= 0.03f;
                sM2.spawnInterval -= 0.03f;
                hasDied = true;
            }
            StartCoroutine(deathDelay());
        }
        if (health <= 0 && this.gameObject.tag == "Boss")
        {
            if(hasDied == false)
            {
                sT.score += 1000;
                health = 0;
                Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                nameObject.SetActive(false);
                bDeath.Play();
                if (Random.Range(0f, 1f) <= hDropChance)
                {
                    Instantiate(healthPickUp, this.gameObject.transform.position, this.gameObject.transform.rotation);
                }
                hasDied = true;
            }
            StartCoroutine(deathDelay());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if((col.tag == "BulletPhysical") && immune == false && this.gameObject.tag == "BasicEnemy")
        {
            eHit.Play();
            StartCoroutine(immunityCo());
        }
        if ((col.tag == "BulletMagic") && immune == false && this.gameObject.tag == "MagicEnemy")
        {
            mHit.Play();
            StartCoroutine(immunityCo());
        }
        if ((col.tag == "BulletSpecial") && immune == false && this.gameObject.tag == "Boss")
        {
            bHit.Play();
            StartCoroutine(immunityCo());
        }
    }

    public IEnumerator immunityCo()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hurt;
        health -= 1;
        immune = true;
        yield return new WaitForSeconds(immunityTime);
        immune = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
    }
    public IEnumerator deathDelay()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
