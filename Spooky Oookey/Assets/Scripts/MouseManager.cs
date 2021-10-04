using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseManager : MonoBehaviour
{
    /*
     *  To attach to the main camera
     */

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    void Click()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, LayerMask.GetMask("clickable"))){
            ClickableObject clickable = hit.collider.gameObject.GetComponent<ClickableObject>();
            if (clickable)
            {
                //clickable.OnClick();
                Debug.Log("Clicked an object!");
            }
        }
    }
}
