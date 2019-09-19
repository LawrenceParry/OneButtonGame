using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipWhenGrounded : MonoBehaviour
{
    /*not to self: replace this with raycast downwards*/
    AudioSource audio;
    [SerializeField] AudioClip grounded;
    [SerializeField] AudioClip airborne;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            float time = audio.time;
            audio.clip = grounded;
            audio.time = time;
            audio.Play();
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            float time = audio.time;
            audio.clip = airborne;
            audio.time = time;
            audio.Play();
        }
    }
}
