using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHoverText : MonoBehaviour
{
    Color NormalColour = new Color(0.9f, 0.9f, 0.9f);
    Color HoverColour = new Color(0.7f, 0.7f, 0.7f);

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnMouseOver()
    {
        text.color = HoverColour;
    }

    private void OnMouseExit()
    {
        text.color = NormalColour;
    }
}
