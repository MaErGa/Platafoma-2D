using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void CambiarEscena(string opciones)
    {
        if (!string.IsNullOrEmpty(opciones))
        {
            SceneManager.LoadScene(opciones);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no puede estar vacío.");
        }
    }
}