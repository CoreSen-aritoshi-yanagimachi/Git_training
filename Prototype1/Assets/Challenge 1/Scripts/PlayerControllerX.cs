using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private const float SPEED = 5.0f;//Challenge1.4
    private const float ROTATION_SPEED = 30f;
    [SerializeField] float verticalInput;

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * SPEED * Time.deltaTime);//Challenge1.3

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * ROTATION_SPEED * Time.deltaTime * verticalInput);// Challenge1.5
    }
}