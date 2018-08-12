using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TouchScript.Gestures;
using TouchScript;

public class Wall : MonoBehaviour
{
    public TapGesture tap;
    public Direction direction;
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
        print("Tapped! " + direction);
        GameManager.Instance.ReceiveInput(direction);
    }
}
