using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float MinX;
    public float MinY;
    public float MaxX;
    public float MaxY;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Min(Mathf.Max(player.transform.position.x, MinX), MaxX);
        float y = Mathf.Min(Mathf.Max(player.transform.position.y, MinY), MaxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
