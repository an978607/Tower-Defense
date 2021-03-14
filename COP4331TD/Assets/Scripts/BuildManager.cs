using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More then one buildMannager");
        }
        instance = this;
    }

    public GameObject weapon1Prefab;
    public GameObject weapon2Prefab;
    public GameObject weapon3Prefab;

    private GameObject weaponToBuild;


    public GameObject getWeaponToBuild()
    {
        return weaponToBuild;
    }

    public void setWeaponToBuild(GameObject weapon)
    {
        weaponToBuild = weapon;
    }

   
}
