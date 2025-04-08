using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public int endurance = 1;
    public UnityEvent IncreaseScore;

    protected void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball") {
            BounceBall(collision);
        }
    }

    protected void BounceBall(Collision collision)
    {
        Vector3 direction = collision.contacts[0].point - transform.position; //a vector from the center to the point where the ball hit
        direction = direction.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direction;
        endurance--;
        Debug.Log("I took a hit! endurance = " + endurance);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endurance <= 0)
        {
            IncreaseScore.Invoke();
            Destroy(this.gameObject);
        }
    }
}
