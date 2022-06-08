using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;


    private Color normalColor;
    private Renderer render;

    private GameObject turret = null;

    private void Start()
    {
        render = GetComponent<Renderer>();
        normalColor = render.material.color;
    }

    private void OnMouseEnter()
    {
        render.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        render.material.color = normalColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            //TODO sale the tower options
            return;
        }

        
    }
}
