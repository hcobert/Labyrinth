using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
    }
}
