using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnBeat : MonoBehaviour
{
    [Header("Behavior Settings")]
    public Transform target;
    private MeshRenderer meshRenderer;
    public Material material;
    private Material materialInstance;
    public Color color;
    public string colorProperty;

    private float strength;
    [Range(0.8f, 0.99f)]
    public float fallBackFactor;
    [Range(1, 4)]
    public float colorMultiplier;

    [Header("Beat Settings")]
    [Range(0, 3)]
    public int onFullBeat;
    [Range(0, 7)]
    public int[] onBeatD8;
    private int beatCountFull;

    private void Start()
    {
        if (target != null)
        {
            meshRenderer = target.GetComponent<MeshRenderer>();
        }
        else
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        strength = 0;
        materialInstance = new Material(material);
        materialInstance.EnableKeyword("_EMISSION");
        meshRenderer.material = materialInstance;
    }

    private void Update()
    {
        if (strength > 0)
        {
            strength *= fallBackFactor;
        }
        else
        {
            strength = 0;
        }
        CheckForBeat();
        materialInstance.SetColor(colorProperty, color * strength * colorMultiplier);
    }

    void CheckForBeat()
    {
        beatCountFull = BeatsPeer.beatCountFull % 4; // to loop in 4 steps
        for (int i = 0; i < onBeatD8.Length; i++)
        {
            if (BeatsPeer.beatD8 && beatCountFull == onFullBeat && BeatsPeer.beatCountD8 % 8 == onBeatD8[i])
            {
                Colorize();
            }
        }
    }

    void Colorize()
    {
        strength = 1;
    }
}
