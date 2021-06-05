﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIA : MonoBehaviour
{
    private float waitedTime;

    public float waitTimeToAttack=3f;

    public Animator animator;

    public GameObject bulletPrefab;

    public Transform launchSpawnPoint;

    private void Start() 
    {
        waitedTime=waitTimeToAttack;
    }

    private void Update() 
    {
        if (waitedTime<=0)
        {
            waitedTime=waitTimeToAttack;
            animator.Play("PlantAttack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime-=Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;

        newBullet= Instantiate(bulletPrefab, launchSpawnPoint.position,launchSpawnPoint.rotation);
    }
}
