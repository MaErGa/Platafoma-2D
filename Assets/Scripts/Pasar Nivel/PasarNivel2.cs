using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class CambioNivel : MonoBehaviour
{
    [SerializeField] private string transicion; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            CambiarEscena();
        }
    }

    public void CambiarEscena()
    {
        
        SceneManager.LoadScene(transicion);
    }
}