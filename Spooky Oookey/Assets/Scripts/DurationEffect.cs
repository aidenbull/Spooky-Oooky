using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationEffect : MonoBehaviour
{
    public float Duration = 1f;

    // Update is called once per frame
    void Update()
    {
        Duration -= Time.deltaTime;
        if (Duration < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
