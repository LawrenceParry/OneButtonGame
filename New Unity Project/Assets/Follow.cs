using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    Camera cam;
    const float maxOffset = 500;
    const float minOffset = 280;
    const float zoomPoint = 0.2f;
    const float transitionSpeed = 6;
    const float zoomOutSpeed = 400;
    const float zoomInSpeed = 70;
    float amtOver = 0;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        Vector3 pos = Vector3.zero;
        int count = 0;
        foreach (Player p in AddPlayers.players)
        {
            if (!p.destroyed)
            {
                pos += p.trans.position;
                count++;
            }      
        }
        pos = count > 0 ? pos / count : Vector3.zero;
        transform.position = Vector3.Lerp(transform.position, pos + offset, Time.deltaTime * transitionSpeed);

        amtOver = 0;
        foreach (Player p in AddPlayers.players)
        {
            if (!p.destroyed)
            {
                Vector3 point = cam.WorldToViewportPoint(p.trans.position);
                if (point.x < zoomPoint || point.x > 1-zoomPoint)
                {
                    float amt = point.x < 0.5 ? (point.x * -1) + zoomPoint : point.x - (1 - zoomPoint);
                    amtOver += amt;
                    ZoomOut();
                }
                if (point.y < zoomPoint|| point.y > 1-zoomPoint)
                {
                    float amt = point.y < 0.5 ? (point.y * -1) + zoomPoint : point.y - (1 - zoomPoint);
                    amtOver += amt;
                    ZoomOut();
                }
            }
        }

        if (amtOver==0)
            ZoomIn();
    }
    void ZoomOut()
    {
        if (offset.y < maxOffset)
            offset.y += amtOver* zoomOutSpeed * Time.deltaTime;
    }
    void ZoomIn()
    {
        if (offset.y > minOffset)
            offset.y -=  zoomInSpeed * Time.deltaTime;
    }
}
