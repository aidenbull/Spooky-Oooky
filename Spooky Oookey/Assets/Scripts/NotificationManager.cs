using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public GameObject NotEnoughPoop;
    public GameObject NotEnoughWater;
    public GameObject NotEnoughMoney;
    public GameObject RefillWater;

    float disappearTimer;
    float DISAPPEAR_TIME = 2f;

    // Start is called before the first frame update
    void Start()
    {
        HideAll();

        EventManager.OnNotEnoughPoop += ShowPoop;
        EventManager.OnNotEnoughWater += ShowWater;
        EventManager.OnNotEnoughMoney += ShowMoney;
        EventManager.OnRefillWater += ShowRefillWater;
    }

    private void Update()
    {
        if (disappearTimer > 0)
        {
            disappearTimer -= Time.deltaTime;
        }
        else
        {
            HideAll();
        }
    }

    void HideAll()
    {
        NotEnoughPoop.SetActive(false);
        NotEnoughWater.SetActive(false);
        NotEnoughMoney.SetActive(false);
        RefillWater.SetActive(false);
    }

    void ResetTimer()
    {
        disappearTimer = DISAPPEAR_TIME;
    }

    void ShowPoop()
    {
        HideAll();
        NotEnoughPoop.SetActive(true);
        ResetTimer();
    }

    void ShowWater()
    {
        HideAll();
        NotEnoughWater.SetActive(true);
        ResetTimer();
    }

    void ShowMoney()
    {
        HideAll();
        NotEnoughMoney.SetActive(true);
        ResetTimer();
    }

    void ShowRefillWater()
    {
        HideAll();
        RefillWater.SetActive(true);
        ResetTimer();
    }
}
