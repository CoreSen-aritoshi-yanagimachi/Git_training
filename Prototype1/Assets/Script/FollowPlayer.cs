using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // LateUpdate is called once per frame
    void LateUpdate()
    {
        while (GameObject.Find("Player"))
        {
            Quaternion playerRotation = player.rotation;
            Vector3 desiredPosition = player.position - playerRotation * offset;
            transform.position = desiredPosition;
            transform.rotation = playerRotation;
        }
    }
}