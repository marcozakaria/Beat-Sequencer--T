using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TappingUI : MonoBehaviour
{
    public Sprite spriteOpen, spriteClosed;

    private Transform ui;
    private Image[] tapImage;

    private void Start()
    {
        ui = transform.GetChild(0);
        ui.gameObject.SetActive(false);

        tapImage = new Image[4];
        for (int i = 0; i < tapImage.Length; i++)
        {
            tapImage[i] = ui.GetChild(i).GetComponent<Image>();
            tapImage[i].sprite = spriteOpen;
        }
    }

    private void Update()
    {
        if (BeatsPeer.customBeat)
        {
            ui.gameObject.SetActive(true);
            for (int i = 0; i < tapImage.Length; i++)
            {
                if (i < BeatsPeer.tap)
                {
                    tapImage[i].sprite = spriteClosed;
                }
                else
                {
                    tapImage[i].sprite = spriteOpen;
                }
            }
        }
        else
        {
            ui.gameObject.SetActive(false);
        }
    }
}
