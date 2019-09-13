using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particles;
    [SerializeField] SpriteRenderer[] sprites;
    public void SetColor(Color color)
    {
        foreach(ParticleSystem p in particles)
        {
            var settings = p.main;
            settings.startColor = color;
        }
        foreach(SpriteRenderer s in sprites)
        {
            s.color = color;
        }
    }
}
