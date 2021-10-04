using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : SpookyObject
{
    //Pretty much a carbon copy of poop.cs, just different behaviour on where drops land

    float slideMinDistance = 0.3f;
    float slideMaxDistance = 0.7f;
    Vector2 origin;
    Vector2 slideTarget;

    float slideTimer = 2f;
    float slideFrameIncrement = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        slideTarget = GenerateRandomBoneCoordinate();
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
        transform.position += targetVector * slideFrameIncrement;
    }

    Vector2 GenerateRandomBoneCoordinate()
    {
        float angle = Random.Range(1.25f * Mathf.PI, 1.75f * Mathf.PI);
        float radius = Random.Range(slideMinDistance, slideMaxDistance);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        return origin + new Vector2(x, y);
    }
}
