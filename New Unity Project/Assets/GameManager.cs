using System.Collections;
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
    private void Start()
    {
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
            
            GameObject g = Instantiate(playerObj, startingGrid[i-1].position, startingGrid[i-1].transform.rotation);
            g.GetComponent<Renderer>().material.color = AddPlayers.players[i-1].color;
            g.name = AddPlayers.players[i-1].name;
            Accelerate accelerateScript = g.GetComponent<Accelerate>();
            accelerateScript.key = AddPlayers.players[i-1].key;
            accelerateScript.thisPlayer = AddPlayers.players[i - 1];
            g.GetComponent<Steer>().waypoints = waypoints;
            txt[i - 1].text = AddPlayers.players[i - 1].name;
            txt[i - 1].color = AddPlayers.players[i - 1].color;
        }
    }

    public void DestroyPlayer(Player player)
    {
        txt[AddPlayers.players.IndexOf(player)].text = player.name + ": X";
        numOfPlayers--;
        player.destroyed = true;
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
        winText.gameObject.SetActive(true);
        winText.color = winner.color;
        winText.text = winner.name + " Wins!";
        playerWon = true;
    }
}
