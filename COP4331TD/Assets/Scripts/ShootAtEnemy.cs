using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtEnemy : MonoBehaviour {

    private GameObject turret;
    // using a queue because the first enemy in is the first enemy that should
    // be fired at, and then the next enemy, and so on
    // firing at enemies should be in order of which was in the range first
    Queue enemies;

    void Start() {
        turret = transform.parent.gameObject;
        enemies = new Queue();
    }

    void Update() {

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
        if (collision.collider.tag == "Enemy") {
            enemies.Enqueue(collision.gameObject);
            print("enqueye");
        }
    }

    void OnCollisionExit (Collision collision) {
        // an enemy not in range (i.e. leaves the range) cannot be fired at
        // in this case, dequeue
        // could cause weird issues later on. will need intensive testing
        if (collision.collider.tag == "Enemy") {
            enemies.Dequeue();
        }
     }
}
