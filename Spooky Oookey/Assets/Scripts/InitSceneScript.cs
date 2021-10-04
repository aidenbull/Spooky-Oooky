using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResourceManager.ResetGameValues();
        EventManager.ResetEventSubscriptions();
    }
}
