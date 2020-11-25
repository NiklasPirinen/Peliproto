using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mute : MonoBehaviour
{
    public AudioSource bgm;
    public bool muted;
    public Sprite mutedS;
    public Sprite unmutedS;

    void Start()
    {

    }

    void Update()
    {
        if (muted)
        {
            bgm.volume = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = mutedS;
        }
        if (!muted)
        {
            bgm.volume = 0.3f;
            gameObject.GetComponent<SpriteRenderer>().sprite = unmutedS;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            muted = !muted;
        }
    }
}
