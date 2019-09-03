using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
public class Accelerate : MonoBehaviour
{
    public Player thisPlayer;
    public KeyCode key = KeyCode.Space;
    Rigidbody rb;
    TrailRenderer trail;
    [SerializeField] float force;
    bool isGrounded = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        trail.startColor = thisPlayer.color;
        trail.endColor = thisPlayer.color;
    }
    private void Update()
    {
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
