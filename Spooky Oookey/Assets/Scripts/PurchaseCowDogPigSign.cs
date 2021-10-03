using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseCowDogPigSign : ClickableObject
{
    public delegate void Purchase();

    Purchase PurchaseCowCallback;

    public void Init(Purchase purchaseCallback)
    {
        PurchaseCowCallback = purchaseCallback;
    }

    public override void OnClick()
    {
        PurchaseCowCallback();
    }
}
