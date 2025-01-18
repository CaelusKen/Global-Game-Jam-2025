using System.Collections;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public CanvasGroup fadePanel => GetComponent<CanvasGroup>();
    public float fadeDuration = 3f;

    public void FadeOut()
    {
        StartCoroutine(Fade(1, 0));
    }
    public void FadeIn()
    {
        StartCoroutine(Fade(0, 1));
    }
    IEnumerator Fade(float start, float end)
    {
        float elapsed = 0f;
        //fadePanel.alpha = Mathf.Lerp(start, start, elapsed / fadeDuration);
        //elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            fadePanel.alpha = Mathf.MoveTowards(start, end, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        fadePanel.alpha = end;
    }
}
