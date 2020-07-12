using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image image;

    void Start()
    {
           
    }

    public void FadeOut(float time)
    {
        StartCoroutine(FadeOutRoutine(time));
    }

    IEnumerator FadeOutRoutine(float time)
    {
        float currentTime = 0f;
        while(currentTime < time)
        {
            image.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, currentTime/time));
            yield return null;
            currentTime += Time.deltaTime;
        }
        image.color = new Color(0f, 0f, 0f, 1f);
    }

    public void FadeIn(float time)
    {
        StartCoroutine(FadeInRoutine(time));
    }

    IEnumerator FadeInRoutine(float time)
    {
        float currentTime = 0f;
        while (currentTime < time)
        {
            image.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, currentTime / time));
            yield return null;
            currentTime += Time.deltaTime;
        }
        image.color = new Color(0f, 0f, 0f, 0f);
    }
}
