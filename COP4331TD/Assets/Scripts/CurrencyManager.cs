using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public Text currencyDisplay;
    public static int currentBalance;
    public static bool quit = false;
    public int currentBalanceRef = currentBalance;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentBalance"))
        {
            currentBalance = PlayerPrefs.GetInt("CurrentBalance");
        }
        else
        {
            currentBalance = 500;
            PlayerPrefs.SetInt("CurrentBalance", currentBalance);
        }

        currencyDisplay.text = currentBalance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddCurrency(int amount)
    {
        currentBalance += amount;
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
    }

    public void quitLevel()
    {
        quit = true;
        updateBalance();
    }

    private void updateBalance()
    {
        if (quit != true)
            return;
        currentBalance -= 100;
        if (currentBalance <= 0)
            AddCurrency(500);
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
        quit = false;
    }
}