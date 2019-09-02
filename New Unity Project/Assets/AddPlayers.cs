﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AddPlayers : MonoBehaviour
{
    int playerNum = 0;
    int maxPlayers = 4;
    [SerializeField] Color[] colors;
    List<KeyCode> takenKeys = new List<KeyCode>();
    public static List<Player> players = new List<Player>();
    [SerializeField] PlayerTextAndColor[] uiElements;
    [SerializeField] GameObject starting;
    private void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey)&&!takenKeys.Contains(vKey))
            {
                Player p = new Player();
                players.Add(p);
                p.color = colors[playerNum];
                p.key = vKey;
                p.name = vKey.ToString();
                takenKeys.Add(vKey);
                uiElements[playerNum].Set(colors[playerNum], vKey.ToString());
                playerNum++;

                if (playerNum == maxPlayers)
                {
                    starting.SetActive(true);
                    this.enabled = false;
                }
            }
        }
    }
}