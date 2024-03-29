﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : MonoBehaviour
{
    //take inputs for object's default acceleration, deceleration and maxSpeed
    //these will NOT change during run time
    public float defaultAcceleration;
    public float defaultDeceleration;
    public float defaultMaxSpeed;

    //these are subject to change based on floor
    public float acceleration;
    public float deceleration;
    public float maxSpeed;

    //initialise vectors
    private Vector2 directionVector;
    private Vector2 velocityVector;

    //initialise rigidbody
    Rigidbody2D body;
   
    //approach inTarget from inStart by inRate each tick
    public float Approach(float inStart,float inTarget,float inRate)
    {
        if (inStart < inTarget)
        {
            inStart += inRate;
            return Mathf.Min(inStart,inTarget);
        }
        else if (inStart > inTarget)
        {
            inStart -= inRate;
            return Mathf.Max(inStart,inTarget);
        }
        else
        {
            return inStart;
        }        
    }

    void Start()
    {
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
        //direction vector determined by user input and normalized
        float inX = Input.GetAxisRaw("Horizontal");
        float inY = Input.GetAxisRaw("Vertical");
        directionVector.x = inX;
        directionVector.y = inY;
        directionVector.Normalize();

        // if player is pressing buttons
        if ((inX != 0) || (inY != 0))
        {
            velocityVector += directionVector * acceleration;
        }
        // if player is not pressing buttons
        else
        {
            velocityVector.x = Approach(velocityVector.x, 0, deceleration);            
            velocityVector.y = Approach(velocityVector.y, 0, deceleration);
        }

        // if player is not pressing horizontal buttons
        if (inX == 0)
        {
            velocityVector.x = Approach(velocityVector.x, 0, deceleration);
        }

        // if player is not pressing vertical buttons
        if (inY == 0)
        {
            velocityVector.y = Approach(velocityVector.y, 0, deceleration);
        }

        // if object is going faster than its max speed, set its speed to its max speed
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
