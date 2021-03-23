using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float bulletSpeed = 70f;
    public bool hit;
    
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        //target is no longer visable 
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = bulletSpeed * Time.deltaTime;

        //something has been hit
        if (dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        //continue moving towards target
        transform.Translate(dir.normalized * distancePerFrame, Space.World);

    }

    void HitTarget()
    {
        // call enemy stats to take damage and destroy enemy
        // bool for other methods...
        hit = target.gameObject.GetComponent<EnemyStats>().takeDamage(5.0f);
//        Destroy(target.gameObject);
        Destroy(gameObject); // destroy the bullet
    }
}
