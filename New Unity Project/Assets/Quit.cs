using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quit : MonoBehaviour
{
    float time = 0;
    Image img;
    private void Start()
    {
        img = GetComponent<Image>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            time += Time.deltaTime;
            if (time > 1.3f)
            {
                Exit();
            }
        }
        else
        {
            time = 0;
        }
        img.fillAmount = time;
    }

    private void Exit()
    {
        Application.Quit();
        Debug.Log("I have quit");
    }
}
