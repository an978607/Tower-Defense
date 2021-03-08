using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtEnemy : MonoBehaviour {

    private GameObject turret, currentEnemy, nextEnemy;
    Queue enemies;

    void Start() {
        turret = transform.parent.gameObject;
        currentEnemy = null;
        nextEnemy = null;
        enemies = new Queue();
    }

    void Update() {

        /*if (currentEnemy != null) {
            Vector3 targetDirection = currentEnemy.transform.position - turret.transform.position;
            float singleStep = 1000 * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(turret.transform.forward, targetDirection, singleStep, 0.0f);
            turret.transform.rotation = Quaternion.LookRotation(newDirection);
        }*/

        if ((int)enemies.Count != 0) {
            GameObject firstEnemy = (GameObject) enemies.Peek();
            Vector3 targetDirection = firstEnemy.transform.position - turret.transform.position;
            float singleStep = 1000 * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(turret.transform.forward, targetDirection, singleStep, 0.0f);
            turret.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Enemy") {
            /*if (currentEnemy == null) {
                currentEnemy = collision.gameObject;
                print("Detected enemy");
            }
            else if (nextEnemy == null) {
                nextEnemy = collision.gameObject;
            }*/

            enemies.Enqueue(collision.gameObject);
            print("enqueye");
        }
    }

    void OnCollisionExit (Collision collision) {
        if (collision.collider.tag == "Enemy") {
            /*currentEnemy = nextEnemy;
            nextEnemy = null;*/
            enemies.Dequeue();
        }
     }
}
