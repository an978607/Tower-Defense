
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void purchaseWeapon1()
    {
        Debug.Log("Weapon1 Purchased");
        buildManager.setWeaponToBuild(buildManager.weapon1Prefab);
    }
    public void purchaseWeapon2()
    {
        Debug.Log("Weapon2 Purchased");
        buildManager.setWeaponToBuild(buildManager.weapon2Prefab);
    }
    public void purchaseWeapon3()
    {
        Debug.Log("Weapon3 Purchased");
        buildManager.setWeaponToBuild(buildManager.weapon3Prefab);
    }

}
