using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	public bool paused = false;
	private stats sT;

	void Start()
	{
		PauseUI.SetActive(false);
		sT = FindObjectOfType<stats>();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Pause"))
		{
			paused = !paused;
		}

		if (paused)
		{
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused)
		{
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}
	public void Resume()
	{
		paused = false;
	}

	public void Restart()
	{
		sT.score = 0;
		sT.time = 0;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenu()
	{
		Destroy(sT.gameObject);
		Application.LoadLevel(0);
		paused = !paused;
	}
}
