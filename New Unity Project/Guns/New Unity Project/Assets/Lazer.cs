using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] LayerMask layers;
    [SerializeField] float maxRange;
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            effect.Play();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if(Physics.Raycast(transform.position,transform.forward,out hit, maxRange))
            {
                SetLazer(transform.position, hit.point);
                Debug.DrawLine(transform.position, hit.point,Color.red,0.1f);
                hitEffect.gameObject.SetActive(true);
            }
            else
            {
                
                Debug.DrawLine(transform.position, transform.forward*maxRange, Color.red, 0.1f);
                SetLazer(transform.position, ray.GetPoint(maxRange));
                hitEffect.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            effect.Stop();
            hitEffect.gameObject.SetActive(false);
        }
    }

    void SetLazer(Vector3 start, Vector3 end)
    {
        Vector3 pos = (start + end) / 2;
        effect.transform.position = pos;
        effect.transform.rotation = transform.rotation;
        float length = Vector3.Distance(start, end)/2;
        var shape = effect.shape;
        shape.scale = new Vector3(length,1,1);
        var emission = effect.emission;
        emission.rateOverTime = length * 1000;
        hitEffect.transform.position = end;
    }
}
