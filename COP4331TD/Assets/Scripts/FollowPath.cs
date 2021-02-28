using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour {

    public PathCreator pathCreator;
    public float speed;
    float distanceTraveled;


    // Start is called before the first frame update
    void Start() {
        distanceTraveled -= 0.0001f;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
    }

    // Update is called once per frame
    void Update() {
        distanceTraveled -= speed*Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
    }
}
