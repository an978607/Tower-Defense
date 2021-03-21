using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject weapon;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        //cant build
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (weapon != null)
        {
            //can't build because something is already on this node. 
            return;
        }

        //build weapon
        buildManager.BuildWeaponOn(this);
    }
    void OnMouseEnter()
    {
        //cant build
        if (!buildManager.CanBuild)
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
