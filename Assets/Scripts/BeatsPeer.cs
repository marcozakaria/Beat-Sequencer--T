using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsPeer : MonoBehaviour
{
    private static BeatsPeer instance;

    public float bpm;

    private float beatInterval, beatTimer, beatIntervalD8, beatTimerD8;

    public static bool beatFull, beatD8;
    public static int beatCountFull, beatCountD8;

    public float[] tapTime = new float[4];
    public static int tap;
    public static bool customBeat;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        Tapping();
        BeatDetection();
    }

    void Tapping()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            customBeat = true;
            tap = 0;
        }

        if (customBeat)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (tap < 4)
                {
                    tapTime[tap] = Time.realtimeSinceStartup;
                    tap++;
                }
                if (tap == 4)
                {
                    float averageTime = ((tapTime[1] - tapTime[0]) + (tapTime[2] - tapTime[1]) + (tapTime[3] - tapTime[2])) / 3;
                    bpm = (float)System.Math.Round((double)60 / averageTime, 2);

                    tap = 0;
                    beatTimer = 0;
                    beatTimerD8 = 0;
                    beatCountD8 = 0;
                    beatCountFull = 0;
                    customBeat = false;
                }
            }
        }
    }


    void BeatDetection()
    {
        beatFull = false;  // full beat count
        beatInterval = 60 / bpm;
        beatTimer += Time.deltaTime;
        if (beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
            beatFull = true;
            beatCountFull++;
            Debug.Log("full beat");
        }

        // divded beat count
        beatD8 = false;
        beatIntervalD8 = beatInterval / 8;
        beatTimerD8 += Time.deltaTime;
        if (beatTimerD8 >= beatIntervalD8)
        {
            beatTimerD8 -= beatIntervalD8;
            beatD8 = true;
            beatCountD8++;
            Debug.Log("Beat D 8");
        }
    }
}
