using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStone : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        brickHealth = 9;
        hitDamange = transform.GetComponentInParent<BricksManager>().BallDamage;
    }

}
