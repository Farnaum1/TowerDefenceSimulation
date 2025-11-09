using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;
    public GameObject cannonPrefab;
    public GameObject ballistaPrefab;

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


    void Update()
    {
        
    }

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }



}
