using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        for (int i = 3; i > 0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        text.text = "GO!";
        GameManager.gm.raceStarted = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
