using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 offsetPos;


    private Color normalColor;
    private Renderer render;

    private GameObject turret = null;

    Builder builder;

    private void Start()
    {
        render = GetComponent<Renderer>();
        normalColor = render.material.color;

        builder = Builder.instance;
    }

    private void OnMouseEnter()
    {
        render.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        if (builder.GetTurretToBuild() == null)
        {
            return;
        }
        render.material.color = normalColor;
    }

    private void OnMouseDown()
    {
        if(builder.GetTurretToBuild() == null)
        {
            return; // TurretToBuild shouldn't be null
        }

        if (turret != null)
        {
            //TODO sale the tower options
            return;
        }
        BuildTurret();
    }

    private void BuildTurret()
    {
        GameObject turretToBuild = Builder.instance.GetTurretToBuild();
        Instantiate(turretToBuild, transform.position + offsetPos, transform.rotation);
    }
}
