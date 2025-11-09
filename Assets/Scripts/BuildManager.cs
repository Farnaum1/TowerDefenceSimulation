using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;

    // A singleton instance, basically a globally accessible instance of the BuildManager
    public static BuildManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        // Ensure only one instance of BuildManager exists
        instance = this;
    }


    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }


    void Update()
    {
        
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}
