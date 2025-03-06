 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int limitX = 23;
    [SerializeField] public float paddleSpeed = 80.0f;
    Vector3 mousePosition3d;
    Vector3 mousePosition2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition2d = Input.mousePosition;
        mousePosition2d.z = - Camera.main.transform.position.z;

        mousePosition3d = Camera.main.ScreenToWorldPoint(mousePosition2d);

        //if (Input.GetKey(KeyCode.LeftArrow)) { 
        //    transform.Translate(Vector3.up * paddleSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.down * paddleSpeed * Time.deltaTime);
        //}

        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * paddleSpeed * Time.deltaTime);

        Vector3 pos = transform.position;
        //pos.x = mousePosition3d.x;

        if (pos.x < -limitX)
        {
            pos.x = -limitX;
        }
        else if (pos.x > limitX) { 
            pos.x = limitX;
        }
        this.transform.position = pos;
        
    }
}
