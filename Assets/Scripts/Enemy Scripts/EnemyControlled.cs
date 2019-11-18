using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlled : MonoBehaviour
{
    //take inputs for object's target, acceleration, deceleration, max speed and sight range
    public Transform target;
    public float defaultAcceleration;
    public float defaultDeceleration;
    public float defaultMaxSpeed;
    public float sightRange;

    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    
    //initialise vectors
    private Vector2 directionVector;
    private Vector2 velocityVector;

    //initialise rigidbody
    Rigidbody2D body;

    //approach inTarget from inStart by inRate each tick
    public float Approach(float inStart, float inTarget, float inRate)
    {
        if (inStart < inTarget)
        {
            inStart += inRate;
            return Mathf.Min(inStart, inTarget);
        }
        else if (inStart > inTarget)
        {
            inStart -= inRate;
            return Mathf.Max(inStart, inTarget);
        }
        else
        {
            return inStart;
        }
    }

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        //set the rigidbody we are working with to the rigidbody of the object
        body = GetComponent<Rigidbody2D>();
    }
    
    //allows other objects to change movement properties of object
    void SetAcceleration(float inAcceleration)
    {
        acceleration = inAcceleration;
    }
    void SetAccelerationDefault()
    {
        acceleration = defaultAcceleration;
    }
    void SetDeceleration(float inDeceleration)
    {
        deceleration = inDeceleration;
    }
    void SetDecelerationDefault()
    {
        deceleration = defaultDeceleration;
    }
    void SetMaxSpeed(float inMaxSpeed)
    {
        maxSpeed = inMaxSpeed;
    }
    void SetMaxSpeedDefault()
    {

        maxSpeed = defaultMaxSpeed;
    }

    void FixedUpdate()
    {
        //direction vector determined by target position
        directionVector = target.position - transform.position;
        
        
        //If target is in range of sight move towards target
        if (directionVector.magnitude <= sightRange)
        {
            directionVector.Normalize();
            velocityVector += directionVector * acceleration;
        }
        //Else decelerate
        else
        {
            velocityVector.x = Approach(velocityVector.x, 0, deceleration);
            velocityVector.y = Approach(velocityVector.y, 0, deceleration);
        }
        
        //if object is going faster than its max speed, set its speed to its max speed
        if (velocityVector.magnitude > maxSpeed)
        {
            velocityVector.Normalize();
            velocityVector *= maxSpeed;
        }

        //set velocity of rigidbody to newly determined velocity vector
        body.velocity = velocityVector;

        // prevents object spinning due to collision 
        body.angularVelocity = 0;

    }
}
