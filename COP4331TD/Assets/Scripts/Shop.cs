
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public GameObject FundsDialogue;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void purchaseWeapon1()
    {
        Debug.Log("Weapon1 Purchased");
        SufficentFundsCheck(50);
        buildManager.setWeaponToBuild(buildManager.weapon1Prefab);
    }
    public void purchaseWeapon2()
    {
        Debug.Log("Weapon2 Purchased");
        SufficentFundsCheck(100);
        buildManager.setWeaponToBuild(buildManager.weapon2Prefab);
    }
    public void purchaseWeapon3()
    {
        Debug.Log("Weapon3 Purchased");
        SufficentFundsCheck(150);
        buildManager.setWeaponToBuild(buildManager.weapon3Prefab);
    }

    void SufficentFundsCheck(int price)
    {
        if (CurrencyManager.currentBalance < price)
        {
            FundsDialogue.SetActive(true);
            return;
        }
        
        CurrencyManager.purchaseItem(price);
    }

    public void InsufficentFundsAcknowledged()
    {
        FundsDialogue.SetActive(false);
    }

}
