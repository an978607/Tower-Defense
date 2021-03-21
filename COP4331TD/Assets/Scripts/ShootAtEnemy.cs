using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtEnemy : MonoBehaviour {

    private GameObject turret;
    private TowerStats towerStats;
    private float deltaTime;
    private float DPS = 25.0f, rateOfFire = 0.25f;
    private string towerType = "basic";

    // using a queue because the first enemy in is the first enemy that should
    // be fired at, and then the next enemy, and so on
    // firing at enemies should be in order of which was in the range first
    Queue enemies;

    void Start() {
        //turret = transform.parent.gameObject;
        turret = this.transform.parent.gameObject;
        enemies = new Queue();
        towerStats = GetComponent<TowerStats>();
        deltaTime = 0.0f;

        //rateOfFire = towerStats.fireRate;
        //DPS = towerStats.damagePerShot;
        //print(rateOfFire + " " + DPS);

    }

    void Update() {

        // update how long its been since last frame
        deltaTime += Time.deltaTime;
        // when the amount of surpassed time is greater than the time it takes
        // between shots, able to shoot again
        if (deltaTime >= rateOfFire) {
            if(fire()) {
                deltaTime = 0.0f;
        }
        }

        if (enemies == null) {
            return;
        }

        if ((int)enemies.Count != 0) {
            // turn towards the first enemy in the queue
            GameObject firstEnemy = (GameObject) enemies.Peek();
            Vector3 targetDirection = firstEnemy.transform.position - turret.transform.position;
            float singleStep = 1000 * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(turret.transform.forward, targetDirection, singleStep, 0.0f);
            turret.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }


    void OnCollisionEnter(Collision collision) {
        // if the collision with the range sphere has the Enemy tag, it is an enemy
        // then, we enqueue them so we can fire at them when its time to
        // shoot at that enemy
        if (collision.collider.tag.ToLower().Contains("enemy")) {
            enemies.Enqueue(collision.gameObject);
        }
    }

    void OnCollisionExit (Collision collision) {
        // an enemy not in range (i.e. leaves the range) cannot be fired at
        // in this case, dequeue
        // could cause weird issues later on. will need intensive testing
        if (collision.collider.tag.ToLower().Contains("enemy")) {
            enemies.Dequeue();
        }
     }

     // attempts to fire at the first enemy in the queue
     // if fails (such as if queue is empty or there is no queue), return false
     // otherwise, return true
     bool fire() {
         if (enemies == null) {
             return false;
         }
         else if ((int) enemies.Count <= 0) {
             return false;
         }

         GameObject enemy = (GameObject) enemies.Peek();
         // check if enemy is null or not
         // seems to be a bug where the enemy becomes null but never dequeues
         if (enemy == null) {
             enemies.Dequeue();
             return false;
         }

         EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
         if (enemyStats == null) print("enemyStats is null");

         print("Firing at enemy");
         bool enemyIsDead = ( (EnemyStats) enemy.GetComponent<EnemyStats>()).takeDamage(DPS, towerType);
         if (enemyIsDead) {
             enemies.Dequeue();
         }
         return true;
     }
}
