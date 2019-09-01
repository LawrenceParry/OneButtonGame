using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] float rotationSpeed;
    int currentTarget = 0;
    public Transform target;

    private void Start()
    {
        target = waypoints[currentTarget];
    }
    private void Update()
    {
        Quaternion targetRot = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed*Time.deltaTime);
    }
    public void ReachCheckpoint()
    {
        if (currentTarget < waypoints.Count-1)
        {
            currentTarget++;
        }
        else
        {
            currentTarget = 0;
        }
        
        target = waypoints[currentTarget];
    }
}
