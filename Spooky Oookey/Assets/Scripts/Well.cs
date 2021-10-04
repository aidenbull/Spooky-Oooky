using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider other)
    //{
    //    Debug.Log("SOMETHING IN MY TRIGGER!");
    //    if (other.CompareTag("Player"))
    //    {
    //        ResourceManager.RefillWater();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ResourceManager.RefillWater();
        }
    }
}
