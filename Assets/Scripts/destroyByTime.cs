using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByTime : MonoBehaviour
{
    public float time;
    void Start()
    {
        StartCoroutine(destroyCo());
    }

    public IEnumerator destroyCo()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
