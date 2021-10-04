using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasture : MonoBehaviour
{
    public GameObject CowDogPig1;
    public GameObject CowDogPig2;
    public GameObject PurchaseSign;

    public float wanderRadius = 2f;
    public float widthToHeightRatio = 2f;
    public float pastureRotation = Mathf.PI / 2f;
    public Vector2 pastureOrigin;

    // Start is called before the first frame update
    void Start()
    {
        PurchaseCowDogPigSign signScript = PurchaseSign.GetComponent<PurchaseCowDogPigSign>();
        signScript.Init(SpawnCow);

        SpawnCow();
        SpawnCow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCow()
    {
        float coinFlip = Random.Range(0f, 1f);
        GameObject cdp;
        if (coinFlip < 0.5f)
        {
            cdp = Instantiate(CowDogPig1);
        }
        else
        {
            cdp = Instantiate(CowDogPig2);
        }
        cdp.transform.SetParent(transform);
        cdp.transform.position = GenerateRandomPastureCoordinate(wanderRadius, widthToHeightRatio, pastureRotation, transform.position);
        cdp.GetComponent<CowDogPig>().Init(wanderRadius, widthToHeightRatio, pastureRotation, transform.position);
    }

    public static Vector2 GenerateRandomPastureCoordinate(float wanderRadius, float widthToHeightRatio, float pastureRotation, Vector2 pastureOrigin)
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float radius = Random.Range(0, wanderRadius);
        float x = radius * Mathf.Cos(angle) * widthToHeightRatio;
        float y = radius * Mathf.Sin(angle);

        Vector2 RotatedCoordinate = Utilities.Rotate2D(new Vector2(x, y), pastureRotation);

        return pastureOrigin + RotatedCoordinate;
    }
}
