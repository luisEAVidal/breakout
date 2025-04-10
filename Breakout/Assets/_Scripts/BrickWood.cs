using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWood : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        brickHealth = 6;
        hitDamange = transform.GetComponentInParent<BricksManager>().BallDamage;
    }

}
