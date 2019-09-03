using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            GameManager.gm.DestroyPlayer(GetComponent<Accelerate>().thisPlayer);
            Destroy(gameObject);
        }
    }
}
