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
            GameObject p =Instantiate(deathEffect, transform.position, Quaternion.identity);
            Color col = GetComponent<PlayerInfo>().thisPlayer.color;
            p.GetComponent<ColorParticles>().SetColor(col);
            GameManager.gm.DestroyPlayer(GetComponent<PlayerInfo>().thisPlayer);
            Destroy(gameObject);
        }
    }
}
