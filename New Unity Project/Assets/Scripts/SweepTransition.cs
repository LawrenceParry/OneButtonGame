using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepTransition : MonoBehaviour
{
    RectTransform rect;
    [SerializeField] float time;
    float currentTime = 0;
    bool reverse;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        TransitionIn();
    }
    public void TransitionOut()
    {
        currentTime = 0;
        reverse = false;
        StartCoroutine(Transition());
    }
    public void TransitionIn()
    {
        currentTime = 0;
        reverse = true;
        StartCoroutine(Transition()); 
    }
    IEnumerator Transition()
    {
        Vector2 scale;
        while (currentTime < time)
        {
            if (reverse)
            {
                currentTime = currentTime + Time.deltaTime;
                scale = rect.localScale;
                scale.x = 1-(currentTime / time);
                rect.localScale = scale;
            }
            else
            {
                currentTime = currentTime + Time.deltaTime;
                scale = rect.localScale;
                scale.x = currentTime / time;
                rect.localScale = scale;
            }
            yield return new WaitForEndOfFrame();
        }
        if (reverse)
        {
            scale = rect.localScale;
            scale.x = 0;
            rect.localScale = scale;
        }
        else
        {
            scale = rect.localScale;
            scale.x = 1.2f;
            rect.localScale = scale;

        }
        
    }
}
