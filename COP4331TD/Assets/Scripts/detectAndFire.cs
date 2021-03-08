using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class detectAndFire : MonoBehaviour {

    public float radius = 1.0f, fireRate, damagePerShot;
    public bool showRange = false;
    public Material rangeMaterial;

    private GameObject sphere;
    private float scaledRadius;
    private Renderer sphereRenderer;
    private MeshRenderer meshRenderer;
    private Rigidbody rigidBody;
    private ShootAtEnemy detector;
    private float scale = 12.5f;
    void Start() {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.SetParent(transform);
        sphere.transform.localPosition = new Vector3(0, 0, 0);
        sphere.transform.localScale = new Vector3(scaledRadius, scaledRadius, scaledRadius);
        sphereRenderer = sphere.GetComponent<Renderer>();
        meshRenderer = sphere.GetComponent<MeshRenderer>();
        rigidBody = sphere.AddComponent<Rigidbody>();

        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        sphere.AddComponent<ShootAtEnemy>();

        meshRenderer.material = rangeMaterial;
    }

    // Update is called once per frame
    void Update() {
        scaledRadius = radius * scale;
        sphere.transform.localScale = new Vector3(scaledRadius, scaledRadius, scaledRadius);

        if (showRange) {
            sphereRenderer.enabled = true;
        }
        else {
            sphereRenderer.enabled = false;
        }


    }

}
