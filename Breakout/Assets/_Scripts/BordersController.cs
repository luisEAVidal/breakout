using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersController : MonoBehaviour
{
    [Header("On Editor Configurations")]
    public float radio = 1.0f;
    public bool keepOnScreen = false;

    [Header("Dynamic Configuration")]
    public bool isOnScreen = true;
    public float cameraHeight;
    public float cameraWidth;
    public bool exitOnLeft, exitOnRight, exitOnTop, exitOnBottom;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.aspect * cameraHeight;
    }

    private void LateUpdate()
    {
        Vector3 position = transform.position;
        isOnScreen = true;
        exitOnBottom = false;
        exitOnLeft = false;
        exitOnTop = false;
        exitOnRight = false;

        if (position.x > cameraWidth - radio) {
            position.x = cameraWidth - radio;
            exitOnRight = true;
        }
        if (position.x < -cameraWidth + radio)
        {
            position.x = - cameraWidth + radio;
            exitOnLeft = true;
        }
        if (position.y > cameraHeight - radio)
        {
            position.y = cameraHeight - radio;
            exitOnTop = true;
        }
        if (position.y < - cameraHeight + radio)
        {
            position.y = -cameraHeight + radio;
            exitOnBottom = true;
        }

        isOnScreen = !(exitOnBottom || exitOnLeft || exitOnRight || exitOnTop);

        if (keepOnScreen && !isOnScreen) { 
            transform.position = position;
            isOnScreen = true;
        }
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) {
            return;
        }
        Vector3 borderSize = new Vector3(cameraWidth * 2, cameraHeight * 2, 1.0f);
        Gizmos.DrawWireCube(Vector3.zero, borderSize);
    }
}
