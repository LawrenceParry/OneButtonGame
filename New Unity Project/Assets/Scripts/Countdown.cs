using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    Text text;
    AudioSource audio;
    private void Start()
    {
        text = GetComponent<Text>();
        audio = GetComponent<AudioSource>();
        StartCoroutine(Timer());
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        for (int i = 3; i > 0; i--)
        {
            text.text = i.ToString();
            audio.Play();
            yield return new WaitForSeconds(1);
        }
        audio.pitch = 1.5f;
        audio.Play();
        text.text = "GO!";
        text.color = Color.green;
        GameManager.gm.raceStarted = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
