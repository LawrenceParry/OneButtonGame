using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysDrag : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 vel = transform.InverseTransformDirection(rb.velocity);
        vel.x = vel.x * 0.95f;
        rb.velocity = transform.TransformDirection(vel);
    }
}
