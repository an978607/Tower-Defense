﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public GameObject spawner;
    public float maxHealth, speed;
    public string type;

    private float currentHealth;


    // Start is called before the first frame update
    void Start() {
        
        // Enemies of type 1 have health of 10, type 2 have 10, last is 30
        if(this.gameObject.CompareTag("Enemy")){
            currentHealth = 30;
            speed = 10;
        } else if(this.gameObject.CompareTag("Enemy2")){
            currentHealth = 50;
            speed = 30;
        } else{
            currentHealth = 100;
            speed = 2;
        }
        //currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (currentHealth <= 0) {
            destroyEnemy();
            print("Enemy is dead");
            Destroy(this.gameObject);
        }
    }

    // call from another script to deal damage
//    public void takeDamage(float dmg, string damageType) {
    public bool takeDamage(float dmg){
        // basic attacks cannot hurt metal enemies **Kevin Deleted this for now**
//        if (type == "metal" && damageType == "basic") {
//            return false;
//        }

        currentHealth -= dmg;
        if (currentHealth <= 0) {
            return true;
        }
        else return false;
    }

    void destroyEnemy() {
        spawner.GetComponent<Spawn2>().destroyEnemy();
        Destroy(this.gameObject);
    }
}
