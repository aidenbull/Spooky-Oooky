using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinButton : ClickableObject
{
    SpriteRenderer sprite;

    float nonHoverAlpha = 0.9f;
    float hoverAlpha = 1f;
    float clickAlpha = 0.9f;

    Color tempColor;

    public delegate void OnClickFunction();
    OnClickFunction onClick;

    bool visible = false;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Init(OnClickFunction onClick)
    {
        sprite = GetComponent<SpriteRenderer>();
        tempColor = sprite.color;
        tempColor.a = nonHoverAlpha;
        sprite.color = tempColor;
        this.onClick = onClick;
        SetActive(false);
        Hide();
    }

    public override void OnMouseD()
    {
        if (visible && active)
        {
            tempColor.a = clickAlpha;
            sprite.color = tempColor;
            if (onClick != null && active) onClick();
        }
    }

    public override void OnMouseU()
    {
        if (visible && active)
        {
            tempColor.a = hoverAlpha;
            sprite.color = tempColor;
        }
    }

    public override void OnMouseIn()
    {
        if (visible && active)
        {
            tempColor.a = hoverAlpha;
            sprite.color = tempColor;
        }
    }

    public override void OnMouseOut()
    {
        if (visible && active)
        {
            tempColor.a = nonHoverAlpha;
            sprite.color = tempColor;
        }
    }

    //Janky but im tired
    void UpdateVisibility()
    {
        if (visible && active)
        {
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
    }

    public void Hide()
    {
        visible = false;
        UpdateVisibility();
    }

    public void Show()
    {
        visible = true;
        UpdateVisibility();
    }

    public void SetActive(bool active)
    {
        this.active = active;
        UpdateVisibility();
    }
}
