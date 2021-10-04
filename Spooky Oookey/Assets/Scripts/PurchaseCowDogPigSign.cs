using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseCowDogPigSign : ClickableObject
{
    public delegate void Purchase();

    Purchase PurchaseCowCallback;

    public GameObject ChildTrigger;

    bool playerInRange = false;

    SpriteRenderer sprite;

    Color hoverColour = Color.white;
    Color activeColour = Color.white * 0.9f;
    Color inactiveColour = Color.grey;

    int cowPrice = 500;

    public void Init(Purchase purchaseCallback)
    {
        PurchaseCowCallback = purchaseCallback;

        sprite = GetComponent<SpriteRenderer>();
        sprite.color = inactiveColour;

        ChildObjectTrigger triggerScript = ChildTrigger.GetComponent<ChildObjectTrigger>();
        triggerScript.Init(SignTriggerEnter, SignTriggerExit);
    }

    public override void OnMouseD()
    {
        if (playerInRange)
        {
            sprite.color = inactiveColour;
            if (ResourceManager.SubtractMoney(cowPrice))
            {
                EventManager.TriggerInteract();
                if (PurchaseCowCallback != null) PurchaseCowCallback();
            }
            else
            {
                EventManager.TriggerNotEnoughMoney();
            }
        }
    }

    public override void OnMouseU()
    {
        if (playerInRange)
        {
            sprite.color = hoverColour;
        }
    }

    public override void OnMouseIn()
    {
        if (playerInRange)
        {
            sprite.color = hoverColour;
        }
    }

    public override void OnMouseOut()
    {
        if (playerInRange)
        {
            sprite.color = activeColour;
        }
    }

    private void SignTriggerEnter(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;
            sprite.color = activeColour;
        }
    }

    private void SignTriggerExit(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
            sprite.color = inactiveColour;
        }
    }
}
