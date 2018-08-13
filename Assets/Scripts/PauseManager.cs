using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DoodleStudio95;

public class PauseManager : MonoBehaviour
{
	public Button PauseButton;
	public CanvasGroup PauseMenu;
	public DoodleAnimationFile a;

    public void Pause()
	{
		PauseMenu.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void Play()
	{	
		PauseMenu.gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void Title()
	{
		Time.timeScale = 1;
		AppManager.Instance.LoadScene(0);
	}
}
