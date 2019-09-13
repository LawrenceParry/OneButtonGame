using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField] float rotationSpeed;
    public  int currentTarget = 0;
    Transform target;
    public bool isGrounded = false;
    public PlayerInfo player;

    private void Start()
    {
        player = GetComponent<PlayerInfo>();
        target = waypoints[currentTarget];
    }
    private void Update()
    {
        if (isGrounded)
        {
            Quaternion targetRot = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
        player.thisPlayer.waypoint = currentTarget;
    }
    public void ReachCheckpoint()
    {
        if (currentTarget < waypoints.Length-1)
        {
            currentTarget++;
        }
        else
        {
            currentTarget = 0;
        }
        
        target = waypoints[currentTarget];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
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
