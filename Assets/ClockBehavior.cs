using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClockBehavior : MonoBehaviour
{

    [HideInInspector]
    public static bool isRinging;

    private float timer;

    private void Start()
    {
        SetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isRinging = true;
            //Start ringing in audio;
        }
    }

    public void SetTimer()
    {
        timer = Random.Range(7, 20);
    }
}
