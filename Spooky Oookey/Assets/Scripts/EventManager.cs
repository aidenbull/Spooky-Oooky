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

    //When water gets refilled
    public delegate void RefillWaterEvent();
    public static event RefillWaterEvent OnRefillWater;
    public static void TriggerRefillWater()
    {
        if (OnRefillWater != null) OnRefillWater();
    }

    //This one may be backward but right now the resourceManager keeps track of number of cows and alerts the pasture when one is eaten
    //When a cow gets eaten
    public delegate void CowEatenEvent();
    public static event CowEatenEvent OnCowEaten;
    public static void TriggerCowEaten()
    {
        if (OnCowEaten != null) OnCowEaten();
    }

    //When a pumpkin grows up
    public delegate void PumpkinGrowsEvent();
    public static event PumpkinGrowsEvent OnPumpkinGrows;
    public static void TriggerPumpkinGrows()
    {
        if (OnPumpkinGrows != null) OnPumpkinGrows();
    }
}
