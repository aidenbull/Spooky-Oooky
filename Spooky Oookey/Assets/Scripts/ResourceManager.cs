using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public static int PoopCounter = 0;
    public static int WaterCounter = 0;
    public static int MoneyCounter = 0;
    public static int CowDogPigCounter = 0;

    public static int MAX_WATER = 3;
    public static int STARTING_MONEY = 1000;

    public static void ResetGameValues()
    {
        PoopCounter = 0;
        WaterCounter = 0;
        MoneyCounter = STARTING_MONEY;
        CowDogPigCounter = 0;
    }

    public static void IncrementPoop()
    {
        PoopCounter += 1;
    }

    public static bool DecrementPoop()
    {
        if (PoopCounter > 0)
        {
            PoopCounter -= 1;
            return true;
        }
        return false;
    }

    public static void RefillWater()
    {
        if (WaterCounter < MAX_WATER)
        {
            WaterCounter = MAX_WATER;
            EventManager.TriggerRefillWater();
        }
    }

    public static bool DecrementWater()
    {
        if (WaterCounter > 0)
        {
            WaterCounter -= 1;
            return true;
        }
        return false;
    }

    public static void AddMoney(int amount)
    {
        MoneyCounter += amount;
    }

    public static bool SubtractMoney(int amount)
    {
        if (MoneyCounter >= amount)
        {
            MoneyCounter -= amount;
            return true;
        }
        return false;
    }

    public static void AddCowDogPig()
    {
        CowDogPigCounter += 1;
    }

    public static bool RemoveCowDogPig()
    {
        if (CowDogPigCounter > 0)
        {
            CowDogPigCounter -= 1;
            EventManager.TriggerCowEaten();
            return true;
        }
        return false;
    }
}
