using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour

{

    BuildManager buildManager; // Refrence to the singelton BuildManager

    private void Start()
    {
        // Get the instance of the BuildManager
        buildManager = BuildManager.instance; 
    }


    public void PurchaseCannon()
    {
        Debug.Log("Cannon Purchased");

        // Set the turret to build in the BuildManager
        buildManager.SetTurretToBuild(buildManager.cannonPrefab); 
    }

    public void PurchaseBallista()
    {
        Debug.Log("Ballista Purchased");

        // Set the turret to build in the BuildManager
        buildManager.SetTurretToBuild(buildManager.ballistaPrefab);
    }

    public void PurchaseCatapult()
    {
        Debug.Log("Catapult Purchased");
    }

    public void PurchaseTurret()
    {
        Debug.Log("Turret Purchased");
    }
}
