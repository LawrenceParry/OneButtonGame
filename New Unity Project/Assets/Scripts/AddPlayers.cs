using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AddPlayers : MonoBehaviour
{
    int playerNum = 0;
    int maxPlayers = 4;
    [SerializeField] Color[] colors;
    List<KeyCode> takenKeys = new List<KeyCode>();
    [SerializeField] public static List<Player> players = new List<Player>();
    [SerializeField] ActivatePanel[] uiElements;
    [SerializeField] GameObject starting;
    private void Start()
    {
        players = new List<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&playerNum>0)
        {
            Remove();
            return;
        }

        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey)&&!takenKeys.Contains(vKey)&&playerNum<maxPlayers&&vKey!=KeyCode.Escape)
            {
                Add(vKey);
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

    void Add(KeyCode k)
    {
        Player p = new Player();
        players.Add(p);
        p.color = colors[playerNum];
        p.key = k;
        p.name = k.ToString();
        p.id = playerNum;
        takenKeys.Add(k);
        float pitch = 1 + ((playerNum) * 0.1f);
        uiElements[playerNum].Activate(colors[playerNum], k.ToString(), pitch, k);
        playerNum++;
    }

    private void Remove()
    {
        int index = players.Count-1;
        uiElements[playerNum-1].Deactivate();
        takenKeys.Remove(players[index].key);
        players.RemoveAt(index);
        playerNum -= 1;
    }

    void Starting()
    {
        starting.SetActive(true);
        this.enabled = false;
    }
}
