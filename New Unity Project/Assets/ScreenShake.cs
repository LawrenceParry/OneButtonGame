using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    float shakeAmt = 0;
    float setamt = 22;
   public void SetShake()
    {
        shakeAmt = setamt;
    }
    private void Update()
    {
        if (shakeAmt > 0)
        {
            Debug.Log("Shaking");
            Vector3 add = Random.insideUnitSphere * shakeAmt;
            transform.position = transform.position + add;
            shakeAmt = shakeAmt  -(35*Time.deltaTime);
        }
    }
}
