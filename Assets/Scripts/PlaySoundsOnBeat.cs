using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip tap, tick;
    public AudioClip[] strum;

    int randomStrun;

    private void Update()
    {
        if (BeatsPeer.beatFull)
        {
            audioManager.PlaySound(tap, 1);
            if (BeatsPeer.beatCountFull % 2 == 0)
            {
                randomStrun = Random.Range(0, strum.Length);
            }
        }

        if (BeatsPeer.beatD8 && BeatsPeer.beatCountD8 %2 ==0)
        {
            audioManager.PlaySound(tick, 0.1f);
        }

        if (BeatsPeer.beatD8 && (BeatsPeer.beatCountD8 % 8 == 2 || BeatsPeer.beatCountD8 %8 ==4))
        {
            audioManager.PlaySound(strum[randomStrun], 1);
        }
    }
}
