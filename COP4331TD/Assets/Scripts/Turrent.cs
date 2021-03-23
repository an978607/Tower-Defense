using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Turrent : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public Transform partToRotate;
    public string enemyTag = "Enemy";
    public float turrentspeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    // Find target to aim at in range
    void updateTarget()
    {
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
        /* Test this out */
        GameObject[] tag_1 = GameObject.FindGameObjectsWithTag("Enemy");  
        GameObject[] tag_2 = GameObject.FindGameObjectsWithTag("Enemy2");  
        GameObject[] tag_3 = GameObject.FindGameObjectsWithTag("Enemy3");

        GameObject[] intermediate = tag_2.Concat(tag_3).ToArray();
        
        GameObject[] enemies = tag_1.Concat(intermediate).ToArray();
        
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // no target found
        if (target == null)
            return;

        //rotate to aim at current found target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turrentspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    // Shows outline of the weapon range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}