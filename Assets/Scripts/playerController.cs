using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public Transform firePos;
    public GameObject bullet;
    public GameObject mBullet;
    public GameObject sBullet;

    public AudioSource pSound;
    public AudioSource mSound;
    public AudioSource sSound;

    public float fireCd;
    public float fireRate;

    public float mFireCd;
    public float mFireRate;

    public float sFireCd;
    public float sFireRate;

    public const float drain = 1f;

    public float speed;
    public float horizontalInput;
    public float verticalInput;

    public bool onPhysical;
    public bool onMagic;
    public bool onSpecial;
    public Transform physicalPos;
    public Transform magicPos;
    public Transform specialPos;
    public GameObject arrowObject;

    public Text healthText;
    public Text bulletText;
    public float health;

    public AudioSource hitSound;
    public bool immune;
    public float immunityTime;

    public Sprite normal;
    public Sprite hurt;

    public bool onEnemy;
    public bool onBoss;

    public float waitTime;
    public GameObject deathParticle;
    public int levelToLoad;
    public bool deathParticleSpawned;
    public bool atZero;
    public AudioSource deathSound;

    //public bool speedBuff;
    //public bool fireRateBuff;
    public Image sBuffIcon;
    public Image fBuffIcon;

    //Speed buff
    public float sBuffDuration;

    //Fire rate buff
    public float fBuffDuration;

    public AudioSource sPick;
    public AudioSource fPick;
    public AudioSource hPick;

    public AudioSource switchSound;

    private pauseMenu pM;
    void Start()
    {
        fireCd = 0f;
        mFireCd = 0f;
        sFireCd = 0f;

        fireRate = 0.15f;
        mFireRate = 0.25f;
        sFireRate = 0.4f;

        onPhysical = true;
        onMagic = false;
        onSpecial = false;
        onEnemy = false;
        onBoss = false;
        deathParticleSpawned = false;

        atZero = false;

        sBuffIcon.enabled = false;
        fBuffIcon.enabled = false;

        pM = FindObjectOfType<pauseMenu>();
    }

    void Update()
    {
        fireCd -= drain * Time.deltaTime;
        mFireCd -= drain * Time.deltaTime;
        sFireCd -= drain * Time.deltaTime;

        healthText.text = "Health: " + health.ToString("F0");

        if (fireCd <= 0)
        {
            fireCd = 0;
        }
        if (fireCd >= fireRate)
        {
            fireCd = fireRate;
        }
        if (mFireCd <= 0)
        {
            mFireCd = 0;
        }
        if (mFireCd >= mFireRate)
        {
            mFireCd = mFireRate;
        }
        if (sFireCd <= 0)
        {
            sFireCd = 0;
        }
        if (sFireCd >= sFireRate)
        {
            sFireCd = sFireRate;
        }

        //Shoot bullet
        if (Input.GetKey(KeyCode.Mouse0) && onPhysical == true && fireCd == 0 && atZero == false && pM.paused == false)
        {
            Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            pSound.Play();
            fireCd += fireRate;
        }
        //Shoot magic
        if(Input.GetKey(KeyCode.Mouse0) && onMagic == true && mFireCd == 0 && atZero == false && pM.paused == false)
        {
            Instantiate(mBullet, firePos.transform.position, firePos.transform.rotation);
            mSound.Play();
            mFireCd += mFireRate;
        }
        //Shoot special
        if (Input.GetKey(KeyCode.Mouse0) && onSpecial == true && sFireCd == 0 && atZero == false && pM.paused == false)
        {
            Instantiate(sBullet, firePos.transform.position, firePos.transform.rotation);
            sSound.Play();
            sFireCd += sFireRate;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);

        if (onPhysical == false && Input.GetKeyDown(KeyCode.Alpha1) && pM.paused == false)
        {
            switchSound.Play();
            onPhysical = true;
            onMagic = false;
            onSpecial = false;
        }
        if (onMagic == false && Input.GetKeyDown(KeyCode.Alpha2) && pM.paused == false)
        {
            switchSound.Play();
            onPhysical = false;
            onMagic = true;
            onSpecial = false;
        }
        if (onSpecial == false && Input.GetKeyDown(KeyCode.Alpha3) && pM.paused == false)
        {
            switchSound.Play();
            onPhysical = false;
            onMagic = false;
            onSpecial = true;
        }

        if(onPhysical == true)
        {
            arrowObject.transform.position = physicalPos.transform.position;
            bulletText.text = "Bullet type: Physical";
        }
        if (onMagic == true)
        {
            arrowObject.transform.position = magicPos.transform.position;
            bulletText.text = "Bullet type: Magic";
        }
        if (onSpecial == true)
        {
            arrowObject.transform.position = specialPos.transform.position;
            bulletText.text = "Bullet type: Special";
        }

        if(health >= 5)
        {
            health = 5;
        }
        if(health > 0)
        {
            atZero = false;
        }
        if(health <= 0)
        {
            atZero = true;
            if(deathParticleSpawned == false)
            {
                deathSound.Play();
                Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
                deathParticleSpawned = true;
            }
            health = 0;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            speed = 0;
            StartCoroutine(deathCo());
        }

        if (onEnemy == true && immune == false)
        {
            StartCoroutine(immunityCoE());
        }
        if (onBoss == true && immune == false)
        {
            StartCoroutine(immunityCoB());
        }

        sBuffDuration -= drain * Time.deltaTime;
        fBuffDuration -= drain * Time.deltaTime;

        if(sBuffDuration > 0)
        {
            sBuffIcon.enabled = true;
            speed = 6.5f;
        }
        if(sBuffDuration >= 5)
        {
            sBuffDuration = 5;
        }
        if(sBuffDuration <= 0)
        {
            sBuffDuration = 0;
            sBuffIcon.enabled = false;
            speed = 3.5f;
        }
        if (fBuffDuration > 0)
        {
            fBuffIcon.enabled = true;
            fireRate = 0.075f;
            mFireRate = 0.15f;
            sFireRate = 0.275f;
        }
        if(fBuffDuration >= 4)
        {
            fBuffDuration = 4;
        }
        if (fBuffDuration <= 0)
        {
            fBuffDuration = 0;
            fBuffIcon.enabled = false;
            fireRate = 0.15f;
            mFireRate = 0.25f;
            sFireRate = 0.4f;
        }
    }
    //public IEnumerator speedBuffCo()
    //{
    //    yield return new WaitForSeconds(sBuffDuration);
    //    speedBuff = false;
    //}
    //public IEnumerator fireRateBuffCo()
    //{
    //    yield return new WaitForSeconds(fBuffDuration);
    //    fireRateBuff = false;
    //}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "BasicEnemy" || col.tag == "MagicEnemy")
        {
            onEnemy = true;
        }
        if (col.tag == "Boss")
        {
            onBoss = true;
        }
        if(col.tag == "SpeedPickUp")
        {
            sPick.Play();
        }
        if (col.tag == "FireRatePickUp")
        {
            fPick.Play();
        }
        if (col.tag == "HPPickUp")
        {
            hPick.Play();
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "BasicEnemy" || col.tag == "MagicEnemy")
        {
            onEnemy = true;
        }
        if (col.tag == "Boss")
        {
            onBoss = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "BasicEnemy" || col.tag == "MagicEnemy")
        {
            onEnemy = false;
        }
        if (col.tag == "Boss")
        {
            onBoss = false;
        }
    }
    public IEnumerator immunityCoE()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hurt;
        hitSound.Play();
        health -= 1;
        immune = true;
        yield return new WaitForSeconds(immunityTime);
        immune = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
    }
    public IEnumerator immunityCoB()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hurt;
        hitSound.Play();
        health -= 2;
        immune = true;
        yield return new WaitForSeconds(immunityTime);
        immune = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
    }
    private IEnumerator deathCo()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelToLoad);
    }
}
