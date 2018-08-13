using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleWords : MonoBehaviour
{
    public Image[] Sentence1;
    public Image[] Sentence2;
    public Image[] Sentence3;

    void Start()
    {
        // Hide all words
        HideAllWords(Sentence1);
        HideAllWords(Sentence2);

        // Show words
        StartCoroutine(SentenceSeq());
    }

    private IEnumerator SentenceSeq()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(ShowSentenceSeq(Sentence1));
            yield return new WaitForSeconds(2f);
            StartCoroutine(ShowSentenceSeq(Sentence2));
        }
    }

    private IEnumerator ShowSentenceSeq(Image[] sentence)
    {
        foreach (Image word in sentence)
        {
            word.DOFade(Random.Range(0.5f, 1.0f), 0.5f).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void HideAllWords(Image[] sentence)
    {
        foreach (Image word in sentence)
        {
            word.DOFade(0f, 0f);
        }
    }

}
