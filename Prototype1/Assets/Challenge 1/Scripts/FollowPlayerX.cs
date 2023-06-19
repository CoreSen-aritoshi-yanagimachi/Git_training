using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] GameObject plane;
    private Vector3 offset = new Vector3(15, 0, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}