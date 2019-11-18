using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    //take inputs for move speed and damage dealt
    public float moveSpeed;
    public int damage;
    
    //upon creation of the bolt, give it speed moveSpeed in the direction the player is facing
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);      
    }
    
    //Upon entering another non-player collider, tell the other collider to take damage and destroy the bolt
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Collider2D playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        Collider2D floorCollider = GameObject.FindWithTag("Floor").GetComponent<Collider2D>();
        if ((otherCollider != playerCollider) && (otherCollider != floorCollider))
        {
            otherCollider.SendMessage("TakeDamageEnemy", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }       
    }
    /*
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    */
}
