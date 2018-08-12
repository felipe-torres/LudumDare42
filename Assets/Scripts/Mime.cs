using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Mime : MonoBehaviour
{
    public Image sprite;

    public Queue<Direction> OrderList;
    public Rigidbody[] Joints;


    private void Awake()
    {
        OrderList = new Queue<Direction>();
        foreach(Rigidbody r in Joints)
        {
            r.maxDepenetrationVelocity = 60f;
        }
    }

    public void Decide()
    {
        StartCoroutine(DecideSequence());
    }

    private IEnumerator DecideSequence()
    {
        OrderList.Clear(); // TEMP!!!

        sprite.transform.DOPunchScale(Vector3.one * 0.5f, 0.5f);
        int r = Random.Range(0, 4);
        switch (r)
        {
            case 0:
                Up();
                break;
            case 1:
                Right();
                break;
            case 2:
                Down();
                break;
            case 3:
                Left();
                break;
        }
		yield return null;
    }

    public void Up()
    {
        sprite.transform.DORotate(Vector3.forward * 180f, 0.5f).SetEase(Ease.InOutBack);
        OrderList.Enqueue(Direction.Up);
    }
    public void Right()
    {
        sprite.transform.DORotate(Vector3.forward * 90f, 0.5f).SetEase(Ease.InOutBack);
        OrderList.Enqueue(Direction.Right);
    }

    public void Down()
    {
        sprite.transform.DORotate(Vector3.forward * 0f, 0.5f).SetEase(Ease.InOutBack);
        OrderList.Enqueue(Direction.Down);
    }

    public void Left()
    {
        sprite.transform.DORotate(Vector3.forward * -90f, 0.5f).SetEase(Ease.InOutBack);
        OrderList.Enqueue(Direction.Left);
    }


}
