﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthPoints = 3;
    // Start is called before the first frame update
    public void TakeDamagePlayer(int damage)
    {
        healthPoints -= damage;
    }
    void FixedUpdate()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
