using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public float maxHealth, speed;
    public string type;

    private float currentHealth;


    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (currentHealth <= 0) {
            Destroy(this);
        }
    }

    // call from another script to deal damage
    public bool takeDamage(float dmg) {
        currentHealth -= dmg;
        if (currentHealth <= 0) {
            return true;
        }
        else return false;
    }
}
