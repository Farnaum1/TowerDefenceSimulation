using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Movement")]
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";

    [Header("Shooting")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Start()
    {
        // Repeat the UpdateTarget method every 0.5 seconds
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void Update()
    {
        
        // Don't do anything if there's no target
        if (target == null)
        return;

        // Handle shooting
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

        Movement();

    }

    void Shoot()
    {
        // A temporary bullet game object to store the instantiated projectile
        // Object casting is necessary because Instantiate returns a generic Object type

        GameObject bulletGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the Bullet component from the instantiated bullet game object
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            // Tell the bullet to seek the target
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        // Store all enemies on the scene in an array
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Default shortest distance to the enemy is infinity
        float shortestDistance = Mathf.Infinity;

        // By default, there is no nearest enemy
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

    private void Movement()
    {
        //  Calculate the direction to the target
        Vector3 direction = target.position - transform.position;

        // Create a rotation that looks in the direction of the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Convert the rotation to Euler angles
        Vector3 rotation = lookRotation.eulerAngles;

        // Only rotate on the y axis
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
