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


    [Header("Preplaced Turret")]
    public GameObject turret = null;

    Builder builder;
    PlayerStats player;

    private void Start()
    {
        render = GetComponent<Renderer>();
        normalColor = render.material.color;

        builder = Builder.instance;
        player = PlayerStats.instance;

        if (turret != null)
        {
            turret = (GameObject)Instantiate(turret, GetBuildPosition(), Quaternion.identity);
        }


    }

    public void PreBuildTurret()
    {
        //GameObject turret = (GameObject)Instantiate(turret, GetBuildPosition(), Quaternion.identity);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offsetPos;
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
            Debug.Log("Already placed a tower on this tile");
            //TODO sale the tower options
            return;
        }
        builder.BuildTurretOnNode(this);
    }
}
