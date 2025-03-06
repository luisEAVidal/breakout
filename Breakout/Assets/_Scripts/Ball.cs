using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float ballSpeed = 15.0f;
    bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        var playerGO = GameObject.FindGameObjectWithTag("Player");
        Vector3 initialPosition = playerGO.transform.position;
        initialPosition.y += 3;
        this.transform.position = initialPosition;
        this.transform.SetParent(playerGO.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Cancel")) // in PS5 controller: Cancel <=> X
        {
            if (!gameStarted)
            {
                gameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = ballSpeed * Vector3.up;
            }
        }
    }
}
