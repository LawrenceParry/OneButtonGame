using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTextAndColor : MonoBehaviour
{
    [SerializeField] Text keyText;
    [SerializeField] Image img;

    public void Set(Color col, string txt)
    {
        keyText.text = txt;
        img.color = col;
    }
}
