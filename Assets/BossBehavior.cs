using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    Transform target;
    float speed = 7f;

    private void Awake()
    {
        target = FindObjectOfType<PlayerBehavior>().gameObject.transform;
    }

    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
