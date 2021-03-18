using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public Text currencyDisplay;
    public static int currentBalance;
    public int currentBalanceRef = currentBalance;
    float timeLeft = 86400f;

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
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            currentBalance += 100;
            PlayerPrefs.SetInt("CurrentBalance", currentBalance);
            currencyDisplay.text = currentBalance.ToString();
        }
    }

    public static void AddBalance(int amount)
    {
        currentBalance += amount;
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
    }

    public static void purchaseItem(int price)
    {
        currentBalance -= price;
        if (currentBalance <= 0)
            AddBalance(500);
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
        Debug.Log("Balance : " + PlayerPrefs.GetInt("CurrentBalance"));
    }
}

