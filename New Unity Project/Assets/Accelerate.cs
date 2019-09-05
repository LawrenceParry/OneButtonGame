using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
public class Accelerate : MonoBehaviour
{
    PlayerInfo info;
    PlayerParticles particles;
    public KeyCode key = KeyCode.Space;
    Rigidbody rb;
    TrailRenderer trail;
    [SerializeField] float force;
    bool isGrounded = false;
    private void Start()
    {
        particles = GetComponent<PlayerParticles>();
        info = GetComponent<PlayerInfo>();   
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        trail.startColor = info.thisPlayer.color;
        trail.endColor = info.thisPlayer.color;
    }
    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            particles.AcceleratePressed();
        }
        else if (Input.GetKeyUp(key))
        {
            particles.AccelerateReleased();
        }
        if (Input.GetKey(key)&&isGrounded&&GameManager.gm.raceStarted)
        {
            trail.emitting = true;
            rb.AddForce(transform.forward * force);
        }
        else
        {
            trail.emitting = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            rb.velocity = rb.velocity * 0.7f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
