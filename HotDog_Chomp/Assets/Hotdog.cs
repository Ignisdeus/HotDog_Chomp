using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotdog : MonoBehaviour
{
    public Vector3 startingPos; 
    void Awake()
    {
        startingPos = transform.position; 
    }
}
