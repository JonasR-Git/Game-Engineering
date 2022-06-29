using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 offsetPos;


    private Color normalColor;
    private Renderer render;

    private GameObject turret = null;

    Builder builder;
    PlayerStats player;

    private void Start()
    {
        render = GetComponent<Renderer>();
        normalColor = render.material.color;

        builder = Builder.instance;
        player = PlayerStats.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!builder.CanBuildTurret)
        {
            return;
        }
        render.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        render.material.color = normalColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!builder.CanBuildTurret)
        {
            return; // TurretToBuild shouldn't be null
        }

        if (turret != null)
        {
            //TODO sale the tower options
            return;
        }
        BuildTurret(builder.GetTurretToBuild());
    }

    private void BuildTurret(TurretPrefabs turretToBuild)
    {
 
        if(player.getMoney() < turretToBuild.cost)
        {
            Debug.Log("not enough money to build the turret");
            return;
        }

        player.ChangeMoney(turretToBuild.cost);
        Instantiate(turretToBuild.turretPrefab, transform.position + offsetPos, transform.rotation);
        Debug.Log("turret Builded");
    }
}
