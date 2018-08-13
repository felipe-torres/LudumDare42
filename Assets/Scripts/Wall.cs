using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using TouchScript.Gestures;
using TouchScript;

public class Wall : MonoBehaviour
{
    public TapGesture tap;
    public Direction direction;

    public Image Visual;

    private void OnEnable()
    {
        tap.Tapped += TapHandler;
    }

    private void OnDisable()
    {
        tap.Tapped -= TapHandler;
    }

    public void TapHandler(object sender, EventArgs e)
    {
        //print("Tapped! " + direction);
        GameManager.Instance.ReceiveInput(direction);
    }

    public void ActivateCue()
    {
        DOTween.Kill("WallCue"+GetInstanceID());
        Visual.DOFade(1f, 0.5f).SetId("WallCue"+GetInstanceID());
        Visual.DOFade(0f, 0.5f).SetDelay(0.5f).SetId("WallCue"+GetInstanceID());
    }
}
