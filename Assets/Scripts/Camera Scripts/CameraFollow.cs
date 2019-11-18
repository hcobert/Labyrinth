using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //take inputs for target object's transform and smoothing fraction
    public Transform target;
    public float smoothing = 0.5f;

    void FixedUpdate()
    {
        //set the position of the object to a point between the object and the target
        //the position is determined by the smoothing, 0 = current position, 1 = target position
        //0.5 = half-way between etc.
        transform.position = Vector2.Lerp(transform.position, target.position, smoothing);
    }
}
