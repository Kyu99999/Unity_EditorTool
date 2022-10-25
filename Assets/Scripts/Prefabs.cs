using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public static Prefabs instance 
    {
        get
        {
            return instance;
        }

    }

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject capsulePrefab;
}
