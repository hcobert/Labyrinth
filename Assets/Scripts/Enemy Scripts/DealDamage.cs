using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float damage;
    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        otherCollider.SendMessage("TakeDamagePlayer", damage, SendMessageOptions.DontRequireReceiver);
    }
}
