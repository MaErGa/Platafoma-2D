using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public GameObject Reset;

    void Start()
    {
        Reset.SetActive(false); // Oculto al inicio
    }

    public void MostrarBoton()
    {
        Reset.SetActive(true); // Se llama cuando el jugador muere
    }

    public void Restart()
    {
        SceneManager.LoadScene("prueba", LoadSceneMode.Single);
    }
}