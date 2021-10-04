using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    public GameObject PoopCounterText;
    Text poopText;

    public GameObject WaterCounterText;
    Text waterText;

    public GameObject MoneyCounterText;
    Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        poopText = PoopCounterText.GetComponent<Text>();
        waterText = WaterCounterText.GetComponent<Text>();
        moneyText = MoneyCounterText.GetComponent<Text>();
        poopText.text = "= 0";
        waterText.text = "= 0/" + ResourceManager.MAX_WATER;
        moneyText.text = "= " + ResourceManager.MoneyCounter + "b";
    }

    // Update is called once per frame
    void Update()
    {
        poopText.text = "= " + ResourceManager.PoopCounter;
        waterText.text = "= " + ResourceManager.WaterCounter + "/" + ResourceManager.MAX_WATER;
        moneyText.text = "= " + ResourceManager.MoneyCounter + "b";
    }
}
