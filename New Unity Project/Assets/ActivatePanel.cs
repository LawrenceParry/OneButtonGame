using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivatePanel : MonoBehaviour
{
    RectTransform rect;
    [SerializeField] Image img;
    [SerializeField] Text txt;
    [SerializeField] ButtonOutline outline;
    [SerializeField] AudioClip selectAudio;
    [SerializeField] AudioClip removeAudio;
    AudioSource audio;
    string defaultText;
    Color defaultColor;
    Color targetColor;
    float fadeTime = 0.2f;
    const float maxScale = 1.25f;
    private void Start()
    {
        rect = img.GetComponent<RectTransform>();
        audio = GetComponent<AudioSource>();
        defaultText = txt.text;
        defaultColor = img.color;
    }

    public void Activate(Color color, string text, float pitch, KeyCode key)
    {
        audio.clip = selectAudio;
        audio.pitch = pitch;
        audio.Play();
        targetColor = color;
        img.color = Color.white;
        StartCoroutine(Fade());
        txt.text = text;
        outline.key = key;
    }
    public void Deactivate()
    {
        audio.clip = removeAudio;
        audio.pitch = 1;
        audio.Play();
        img.color = defaultColor;
        txt.text = defaultText;
        outline.key = KeyCode.None;
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
