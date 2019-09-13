using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    AudioSource lapSound;
    private void Start()
    {
        lapSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.gm.FinishLap(other.transform.parent.GetComponent<PlayerInfo>().thisPlayer);
            lapSound.Play();
        }
    }
}
