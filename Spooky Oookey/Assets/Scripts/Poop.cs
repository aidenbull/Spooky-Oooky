using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : SpookyObject
{
    float slideMaxDistance = 1f;
    Vector2 origin;
    Vector2 slideTarget;

    float slideTimer = 2f;
    float slideFrameIncrement = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        slideTarget = GenerateRandomPoopCoordinate();
        //So it appears behind the cowdogpigs
        transform.position += new Vector3(0f, 0f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (slideTimer > 0f) HandleSliding();
    }

    void HandleSliding()
    {
        slideTimer -= Time.deltaTime;

        Vector3 slideTarget3D = new Vector3(slideTarget.x, slideTarget.y, transform.position.z);
        Vector3 targetVector = slideTarget3D - transform.position;
        transform.position += targetVector * 0.1f;
    }

    Vector2 GenerateRandomPoopCoordinate()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float radius = Random.Range(0, slideMaxDistance);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        return origin + new Vector2(x, y);
    }
}
