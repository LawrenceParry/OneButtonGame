using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log(gameObject.name + " has been destroyed");
    }
}
