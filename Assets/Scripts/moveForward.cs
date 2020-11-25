using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    public float speed;
    public GameObject pBulletHitParticle;
    public GameObject mBulletHitParticle;
    public GameObject sBulletHitParticle;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "BasicEnemy" && this.gameObject.tag == "BulletPhysical")
        {
            Instantiate(pBulletHitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (col.tag == "MagicEnemy" && this.gameObject.tag == "BulletMagic")
        {
            Instantiate(mBulletHitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (col.tag == "Boss" && this.gameObject.tag == "BulletSpecial")
        {
            Instantiate(sBulletHitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
