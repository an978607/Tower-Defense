using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject weapon; 

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if(buildManager.getWeaponToBuild() == null)
        {
            return;
        }
        if(weapon != null)
        {
            //can't build because something is already on this node. 
            return;
        }

        //build weapon
        GameObject weaponToBuild = BuildManager.instance.getWeaponToBuild();
        weapon = (GameObject)Instantiate(weaponToBuild, transform.position + positionOffset, transform.rotation);
    }
    void OnMouseEnter()
    {
        if (buildManager.getWeaponToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;

    }
}
