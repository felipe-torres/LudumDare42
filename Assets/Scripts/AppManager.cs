using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DoodleStudio95;

// App Manager, active through all game
public class AppManager : MonoBehaviour
{
	public static AppManager Instance;

	public GraphicRaycaster raycaster;

	// Loading screen
	public DoodleAnimator Curtain;

	void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	public void LoadScene(int index)
	{
		StartCoroutine(LoadSceneSequence(index));
	}

	private IEnumerator LoadSceneSequence(int index)
	{
		raycaster.enabled = true;
		yield return Curtain.PlayAndPauseAt(0, 12);
		yield return SceneManager.LoadSceneAsync(index);
		yield return Curtain.PlayAndPauseAt(12, 0);
		raycaster.enabled = false;
	}
}
