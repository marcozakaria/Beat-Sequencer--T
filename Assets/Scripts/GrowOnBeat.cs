using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnBeat : MonoBehaviour
{
    [Header("Behavior Settings")]
    public Transform target;  
    private float currentSize;
    public float growSize, shrinkSize;
    [Range(0.8f,0.99f)]
    public float shrinkFactor;

    [Header("Beat Settings")]
    [Range(0,3)]
    public int onFullBeat;
    [Range(0,7)]
    public int[] onBeatD8;
    private int beatCountFull;

    private void Start()
    {
        if (target == null)
        {
            target = this.transform;
        }
        currentSize = shrinkSize;
    }

    private void Update()
    {
        if (currentSize > shrinkSize)
        {
            currentSize *= shrinkFactor;
        }
        else
        {
            currentSize = shrinkSize;
        }
        CheckForBeat();
        target.localScale = new Vector3(target.localScale.x, currentSize, target.localScale.z);
    }

    void Grow()
    {
        currentSize = growSize;
    }

    void CheckForBeat()
    {
        beatCountFull = BeatsPeer.beatCountFull % 4; // to loop in 4 steps
        for (int i = 0; i < onBeatD8.Length; i++)
        {
            if (BeatsPeer.beatD8 && beatCountFull == onFullBeat && BeatsPeer.beatCountD8 % 8 == onBeatD8[i] )
            {
                Grow();
            }
        }
    }
}
