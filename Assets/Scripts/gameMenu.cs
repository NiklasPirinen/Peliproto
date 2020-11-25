using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMenu : MonoBehaviour
{
    public bool onStart;
    public bool onInfo;
    public bool onQuit;
    public bool onBack;
    public bool onNext;
    public bool onPrev;

    public AudioSource clickSound;
    public AudioSource hoverSound;

    public int levelToLoad;

    public Camera cam;
    public Transform camPos;

    void Start()
    {
        onStart = false;
        onInfo = false;
        onQuit = false;
        onBack = false;
        onNext = false;
        onPrev = false;
    }

    void Update()
    {
        if(onStart == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(levelToLoad);
            clickSound.Play();
        }
        if(onInfo == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            cam.transform.position = camPos.transform.position;
            clickSound.Play();
        }
        if(onQuit == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Application.Quit();
            clickSound.Play();
        }
        if(onBack == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            cam.transform.position = new Vector3(0, 0, -10);
            clickSound.Play();
        }
        if (onNext == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            cam.transform.position = new Vector3(64, 0, -10);
            clickSound.Play();
        }
        if (onPrev == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            cam.transform.position = new Vector3(32, 0, -10);
            clickSound.Play();
        }
    }
    void OnMouseEnter()
    {
        hoverSound.Play();
    }
    void OnMouseOver()
    {
        if (this.gameObject.tag == "Start")
        {
            onStart = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
        if (this.gameObject.tag == "Info")
        {
            onInfo = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
        if (this.gameObject.tag == "Quit")
        {
            onQuit = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
        if (this.gameObject.tag == "Back")
        {
            onBack = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
        if (this.gameObject.tag == "Next")
        {
            onNext = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
        if (this.gameObject.tag == "Prev")
        {
            onPrev = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }
    void OnMouseExit()
    {
        if (this.gameObject.tag == "Start")
        {
            onStart = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (this.gameObject.tag == "Info")
        {
            onInfo = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (this.gameObject.tag == "Quit")
        {
            onQuit = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (this.gameObject.tag == "Back")
        {
            onBack = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (this.gameObject.tag == "Next")
        {
            onNext = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (this.gameObject.tag == "Prev")
        {
            onPrev = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
