using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public bool onRestart;
    public bool onMenu;

    public AudioSource clickSound;
    public AudioSource hoverSound;

    public int levelToLoad;
    public int menuToLoad;

    private stats sT;

    void Start()
    {
        onRestart = false;
        onMenu = false;
        sT = FindObjectOfType<stats>();
    }

    void Update()
    {
        if (onRestart == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            sT.score = 0;
            sT.time = 0;
            SceneManager.LoadScene(levelToLoad);
            clickSound.Play();
        }
        if (onMenu == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(sT.gameObject);
            SceneManager.LoadScene(menuToLoad);
            clickSound.Play();
        }
    }
    void OnMouseEnter()
    {
        hoverSound.Play();
    }
    void OnMouseOver()
    {
        if (this.gameObject.tag == "Restart")
        {
            onRestart = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
        if (this.gameObject.tag == "Menu")
        {
            onMenu = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }
    void OnMouseExit()
    {
        if (this.gameObject.tag == "Restart")
        {
            onRestart = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (this.gameObject.tag == "Menu")
        {
            onMenu = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
