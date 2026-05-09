using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public GameObject Reset;

    void Start()
    {
        if (Reset != null)
        {
            Reset.SetActive(false); 
        }
        else
        {
            Debug.LogError("¡ERROR! No has asignado el objeto del Botón en el script ResetLevel de " + gameObject.name);
        }
    }

    public void MostrarBoton()
    {
        if (Reset != null)
        {
            Reset.SetActive(true);
            Debug.Log("El botón debería estar visible ahora.");
        }
        else
        {
            Debug.LogError("Intentaste mostrar el botón, pero la variable 'Reset' está vacía.");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("prueba", LoadSceneMode.Single);
    }
}