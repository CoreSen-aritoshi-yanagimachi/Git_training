using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED = 20.0f;
    private const float TURN_SPEED = 45.0f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * SPEED * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * TURN_SPEED * horizontalInput);
    }
}
