using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteController : MonoBehaviour
{
    public GameObject Pausa;
    public Sprite pausaSprite;
    public Sprite playSprite;

    void Start()
    {
        Pausa = gameObject;
        playSprite = Load("play-pausa", "play");
        pausaSprite = Load("play-pausa", "pausa");
    }

    Sprite Load(string imageName, string spriteName)
    {
        Sprite[] all = Resources.LoadAll<Sprite>(imageName);
        foreach (var s in all)
        {
            if (s.name == spriteName)
            {
                return s;
            }
        }
        return null;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            Pausa.GetComponent<Image>().sprite = playSprite;
        }
        else
        {
            Pausa.GetComponent<Image>().sprite = pausaSprite;
        }
    }
}