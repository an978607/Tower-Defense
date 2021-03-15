using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class detectAndFire : MonoBehaviour {

    // will change per tower type
    public bool showRange = false;
    public Material rangeMaterial;


    private GameObject sphere; // radius/range of tower
    private float scaledRadius; // how much to scale the radius
    private Renderer sphereRenderer;
    private MeshRenderer meshRenderer;
    private Rigidbody rigidBody;
    private ShootAtEnemy detector;
    private float scale = 12.5f;

    public TowerStats towerStats;

    // gets this information from TowerStats class for the tower
    private float radius, fireRate, damagePerShot;
    void Start() {
        // get stats from TowerStats class
        radius = towerStats.towerRange;
        fireRate = towerStats.fireRate;
        damagePerShot = towerStats.damagePerShot;


        // create and add the sphere to the tower
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.SetParent(transform);
        sphere.transform.localPosition = new Vector3(0, 0, 0);
        sphere.transform.localScale = new Vector3(scaledRadius, scaledRadius, scaledRadius);
        sphereRenderer = sphere.GetComponent<Renderer>();
        meshRenderer = sphere.GetComponent<MeshRenderer>();
        rigidBody = sphere.AddComponent<Rigidbody>();

        // locks the sphere to where the tower is
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        sphere.AddComponent<ShootAtEnemy>();

        // sets the material of the range
        // usually, a semi-transparent material to see through but also see the
        // range itself
        meshRenderer.material = rangeMaterial;
    }

    // Update is called once per frame
    void Update() {
        // radius scaling
        scaledRadius = towerStats.towerRange * scale;
        sphere.transform.localScale = new Vector3(scaledRadius, scaledRadius, scaledRadius);

        // toggleable range showing
        if (showRange) {
            sphereRenderer.enabled = true;
        }
        else {
            sphereRenderer.enabled = false;
        }


    }

}
