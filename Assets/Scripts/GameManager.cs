using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum Direction { Up, Right, Down, Left }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Mime mime;
    public RectTransform Box;
    public enum State { Idle, AwaitingInput, GameOver }
    public State state = State.Idle;
    public float StartTime = 5f;
    private Coroutine timer;
    public float BoxStep = 80f;

    private int[] StepCounters;


    // UI
    public Text Counter;



    private void Awake()
    {
        Instance = this;
        StepCounters = new int[4];
    }

    public void Start()
    {
        StartCoroutine(GameLoop());
    }

    public IEnumerator GameLoop()
    {
        // Receive order from mime
        mime.Decide();

        // Start order timer
        timer = StartCoroutine(TimerSequence());
        yield return timer;
    }

    public void ReceiveInput(Direction d)
    {
        // Stop time sequence
        StopCoroutine(timer);

        // Check input correctness
        print("Compare:" + mime.OrderList.Peek());
        if (mime.OrderList.Peek() == d)
        {
            print("correct!");
            GrowBox(d);
        }
        else
        {
            print("incorrect!");
            ShrinkBox(d);
        }

        // New Game Loop
        StartCoroutine(GameLoop());
    }

    public IEnumerator TimerSequence()
    {
        float time = StartTime;
        while (time > 0)
        {
            Counter.text = time.ToString();
            time -= 1;
            yield return new WaitForSeconds(1f);
        }

        // Failed to input in given time, shrink box!
        ShrinkBox();
        StartCoroutine(GameLoop());
    }

    public void ShrinkBox()
    {
        Box.DOSizeDelta(Box.sizeDelta - Vector2.one * BoxStep, 1f);

        // Check game end
    }

    public void ShrinkBox(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                StepCounters[0]++; 
                DOTween.To(() => Box.offsetMax, x => Box.offsetMax = x, 
                    new Vector2(Box.offsetMax.x, -BoxStep*StepCounters[0]), 1f);
                break;
            case Direction.Right:
                StepCounters[1]++;
                DOTween.To(() => Box.offsetMax, x => Box.offsetMax = x, 
                    new Vector2(-BoxStep*StepCounters[1], Box.offsetMax.y), 1f);
                break;
            case Direction.Down:
                StepCounters[2]++;
                DOTween.To(() => Box.offsetMin, x => Box.offsetMin = x, 
                    new Vector2(Box.offsetMin.x, BoxStep*StepCounters[2]), 1f);
                break;
            case Direction.Left:
                StepCounters[3]++;
                DOTween.To(() => Box.offsetMin, x => Box.offsetMin = x, 
                    new Vector2(BoxStep*StepCounters[3], Box.offsetMin.y), 1f);
                break;
        }
    }

    public void GrowBox(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                if ((StepCounters[0]-1)*BoxStep < 0) break;
                StepCounters[0]--;
                DOTween.To(() => Box.offsetMax, x => Box.offsetMax = x, new Vector2(Box.offsetMax.x, Box.offsetMax.y + BoxStep), 1f);
                break;
            case Direction.Right:
                if ((StepCounters[1]-1)*BoxStep < 0) break;
                StepCounters[1]--;
                DOTween.To(() => Box.offsetMax, x => Box.offsetMax = x, new Vector2(Box.offsetMax.x + BoxStep, Box.offsetMax.y), 1f);
                break;
            case Direction.Down:
                if ((StepCounters[2]-1)*BoxStep < 0) break;
                StepCounters[2]--;
                DOTween.To(() => Box.offsetMin, x => Box.offsetMin = x, new Vector2(Box.offsetMin.x, Box.offsetMin.y - BoxStep), 1f);
                break;
            case Direction.Left:
                if ((StepCounters[3]-1)*BoxStep < 0) break;
                StepCounters[3]--;
                DOTween.To(() => Box.offsetMin, x => Box.offsetMin = x, new Vector2(Box.offsetMin.x - BoxStep, Box.offsetMin.y), 1f);
                break;
        }
    }
}
