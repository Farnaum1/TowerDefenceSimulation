using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;


    void Start()
    {
        
    }

    void Update()
    {
        if (target == null)
        {
            // Always use return to exit the method early because destroy will not stop the method

            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        // Time it takes to travel this frame
        float distanceThisFrame = speed * Time.deltaTime;

        // Check if the bullet would reach or overshoot the target this frame
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // Move the bullet towards the target
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


    }

    public void Seek (Transform _target)
    {
        target = _target;
    }

    private void HitTarget()
    {
        // Add effects here (explosion, sound, etc.)
        Destroy(gameObject);
    }
}
