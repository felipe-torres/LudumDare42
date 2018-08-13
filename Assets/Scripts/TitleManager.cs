using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DoodleStudio95;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public void LoadGame()
	{
		AppManager.Instance.LoadScene(1);
	}
}
