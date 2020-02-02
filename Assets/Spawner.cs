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

    [HideInInspector]
    public bool hasSpawnedItem = false;

    private static bool hasSpawnedBoss = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (!hasSpawnedItem)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && !hasSpawnedItem)
        {
            timer = 7f;
            hasSpawnedItem = true;
            Instantiate(item, transform);
        }

        if (ClockBehavior.ringingClocks >= 3)
        {
            bossTimer -= Time.deltaTime;


           
            if (bossTimer <=0 && !hasSpawnedBoss)
            {

                float distanceToPlayer = 0f;
                GameObject SelectedSpawner = null;


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
                }

                hasSpawnedBoss = true;

                if (SelectedSpawner.name == this.gameObject.name)
                {
                    Instantiate(boss, transform);
                }
                
            }
        } 
    }
}
