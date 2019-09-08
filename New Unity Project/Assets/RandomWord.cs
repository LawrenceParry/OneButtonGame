using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWord : MonoBehaviour
{
    Text txt;
    [SerializeField] string[] phrases;
    void Start()
    {
        txt = GetComponent<Text>();
        float num = Random.Range(-0.49f, phrases.Length -0.51f);
        int i = Mathf.RoundToInt(num);
        txt.text = phrases[i];
    }

}
