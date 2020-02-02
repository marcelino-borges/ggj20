using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClockBehavior : MonoBehaviour
{
    [HideInInspector]
    public static int ringingClocks;
    
    private bool isRinging;

    private float timer;

    private void Start()
    {
        SetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !isRinging)
        {
            isRinging = true;
            AddToRingingClocks();
            //Start ringing in audio;
        }
    }

    void AddToRingingClocks()
    {
        ringingClocks++;
    }

    public void DeactivateClock()
    {
        ringingClocks--;
        isRinging = false;
        SetTimer();
    }

    public void SetTimer()
    {
        timer = Random.Range(20, 60);
    }
}
