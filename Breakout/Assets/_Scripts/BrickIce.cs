using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickIce : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        endurance = 3;
    }

    void Slide()
    {
        Debug.Log("Sliding to the side");
    }
}
