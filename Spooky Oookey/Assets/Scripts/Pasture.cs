using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasture : MonoBehaviour
{
    public GameObject CowDogPig1;
    public GameObject CowDogPig2;
    public GameObject PurchaseSign;

    public float wanderRadius = 2f;
    public float widthToHeightRatio = 1.5f;
    public float pastureRotation = 0f;
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
        cdp.transform.localPosition = Vector3.zero;
        cdp.GetComponent<CowDogPig>().Init(wanderRadius, widthToHeightRatio, pastureRotation, transform.position);
    }


}
