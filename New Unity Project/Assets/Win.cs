using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(LoadLevel))]
public class Win : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] GameObject panel;
    public void Activate(string _text,Color _color)
    {
        panel.SetActive(true);
        txt.text = _text;
        txt.color = _color;
        GetComponent<LoadLevel>().Run();
    }
}
