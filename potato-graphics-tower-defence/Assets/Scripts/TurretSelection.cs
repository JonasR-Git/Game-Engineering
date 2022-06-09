using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSelection : MonoBehaviour
{
    Builder builder;

    private void Start()
    {
        builder = Builder.instance;
    }

    public void PurchaseMachineGun()
    {
        builder.SetTurretToBuild(builder.MachineGunPrefab);
        Debug.Log("MachineGun");
    }

    public void PurchaseAnotherGun()
    {
        //TODO to add with new turrets
    }
}
