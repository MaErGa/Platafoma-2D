using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeController : MonoBehaviour
{
    public GameObject menuPausa;
    public float ScaleAtRuntime;

    public void HandleTime()
    {
        if (Time.timeScale != 0)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        ScaleAtRuntime = Time.timeScale;
        Time.timeScale = 0;
        menuPausa.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Resume()
    {
        Time.timeScale = ScaleAtRuntime;
        menuPausa.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}