using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPitch : MonoBehaviour
{
    AudioSource audio;
    Rigidbody rb;
    [SerializeField] float divAmt;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float pitch = Mathf.Lerp(1, 3, rb.velocity.magnitude / divAmt);
        audio.pitch = pitch;
        audio.volume = Mathf.Lerp(0, 0.5f, rb.velocity.magnitude / divAmt);
    }
}
