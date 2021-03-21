using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public GameObject spawner;
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
            destroyEnemy();
            print("Enemy is dead");
            Destroy(this.gameObject);
        }
    }

    // call from another script to deal damage
    public bool takeDamage(float dmg, string damageType) {
        // basic attacks cannot hurt metal enemies
        if (type == "metal" && damageType == "basic") {
            return false;
        }

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
