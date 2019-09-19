using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClipOnTimer : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] float time;
    AudioSource audio;
    float volume = 0.05f;
    float pitch = 1f;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        audio.clip = clip;
        audio.volume = volume;
        audio.pitch = pitch;
        audio.Play();
    }
}
