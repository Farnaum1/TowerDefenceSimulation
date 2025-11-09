using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] float moveSpeed = 1f;
    public int enemyHealth = 100;

    [Header("Refrences")]
    private EnemyPath enemyPath;
    public Spawner spawner;

    private Vector3 targetPosition;
    private int currentWaypointIndex = 0;
    private float waypointTolerance = 0.1f;


    private void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    private void Awake()
    {
        // Find the EnemyPath class on awake before Start or Enable methods are called
        enemyPath = GameObject.FindObjectOfType<EnemyPath>();
    }

    private void OnEnable()
    {
        SetTargetPosition();
    }

    void Update()
    {
        UpdateWaypoint();
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void SetTargetPosition()
    {
        currentWaypointIndex = 0;
        targetPosition = enemyPath.GetWaypointPosition(currentWaypointIndex);
    }

    private void UpdateWaypoint()
    {
        // Calculate the distance to the target position
        float relativeDistance = (transform.position - targetPosition).magnitude;

        if (relativeDistance < waypointTolerance)
        {
            if (currentWaypointIndex == 6) 
            {
                gameObject.SetActive(false);
                return;
                // Damage the tower
            }
            currentWaypointIndex++;
            targetPosition = enemyPath.GetWaypointPosition(currentWaypointIndex);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (spawner != null)
        {
            spawner.waves[spawner.currentWaveIndex].enemiesLeft--;
            Debug.Log("Enemies Left: " + spawner.waves[spawner.currentWaveIndex].enemiesLeft);
        }
        else
        {
            Debug.LogWarning("Spawner reference is missing on enemy!");
        }
        Destroy(gameObject);
    }


}
