using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float MinX;
    public float MinY;
    public float MaxX;
    public float MaxY;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Min(Mathf.Max(player.transform.position.x, MaxX), MinX);
        float y = Mathf.Min(Mathf.Max(player.transform.position.y, MaxY), MinY);

        transform.position = new Vector3(x, y, transform.z);
    }
}
