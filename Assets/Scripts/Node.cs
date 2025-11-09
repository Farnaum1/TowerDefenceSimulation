using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    private Color starColor;

    private Renderer rend;

    private GameObject turret;


    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        starColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        // Refrence to the turret to build from BuildManager singleton
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();

        // Using casting to convert the generic Object type returned by Instantiate to a GameObject type
        turret = (GameObject) Instantiate(turretToBuild, transform.position, transform.rotation);


    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
    }


    void Update()
    {
        
    }
}
