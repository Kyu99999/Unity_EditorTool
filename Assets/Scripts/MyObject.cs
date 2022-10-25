using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum COLOR
{   
    RED,
    GREEN,
    BLUE,
    ORIGINAL,
}

public class MyObject : MonoBehaviour
{
    private MeshRenderer renderer = null;

    private bool isOriMaterial = false;
    private bool isRenderer = false;
    private bool isMaterial = false;

    public MeshRenderer Renderer
    {
        get
        {
            if (renderer == null)
            {
                renderer = GetComponent<MeshRenderer>();
            }

            return renderer;
        }
    }

   
    private Material oriMaterial;
    public Material OriMaterial
    {
        get
        {
            if(oriMaterial == null)
            {
                oriMaterial = new Material(Renderer.sharedMaterial);
                isOriMaterial = true;
            }

            return oriMaterial;
        } 
        set
        {
            oriMaterial = value;
        }
    }

    /*
     Instantiating material due to calling renderer.material during edit mode. This will leak materials into the scene. You most likely want to use renderer.sharedMaterial instead.
     */

    public void ChangeColor(COLOR color)
    {
        Material nextMaterial = new Material(Renderer.sharedMaterial);
        
        if (OriMaterial == null)
        {
            OriMaterial = new Material(Renderer.sharedMaterial);
            isOriMaterial = true;
        }

        switch (color)
        {
            case COLOR.RED:
                nextMaterial.SetColor("_Color", Color.red);
                break;
            case COLOR.GREEN:
                nextMaterial.SetColor("_Color", Color.green);
                break;
            case COLOR.BLUE:
                nextMaterial.SetColor("_Color", Color.blue);
                break;
            case COLOR.ORIGINAL:
                nextMaterial = OriMaterial;
                break;
            default:
                break;
        }

        Renderer.sharedMaterial = nextMaterial;
    }
}
