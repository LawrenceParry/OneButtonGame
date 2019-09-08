using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonOutline : MonoBehaviour
{
    public KeyCode key;
    Outline outline;
    private void Start()
    {
        outline = GetComponent<Outline>();
    }
    private void Update()
    {
        if (key != null)
        {
            if (Input.GetKeyDown(key))
            {
                outline.enabled = true;
            }
            if (Input.GetKeyUp(key))
            {
                outline.enabled = false;
            }
        }
    }
}
