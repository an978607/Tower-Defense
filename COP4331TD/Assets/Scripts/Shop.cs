
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Turrent_BluePrint rayGun;
    public Turrent_BluePrint GattlingGun;
    public Turrent_BluePrint CowAcid;

    BuildManager buildManager;
    public GameObject FundsDialogue;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void selectRayGun()
    {
        Debug.Log("RayGun Selected");
        buildManager.selectWeaponToBuild(rayGun);
    }
    public void selectGattling()
    {
        Debug.Log("Gattling Selected");
        buildManager.selectWeaponToBuild(GattlingGun);
    }
    public void selectAcid()
    {
        Debug.Log("Cow Acid Selected");
        buildManager.selectWeaponToBuild(CowAcid);
    }

    public void InsufficentFundsAcknowledged()
    {
        FundsDialogue.SetActive(false);
    }

}
