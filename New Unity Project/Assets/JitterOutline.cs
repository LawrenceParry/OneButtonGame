using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JitterOutline : MonoBehaviour
{
    Outline[] outline;
    private void Start()
    {
        outline = GetComponents<Outline>();
    }
    private void Update()
    {
        outline[1].effectDistance = new Vector2(Random.Range(0.5f, 4), Random.Range(0.5f, 4));
    }
}
