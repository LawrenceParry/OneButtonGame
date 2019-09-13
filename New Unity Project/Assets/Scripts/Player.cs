using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int id;
    public KeyCode key;
    public Color color;
    public string name;
    public int lapCount=-1;
    public int waypoint;
    public bool destroyed = false;
    public Transform trans;
}
