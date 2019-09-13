using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LapText : MonoBehaviour
{
    
    Text text;
    Outline outline;
    float outlineAmt = 0;
    const float maxOutline = 4;
    const float time = 0.25f;
    private void Start()
    {
        text = GetComponent<Text>();
        outline = GetComponent<Outline>();
    }
    /*PLS REPLACE WITH PROPERTIES*/
    public void SetText(string txt)
    {
        text.text = txt;
        outlineAmt = maxOutline;
        outline.enabled = true;
    }
    public void SetColor(Color color)
    {
        text.color = color;
    }
    private void Update()
    {
        if (outlineAmt > 0)
        {
            outlineAmt = outlineAmt - ((Time.deltaTime * maxOutline)/time);
            outline.effectDistance = new Vector2(Random.Range(0, outlineAmt), Random.Range(0, outlineAmt));
        }
        else
        {
            outline.enabled = false;
        }
    }

}
