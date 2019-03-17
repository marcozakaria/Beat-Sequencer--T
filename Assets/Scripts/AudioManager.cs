using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public int soundBankSize;

    public List<AudioSource> soundClip;

    private void Start()
    {
        soundClip = new List<AudioSource>();

        for (int i = 0; i < soundBankSize; i++)
        {
            GameObject soundInstance = new GameObject("Sound");
            soundInstance.AddComponent<AudioSource>();
            soundInstance.transform.parent = this.transform;
            soundClip.Add(soundInstance.GetComponent<AudioSource>());
        }
    }

    public void PlaySound(AudioClip clip,float volume)
    {
        for (int i = 0; i < soundBankSize; i++)
        {
            if (!soundClip[i].isPlaying)
            {
                soundClip[i].clip = clip;
                soundClip[i].volume = volume;
                soundClip[i].Play();
                return;
            }
        }

        GameObject soundInstance = new GameObject("Sound");
        AudioSource instanceSource = soundInstance.AddComponent<AudioSource>();
        soundInstance.transform.parent = this.transform;
        instanceSource.clip = clip;
        instanceSource.volume = volume;
        instanceSource.Play();
        soundClip.Add(soundInstance.GetComponent<AudioSource>());

    }
}
