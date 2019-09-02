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
        
        Debug.Log(AddPlayers.players.Count);
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
    public void FinishLap(Player player)
    {
        player.lapCount++;
        txt[AddPlayers.players.IndexOf(player)].text = player.name + ": " + player.lapCount.ToString();
        if (player.lapCount == numOfLaps&&!playerWon)
        {
            winText.gameObject.SetActive(true);
            winText.color = player.color;
            winText.text = player.name + " wins!";
            playerWon = true;
        }
    }
}
