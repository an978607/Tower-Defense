using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour {
    [HideInInspector]
    public int costToSell, enemiesDefeated, shotsFired;
    public float towerRange, fireRate, damagePerShot;
    public string towerType;
}
