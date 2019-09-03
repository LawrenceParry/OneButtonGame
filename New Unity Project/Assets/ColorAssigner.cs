using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssigner : MonoBehaviour
{
    [SerializeField]Renderer[] renderers;

    public void SetColor(Color color)
    {
        foreach(Renderer r in renderers)
        {
            r.material.color = color;
        }
    }
}
