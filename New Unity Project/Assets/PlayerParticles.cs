using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem held;
    [SerializeField] ParticleSystem pressed;
    [SerializeField] int pressedAmt;
    bool isAccelerating =false;
    private void Start()
    {
        
    }

    public void AcceleratePressed()
    {
        
        held.Play();
        if (!isAccelerating)
        {
            isAccelerating = true;
            pressed.Emit(pressedAmt);
        }
    }
    public void AccelerateReleased()
    {

        held.Stop();
        isAccelerating = false;
    }
}
