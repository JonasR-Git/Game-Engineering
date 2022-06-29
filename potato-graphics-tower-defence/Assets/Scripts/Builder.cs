using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    //Creating a Singleton Pattern Style to have only 1 Builder in every Scene
    public static Builder instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only one Builder should be instanciate");
            return;
        }
        instance = this;
    }



    private TurretPrefabs turretToBuild;

    public GameObject MachineGunPrefab;
    
    private Node selectedNode;



    public void SetTurretToBuild(TurretPrefabs turret)
    {
        turretToBuild = turret;
    }

    public TurretPrefabs GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
    }

    public void DeselectNode()
    {
        selectedNode = null;
    }

    public bool CanBuildTurret { get { return turretToBuild != null; } }
}
