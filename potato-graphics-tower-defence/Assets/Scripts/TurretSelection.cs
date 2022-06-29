using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSelection : MonoBehaviour
{

    public TurretPrefabs machineGun;
    public TurretPrefabs LaserTurret;

    Builder builder;

    private void Start()
    {
        builder = Builder.instance;
    }

    public void SelectMachineGun()
    {
        builder.SetTurretToBuild(machineGun);
        Debug.Log("MachineGun");
    }

    public void SelectAnotherGun()
    {
        //TODO to add with new turrets
    }
}
