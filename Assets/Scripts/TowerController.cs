using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Header("Targeting")]
    [SerializeField] float range = 5f;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] private string enemyTag = "Enemy"; // Make this serializable and check in Inspector

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] Transform shootingPoint;

    [HideInInspector] public Vector3 shootingDirection;

    float fireCooldown = 0f;



    void Start()
    {
        
    }

    void Update()
    {
        ShootingDirection();
    }


    private void ShootingDirection()
    {
        fireCooldown -= Time.deltaTime;
        Transform target = FindNearestEnemy();

        if (target == null) return;

        shootingDirection = (target.position - shootingPoint.position).normalized;

        if (fireCooldown <= 0f)
        {
            Shoot(shootingDirection);
            fireCooldown = 1f / fireRate;
        }
    }


    Transform FindNearestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range, enemyLayer);
        Transform nearest = null;
        float minDist = float.MaxValue;

        foreach (var hit in hits)
        {
            if (!hit.CompareTag(enemyTag)) continue;
            float d = (hit.transform.position - transform.position).sqrMagnitude;
            if (d < minDist)
            {
                minDist = d;
                nearest = hit.transform;
            }
        }

        return nearest;
    }


    void Shoot (Vector3 direction)
    {
        if (projectilePrefab == null || spawnPoint == null) return;

        GameObject p = Instantiate (projectilePrefab, spawnPoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = p.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawRay(spawnPoint.position, shootingDirection * range);


    }

}
