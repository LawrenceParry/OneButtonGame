using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JitterOutline : MonoBehaviour
{
    [SerializeField] Outline outline;
    [SerializeField] Vector2 minAndMax;

    private void Update()
    {
        outline.effectDistance = new Vector2(Random.Range(minAndMax.x, minAndMax.y), Random.Range(minAndMax.x, minAndMax.y));
    }
}
