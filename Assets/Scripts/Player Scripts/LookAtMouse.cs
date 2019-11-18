using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    //Take inputs for camera being used, rotation smoothing and adjustment
    public Camera theCamera;
    public float smoothing;
    public float adjustment = 270;
    void FixedUpdate()
    {
        //find direction vector from object to mouse using A->B = b - a
        Vector2 directionVector = theCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //find angle in degrees between direction vector and x-axis
        float rot = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;

        //add adjustment (default 270) to angle and convert angle into quaternion
        Quaternion newRot = Quaternion.Euler(0, 0, rot + adjustment);
        
        //set rotation of object to a fraction (smoothing) of the new angle 
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, smoothing);
    }
}
