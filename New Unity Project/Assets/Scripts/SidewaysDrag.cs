using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysDrag : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float multi;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 vel = transform.InverseTransformDirection(rb.velocity);
        vel.x = vel.x * multi;
        rb.velocity = transform.TransformDirection(vel);
    }
}
