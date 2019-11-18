using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    //Take inputs for camera being used, rotation smoothing, angle adjustment and sight range
    public Transform target;
    public float smoothing = 1;
    public float adjustment = 270;
    public float sightRange;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        //find direction vector from object to target using A->B = b - a
        Vector2 directionVector = target.position - transform.position;

        //check that object can "see" target
        if (directionVector.magnitude <= sightRange)
        {
            //find angle in degrees between direction vector and x-axis
            float rot = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;

            //add adjustment (default 270) to angle and convert angle into quaternion
            Quaternion newRot = Quaternion.Euler(0, 0, rot + adjustment);

            //set rotation of object to a fraction (smoothing) of the new angle 
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, smoothing);
        }
        
    }
}
