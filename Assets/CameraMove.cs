using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = FindObjectOfType<Grant_Controll>().moveForce;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + cameraSpeed, transform.position.y, -10);
    }
}
