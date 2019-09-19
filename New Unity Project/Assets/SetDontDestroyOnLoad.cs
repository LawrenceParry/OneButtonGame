using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDontDestroyOnLoad : MonoBehaviour
{
    void OnEnable()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
}
