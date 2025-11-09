using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 4f;
    public int damage = 10;
    public string enemyTag = "Enemy";
    [SerializeField] EnemyController enemyController;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(enemyTag))
        {

            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
                Destroy(gameObject);
                Debug.Log("Hit enemy for " + damage + " damage.");
            } 
  
        }
    }
}
