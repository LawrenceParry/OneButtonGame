using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonText : MonoBehaviour
{
    [SerializeField] Text keyText;

    public void Set(string txt)
    {
        keyText.text = txt;
    }
}
