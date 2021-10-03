using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyObject : MonoBehaviour
{
    
    // Kinda poor form but felt that this would be an easy way to allow objects to go "behind" each other
    // Update is called once per frame
    protected void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.2f);
    }
}
