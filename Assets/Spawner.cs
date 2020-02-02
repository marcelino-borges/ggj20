using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject item;
    public GameObject boss;
    private GameObject player;

    private float bossTimer = 30f;
    private float timer = 7f;

    private static bool hasSpawnedBoss = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 7f;

            Instantiate(item);
        }

        if (ClockBehavior.isRinging)
        {
            bossTimer -= Time.deltaTime;

           
            if (bossTimer <= 0 && !hasSpawnedBoss)
            {

                float distanceToPlayer = 0f;
                GameObject SelectedSpawner;
                foreach (var item in FindObjectsOfType<Spawner>())
                {
                    float deltaDistanceToPlayer;
                    deltaDistanceToPlayer = distanceToPlayer;
                    distanceToPlayer = Vector3.Distance(item.transform.position, player.transform.position);
                    if (distanceToPlayer < deltaDistanceToPlayer)
                    {
                        distanceToPlayer = deltaDistanceToPlayer;
                    }
                    else
                    {
                        SelectedSpawner = item.gameObject;
                    }

                    //make boss spawn furthest away from player
                }
                hasSpawnedBoss = true;

                Instantiate(boss);
            }
        } 
    }
}
