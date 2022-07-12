using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    //Creating a Singleton Pattern Style to have only 1 Builder in every Scene
    public static Builder instance;
    PlayerStats player;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only one Builder should be instanciate");
            return;
        }
        instance = this;
    }

    private void Start() 
    {
        player = PlayerStats.instance;
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
    

    public void BuildTurretOnNode (Node node)
    {
        if (player.getMoney() < turretToBuild.cost)
        {
            Debug.Log("not enough money to build the turret");
            return;
        }

        GameObject turret = (GameObject)Instantiate(turretToBuild.turretPrefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("turret Builded");
        player.ChangeMoney(-turretToBuild.cost);
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
