using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public int CurrentLap { get; private set; } = 0;

    private float lapTimerTimestamp;
    private int lastCheckpoint = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;

    private void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Chekpoint");
    }
   void StartLap()
    {
        Debug.Log("start");
        CurrentLap++;
        lastCheckpoint = 1;
        lapTimerTimestamp = Time.time;
    }
    void EndLap()
    {
        Debug.Log("end");
        LastLapTime = Time.time - lapTimerTimestamp;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != checkpointLayer)
        {
            return;
        }
        if (collider.gameObject.name == "1")
        {
            if (lastCheckpoint == checkpointCount)
            {
                EndLap();
            }

            if (CurrentLap == 0 || lastCheckpoint == checkpointCount)
            {
                StartLap();
            }
            return;
        }
        if (collider.gameObject.name == (lastCheckpoint+1).ToString())
        {
            lastCheckpoint++;
        }
    }
    void Update()
    {
        CurrentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0;
    }
}
