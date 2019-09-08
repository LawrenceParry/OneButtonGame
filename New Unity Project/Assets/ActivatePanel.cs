using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivatePanel : MonoBehaviour
{
    RectTransform rect;
    [SerializeField] Image img;
    [SerializeField] Text txt;
    AudioSource audio;
    Color targetColor;
    float fadeTime = 0.2f;
    const float maxScale = 1.25f;
    private void Start()
    {
        rect = img.GetComponent<RectTransform>();
        audio = GetComponent<AudioSource>();
    }

    public void Activate(Color color, string text, float pitch)
    {
        audio.pitch = pitch;
        audio.Play();
        targetColor = color;
        img.color = Color.white;
        StartCoroutine(Fade());
        txt.text = text;
    }
    IEnumerator Fade()
    {
        float time = 0;
        float scale = maxScale;
        while (time<1)
        {
            scale = Mathf.Lerp(maxScale, 1, time);
            rect.localScale = new Vector2(scale, scale);
            time += Time.deltaTime/fadeTime;
            img.color = Color.Lerp(img.color, targetColor, time);
            yield return new WaitForEndOfFrame();
        }
        rect.localScale = new Vector2(1, 1);
    }
}
