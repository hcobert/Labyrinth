using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : MonoBehaviour
{
    public float acceleration;
    public float deceleration;
    public float maxSpeed;

    private Vector2 directionVector;
    private Vector2 velocityVector;
    private Vector2 accelerationVector;

    Rigidbody2D body;
   
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
        body = GetComponent<Rigidbody2D>();
        accelerationVector.x = acceleration;
        accelerationVector.y = acceleration;
    }

    void FixedUpdate()
    {    
        float inX = Input.GetAxisRaw("Horizontal");
        float inY = Input.GetAxisRaw("Vertical");
        directionVector.x = inX;
        directionVector.y = inY;
        directionVector.Normalize();

        // if player is pressing buttons
        if ((inX != 0) || (inY != 0))
        {
            velocityVector += directionVector * accelerationVector;
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

        body.velocity = velocityVector;

        // prevents object spinning due to collision 
        body.angularVelocity = 0;

    }
}
