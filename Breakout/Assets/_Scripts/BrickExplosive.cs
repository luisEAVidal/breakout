using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExplosive : Brick
{
    // Start is called before the first frame update
    public int explosionRadius = 1;
    void Start()
    {
        
    }

    void Explode()
    {
        Debug.Log("Exploding!!!");
    }
}
