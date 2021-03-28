using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public Text currencyDisplay;
    public static int currentBalance;
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
            currentBalance = 200;
            PlayerPrefs.SetInt("CurrentBalance", currentBalance);
        }

         currencyDisplay.text = currentBalance.ToString();
     }

// Update is called once per frame
    void Update()
    {

    }

    public static void AddBalance(int amount)
    {
        currentBalance += amount;
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
    }
    
    public int getBalance()
    {
        return currentBalance;
    }

    public static void purchaseItem(int price)
    {
        currentBalance -= price;
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
        Debug.Log("Balance : " + PlayerPrefs.GetInt("CurrentBalance"));
    }
}

