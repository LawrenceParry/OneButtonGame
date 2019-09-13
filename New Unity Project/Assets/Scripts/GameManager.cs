using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] Transform[] startingGrid;
    [SerializeField] Transform[] waypoints;
    [SerializeField] LapText[] txt;
    [SerializeField] GameObject winObj;
    [SerializeField] int numOfLaps = 1;
    bool playerWon = false;
    int numOfPlayers;
    public bool raceStarted = false;
    public static GameManager gm = null;
    [SerializeField] GameObject leadingPlayerObj;
    int highestLap = 0;
    Player winningPlayer;
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
        CreatePlayers();
    }

    private void Update()
    {
        CheckFirstPlace();
    }

    public void CreatePlayers()
    {
        numOfPlayers = AddPlayers.players.Count;
        for (int i = AddPlayers.players.Count; i > 0; i--)
        {
            Player player = AddPlayers.players[i - 1];
            GameObject g = Instantiate(playerObj, startingGrid[i - 1].position, startingGrid[i - 1].transform.rotation);
            g.GetComponent<ColorAssigner>().SetColor(player.color);
            g.GetComponent<Steer>().waypoints = waypoints;
            g.GetComponent<Accelerate>().key = player.key;
            g.name = player.name;
            player.trans = g.transform;
            PlayerInfo playerInfo = g.GetComponent<PlayerInfo>();
            playerInfo.thisPlayer = player;
            txt[i - 1].SetText(player.name);
            txt[i - 1].SetColor(player.color);
        }
    }

    public void DestroyPlayer(Player player)
    {
        txt[player.id].SetText(player.name + ": X");
        numOfPlayers--;
        player.destroyed = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>().SetShake();
        if (winningPlayer == player)
            winningPlayer = null;
        AddPlayers.players.Remove(player);
        if (numOfPlayers == 1)
        {
            Win(AddPlayers.players[0]);
        }
        if (numOfPlayers == 0)
            Destroy(leadingPlayerObj);
    }

    public void FinishLap(Player player)
    {
        player.lapCount++;
        txt[player.id].SetText(player.name + ": " + player.lapCount.ToString() + "/" + numOfLaps.ToString());
        if (player.lapCount > highestLap)
        {
            winningPlayer = player;
            highestLap++;
        }
        if (player.lapCount == numOfLaps && !playerWon)
        {
            Win(player);
        }
    }

    public void Win(Player winner)
    {
        if (!playerWon)
        {
            winObj.GetComponent<Win>().Activate(winner.name + " Wins!", winner.color);
            playerWon = true;
        }
    }

    Player CompareWaypointDistance(Player p)
    {
        int nextWaypoint = winningPlayer.waypoint + 1;
        if (waypoints.Length == nextWaypoint)
            nextWaypoint = 0;
        float distanceLeader = Vector3.Distance(winningPlayer.trans.position, waypoints[nextWaypoint].position);
        float distanceChallenger = Vector3.Distance(p.trans.position, waypoints[nextWaypoint].position);
        if (distanceChallenger < distanceLeader)
            return p;
        return winningPlayer;
    }

    public void CheckFirstPlace()
    {
        for (int i = AddPlayers.players.Count - 1; i >= 0; i--)
        {
            if (winningPlayer == null)
            {
                winningPlayer = AddPlayers.players[i];
                continue;
            }
            if (AddPlayers.players[i].lapCount == highestLap)
            {
                if (AddPlayers.players[i].waypoint > winningPlayer.waypoint && winningPlayer.waypoint != 0)
                {
                    winningPlayer = AddPlayers.players[i];
                }
                if (AddPlayers.players[i].waypoint == winningPlayer.waypoint)
                {
                    winningPlayer = CompareWaypointDistance(AddPlayers.players[i]);
                }
            }
        }

        if (winningPlayer != null && winningPlayer.lapCount >= 0)
        {
            leadingPlayerObj.transform.position = winningPlayer.trans.position;
        }
    }
}
