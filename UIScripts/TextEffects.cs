using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TextEffects : MonoBehaviour {

    [SerializeField] Text text;
    [SerializeField] float time;

	void Start () {

        text = GetComponent<Text>();
	}

    public void FadeIn()
    {
        StartCoroutine(FadeTextToFullAlpha(time, text));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeTextToZeroAlpha(time, text));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
