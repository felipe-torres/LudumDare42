using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DoodleStudio95;

public class Mime : MonoBehaviour
{
    public Queue<Direction> OrderList;

    public GameObject Model;
    public Rigidbody[] Joints;
    public Transform Head;
    //public DoodleAnimator FaceAnimator;

    //public DoodleAnimationFile[] Faces;
    public MeshRenderer FaceRenderer;
    public Texture2D[] Faces;
    public Texture2D DeadFace;


    public Wall UpWall;
    public Wall RightWall;
    public Wall DownWall;
    public Wall LeftWall;


    private void Awake()
    {
        OrderList = new Queue<Direction>();
        foreach (Rigidbody r in Joints)
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
        UpWall.ActivateCue();
        OrderList.Enqueue(Direction.Up);
    }
    public void Right()
    {
        RightWall.ActivateCue();
        OrderList.Enqueue(Direction.Right);
    }

    public void Down()
    {
        DownWall.ActivateCue();
        OrderList.Enqueue(Direction.Down);
    }

    public void Left()
    {
        LeftWall.ActivateCue();
        OrderList.Enqueue(Direction.Left);
    }

    public void SwitchFace(int index)
    {
        //FaceAnimator.ChangeAnimation(Faces[index]);}
        FaceRenderer.material.mainTexture = Faces[index];
    }

    public void SwitchToGoodFace()
    {
        SwitchFace(Random.Range(0, 3));
    }

    public void SwitchToBadFace()
    {
        SwitchFace(Random.Range(3, Faces.Length));
    }

    public void Dissappear()
    {
        StartCoroutine(DissappearSequence());
    }

    private IEnumerator DissappearSequence()
    {
        foreach (Rigidbody rb in Joints)
        {
            rb.isKinematic = true;
            //rb.transform.DOScale(0.5f, 0.5f).SetEase(Ease.InOutBounce);
        }
        
        Head.DORotate(new Vector3(Head.rotation.x, 90f, -90f), 0.25f);
        FaceRenderer.material.mainTexture = DeadFace;

        yield return new WaitForSeconds(0.5f);

        foreach (Rigidbody rb in Joints)
        {
            rb.transform.DOScale(0.5f, 0.5f).SetEase(Ease.InOutBounce);
        }
        yield return new WaitForSeconds(0.5f);
        Model.SetActive(false);
    }


}
