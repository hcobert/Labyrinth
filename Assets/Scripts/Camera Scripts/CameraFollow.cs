using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.5f;

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, smoothing);
    }
}
