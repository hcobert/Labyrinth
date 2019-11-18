using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBolts : MonoBehaviour
{
    public GameObject boltPrefab;
    public Transform spawnPoint01;
    public Transform spawnPoint02;
    public bool doubleFire = true;
    public float cooldown;
    public float timeBetweenBolts;

    private bool isFiring = false;
    private int currentBolt = 1;

    private void SetFiring()
    {
        isFiring = false;
    }
    private void Fire()
    {
        if (doubleFire)
        {
            if (currentBolt == 1)
            {
                isFiring = true;
                Instantiate(boltPrefab, spawnPoint01.position, spawnPoint01.rotation);
                currentBolt = 2;
                Invoke("Fire", timeBetweenBolts);                
            }
            else
            {
                Instantiate(boltPrefab, spawnPoint02.position, spawnPoint02.rotation);
                currentBolt = 1;
                Invoke("SetFiring", cooldown);
            }
            
        }
        else
        {
            isFiring = true;
            Instantiate(boltPrefab, spawnPoint01.position, spawnPoint01.rotation);
            Invoke("SetFiring", cooldown);
        }
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
