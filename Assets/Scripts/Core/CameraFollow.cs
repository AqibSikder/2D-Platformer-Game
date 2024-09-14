using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    Vector3 velocity = Vector3.zero; // Velocity used for smoothing

    [Range(0, 1)]
    public float smoothTime; // Smoothing factor for camera movement

    public Vector3 positionOffset; // Offset from the target's position

    void Awake()
    {
        // Find the object with the "Player" tag
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // Calculate position for the camera to move towards
        Vector3 targetPosition = target.position + positionOffset;

        // move the camera towards the target position using SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
