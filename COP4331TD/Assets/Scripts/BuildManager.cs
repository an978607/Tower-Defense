using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More then one buildMannager");
        }
        instance = this;
    }

    public GameObject weapon1Prefab;
    public GameObject weapon2Prefab;
    public GameObject weapon3Prefab;

    public GameObject FundsDialoge;

    private Turrent_BluePrint weaponToBuild;


    //Node is empty and can be built on 
    public bool CanBuild { get { return weaponToBuild != null; } }
    //Does the player have enough 
    public bool HasMoney { get { return CurrencyManager.currentBalance >= weaponToBuild.cost; } }

    public void BuildWeaponOn(Node node)
    {
        if (CurrencyManager.currentBalance < weaponToBuild.cost)
        {
            FundsDialoge.SetActive(true);
            return;
        }

        //purchase upon build 
        CurrencyManager.currentBalance -= weaponToBuild.cost;
        GameObject weapon = (GameObject)Instantiate(weaponToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.weapon = weapon;
    }

    public void selectWeaponToBuild(Turrent_BluePrint weapon)
    {
        weaponToBuild = weapon;
    }

}
