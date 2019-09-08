﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] Transform[] startingGrid;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Text[] txt;
    [SerializeField] Text winText;
    [SerializeField] int numOfLaps = 1;
    bool playerWon = false;
    int numOfPlayers;
    public bool raceStarted = false;
    public static GameManager gm=null;
    [SerializeField] GameObject leadingPlayerObj;
    List<Steer> playerSteer = new List<Steer>();
    private void Start()
    {
        leadingPlayerObj = Instantiate(leadingPlayerObj);
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
        numOfPlayers = AddPlayers.players.Count;
        for (int i = AddPlayers.players.Count;i>0;i--)
        {
            Player player = AddPlayers.players[i - 1];
            GameObject g = Instantiate(playerObj, startingGrid[i-1].position, startingGrid[i-1].transform.rotation);
            player.trans = g.transform;
            g.GetComponent<ColorAssigner>().SetColor(player.color);
            g.name = player.name;
            PlayerInfo playerInfo = g.GetComponent<PlayerInfo>();
            playerInfo.thisPlayer = player;
            g.GetComponent<Accelerate>().key = player.key;
            g.GetComponent<Steer>().waypoints = waypoints;
            playerSteer.Add(g.GetComponent<Steer>());
            txt[i - 1].text = player.name;
            txt[i - 1].color = player.color;
        }
    }

    public void DestroyPlayer(Player player)
    {
        txt[AddPlayers.players.IndexOf(player)].text = player.name + ": X";
        numOfPlayers--;
        player.destroyed = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>().SetShake();
        if (numOfPlayers == 1)
        {
            foreach(Player p in AddPlayers.players)
            {
                if (!p.destroyed)
                {
                    Win(p);
                }
            }
        }
    }

    public void FinishLap(Player player)
    {
        player.lapCount++;
        txt[AddPlayers.players.IndexOf(player)].text = player.name + ": " + player.lapCount.ToString()+"/"+numOfLaps.ToString();
        if (player.lapCount == numOfLaps&&!playerWon)
        {
            Win(player);
        }
    }

    public void Win(Player winner)
    {
        if (!playerWon)
        {
            winText.gameObject.SetActive(true);
            winText.color = winner.color;
            winText.text = winner.name + " Wins!";
            playerWon = true;
        }
    }
    private void Update()
    {
        CheckFirstPlace();
    }
    public void CheckFirstPlace()
    {
        List<GameObject> higestLapPlayers = new List<GameObject>();
        foreach(Player p in AddPlayers.players)
        {
           higestLapPlayers.Add(p.trans.gameObject);
        }


        int highestWaypoint = 0;
        List<GameObject> highestWaypointPlayers = new List<GameObject>();
        foreach(GameObject g in higestLapPlayers)
        {
            int targ = g.GetComponent<Steer>().currentTarget;
            if (targ > highestWaypoint)
            {
                highestWaypoint = targ;
                highestWaypointPlayers.Add(g);
            }  
        }
        leadingPlayerObj.transform.position = highestWaypointPlayers[0].transform.position;
    }
}
