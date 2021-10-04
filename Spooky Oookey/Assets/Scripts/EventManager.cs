using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static void ResetEventSubscriptions()
    {
        OnInteract = null;
        OnNotEnoughPoop = null;
        OnNotEnoughWater = null;
        OnNotEnoughMoney = null;
        OnRefillWater = null;
        OnCowEaten = null;
        OnPumpkinGrows = null;
        OnGameOver = null;
    }


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
    public delegate void CowEatenEvent(GameObject eatEffect);
    public static event CowEatenEvent OnCowEaten;
    public static void TriggerCowEaten(GameObject eatEffect)
    {
        if (OnCowEaten != null) OnCowEaten(eatEffect);
    }

    //When a pumpkin grows up
    public delegate void PumpkinGrowsEvent();
    public static event PumpkinGrowsEvent OnPumpkinGrows;
    public static void TriggerPumpkinGrows()
    {
        if (OnPumpkinGrows != null) OnPumpkinGrows();
    }

    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;
    public static void TriggerGameOver()
    {
        if (OnGameOver != null) OnGameOver();
    }
}
