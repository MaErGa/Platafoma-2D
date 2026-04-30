using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose2 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("se tocan");
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("LV2", LoadSceneMode.Single); //escena nueva
        }
    }
}


