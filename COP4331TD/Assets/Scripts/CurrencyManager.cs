using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public Text currencyDisplay;
    public static int currentMoney;
    public static bool quit = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentMoney"))
        {
            currentMoney = PlayerPrefs.GetInt("CurrentMoney");
        }
        else
        {
            currentMoney = 500;
            PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        }

         currencyDisplay.text = currentMoney.ToString();
     }

// Update is called once per frame
    void Update()
    {
    }

    public void AddCurrency(int amount)
    {
        currentMoney += amount;
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        // currencyDisplay.text = currentMoney.ToString();
    }

    public void quitLevel()
    {
        quit = true;
        updateCurrency();
    }

    private void updateCurrency()
    {
        if (quit != true)
            return;
        currentMoney -= 100;
        if (currentMoney <= 0)
            AddCurrency(500);
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        quit = false;
    }
}

