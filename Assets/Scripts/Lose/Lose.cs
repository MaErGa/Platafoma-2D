using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("se tocan");
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("prueba", LoadSceneMode.Single); //escena nueva
        }
    }
}


