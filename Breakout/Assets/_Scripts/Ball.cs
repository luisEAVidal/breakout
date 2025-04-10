using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 15.0f;
    bool gameStarted = false;
    Vector3 lastPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Rigidbody rigidbody;
    private BordersController bordersController;
    public Preferences PreferencesScriptableObject;
    public UnityEvent DestroyedBall;

    private void Awake()
    {
        bordersController = GetComponent<BordersController>();
    }


    // Start is called before the first frame update
    void Start()
    {
        var playerGO = GameObject.FindGameObjectWithTag("Player");
        Vector3 initialPosition = playerGO.transform.position;
        initialPosition.y += 2;
        this.transform.position = initialPosition;
        this.transform.SetParent(playerGO.transform);
        rigidbody = this.GetComponent<Rigidbody>();

        try
        {
            PreferencesScriptableObject.Load();
            ballSpeed = PreferencesScriptableObject.currentBallSpeed;
        }
        catch (FileNotFoundException)
        {
            Debug.Log("Preferences File not found, a default one will be created");
            PreferencesScriptableObject.currentBallSpeed = ballSpeed;
            PreferencesScriptableObject.Save();
        }

        Debug.Log("The ball speed will be " + ballSpeed);

    }

    // Update is called once per frame
    void Update()
    {

        if (bordersController.exitOnBottom) {
            DestroyedBall.Invoke(); 
            Destroy(this.gameObject);
        }
        if (bordersController.exitOnTop) {
            direction = transform.position - lastPosition;
            Debug.Log("Ball exit on top");

            var tempPosition = transform.position;
            tempPosition.y--;
            transform.position = tempPosition;

            direction.y *= -1;
            direction.Normalize();
            rigidbody.velocity = direction * ballSpeed;
            bordersController.exitOnBottom = false;
        }
        if (bordersController.exitOnLeft) {
            direction = transform.position - lastPosition;
            Debug.Log("Ball exit on left");

            var tempPosition = transform.position;
            tempPosition.x++;
            transform.position = tempPosition;

            direction.x *= -1;
            direction.Normalize();
            rigidbody.velocity = direction * ballSpeed;
            bordersController.exitOnLeft = false;
        }
        if (bordersController.exitOnRight)
        {
            direction = transform.position - lastPosition;
            Debug.Log("Ball exit on right");
            var tempPosition = transform.position;
            tempPosition.x--;
            transform.position = tempPosition;

            direction.x *= -1;
            direction.Normalize();
            rigidbody.velocity = direction * ballSpeed;
            bordersController.exitOnRight = false;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Cancel")) // in PS5 controller: Cancel <=> X
        {
            if (!gameStarted)
            {
                gameStarted = true;
                this.transform.SetParent(null);
                rigidbody.velocity = ballSpeed * Vector3.up;
            }
        }
    }

    private void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        if(direction != Vector3.zero) { direction = Vector3.zero; }
    }
}
