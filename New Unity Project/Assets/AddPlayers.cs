using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AddPlayers : MonoBehaviour
{
    int playerNum = 0;
    int maxPlayers = 4;
    [SerializeField] Color[] colors;
    List<KeyCode> takenKeys = new List<KeyCode>();
    [System.NonSerialized] public static List<Player> players = new List<Player>();
    [SerializeField] ActivatePanel[] uiElements;
    [SerializeField] GameObject starting;
    private void Start()
    {
        players = new List<Player>();
    }

    private void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey)&&!takenKeys.Contains(vKey)&&playerNum<maxPlayers)
            {
                Player p = new Player();
                players.Add(p);
                p.color = colors[playerNum];
                p.key = vKey;
                p.name = vKey.ToString();
                takenKeys.Add(vKey);
                float pitch = 1 + ((playerNum) * 0.1f);
                uiElements[playerNum].Activate(colors[playerNum], vKey.ToString(),pitch,vKey);
                playerNum++;
            }
        }
        if (playerNum >= 2)
        {
            foreach(KeyCode k in takenKeys)
            {
                if (!Input.GetKey(k))
                {
                    return;
                }
            }
            Starting();
        }
    }
    void Starting()
    {
        starting.SetActive(true);
        this.enabled = false;
    }
}
