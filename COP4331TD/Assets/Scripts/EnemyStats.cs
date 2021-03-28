using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public GameObject spawner;
    public float maxHealth, speed;
    public string type;
    public int scoreValue;

    private float currentHealth;


    // Start is called before the first frame update
    void Start() {

        // Enemies of type 1 have health of 10, type 2 have 10, last is 30
        if(this.gameObject.CompareTag("Enemy")){
            currentHealth = 30;
            speed = 10;
            scoreValue = 100;
        } else if(this.gameObject.CompareTag("Enemy2")){
            currentHealth = 50;
            speed = 30;
            scoreValue = 200;
        } else{
            currentHealth = 100;
            speed = 2;
            scoreValue = 300;
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
    public bool takeDamage(float dmg, string damageType) {
    //public bool takeDamage(float dmg){
        // basic attacks cannot hurt metal enemies
        if (type == "metal" && damageType == "basic") {
            return false;
        }

        if (damageType == "freeze") {
            this.GetComponent<FollowPath>().freezeEnemy(0.5f);
        }

        currentHealth -= dmg;
        if (currentHealth <= 0) {
            return true;
        }
        else return false;
    }

    void destroyEnemy() {
        spawner.GetComponent<Spawn2>().destroyEnemy();
        spawner.GetComponent<ScoreManager>().AddScore(scoreValue);
        Destroy(this.gameObject);
    }


}
