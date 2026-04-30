using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Posición del player
    public Vector3 offset = new Vector3(0, 0, -10); // Es mejor tener el offset fuera para ajustarlo

    void LateUpdate()
    {
        // ERROR CORREGIDO: "new" debe ir en minúscula. 
        // "player.transform.position" se puede simplificar a "player.position".
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}