using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Player interaction
    public delegate void InteractEvent();
    public static event InteractEvent OnInteract;
    public static void TriggerInteract()
    {
        if (OnInteract != null) OnInteract();
    }

    //Try to spend poop when have none
    public delegate void NotEnoughPoopEvent();
    public static event NotEnoughPoopEvent OnNotEnoughPoop;
    public static void TriggerNotEnoughPoop()
    {
        if (OnNotEnoughPoop != null) OnNotEnoughPoop();
    }

    //Try to spend water when have none
    public delegate void NotEnoughWaterEvent();
    public static event NotEnoughWaterEvent OnNotEnoughWater;
    public static void TriggerNotEnoughWater()
    {
        if (OnNotEnoughWater != null) OnNotEnoughWater();
    }

    //Try to spend money when have none
    public delegate void NotEnoughMoneyEvent();
    public static event NotEnoughMoneyEvent OnNotEnoughMoney;
    public static void TriggerNotEnoughMoney()
    {
        if (OnNotEnoughMoney != null) OnNotEnoughMoney();
    }
}
