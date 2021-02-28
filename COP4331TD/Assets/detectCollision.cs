﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectCollision : MonoBehaviour {

    public Text lives;
    public GameObject level;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Enemy") {
            level.GetComponent<startLevel>().loseLives(1);
            Destroy(collision.gameObject);
        }
    }
}
