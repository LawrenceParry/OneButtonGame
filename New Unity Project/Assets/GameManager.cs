using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] Transform[] startingGrid;
    [SerializeField] Transform[] waypoints;
    private void Start()
    {
        Debug.Log(AddPlayers.players.Count);
        for (int i = AddPlayers.players.Count;i>0;i--)
        {
            
            GameObject g = Instantiate(playerObj, startingGrid[i-1].position, startingGrid[i-1].transform.rotation);
            g.GetComponent<Renderer>().material.color = AddPlayers.players[i-1].color;
            g.name = AddPlayers.players[i-1].name;
            g.GetComponent<Accelerate>().key = AddPlayers.players[i-1].key;
            g.GetComponent<Steer>().waypoints = waypoints;
        }
    }
}
