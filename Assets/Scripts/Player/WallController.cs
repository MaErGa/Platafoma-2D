using UnityEngine;

public class WallController : MonoBehaviour
{
    public bool isTouchingWall;
    public int wallLayer = 7; // Usa una capa distinta para muros si quieres
    private int layerMask;
    private Collider2D coll;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        layerMask = 1 << wallLayer;
    }

    public bool IsTouchingWall()
    {
        // Detecta hacia los lados usando el área del cuadrado lateral
        RaycastHit2D hit = Physics2D.BoxCast(
            coll.bounds.center,
            coll.bounds.size,
            0f,
            transform.right, // Mira hacia donde apunte el sensor
            0.1f,
            layerMask
        );

        return hit.collider != null;
    }

    void FixedUpdate()
    {
        isTouchingWall = IsTouchingWall();
    }
}