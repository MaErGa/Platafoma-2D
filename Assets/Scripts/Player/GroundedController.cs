using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour
{
    public float distToGround;//Distancia suelo
    public bool helper; //nos va ayudar a ver si esta o no en el suelo
    public int layer; //capa
    public int layerMask; //mascara de capa
    void Start()
    {
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        layer = 6; //la capa
        layerMask = 1 << layer; //evitamos que la mascara de capa se vea afectada asi todo pertenece al layer 6
    }

    public bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up, Color.yellow); //Dibuja el rayo
        return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, layerMask);
    }
    void FixedUpdate()
    {
        IsGrounded();
        helper = IsGrounded();
    }
}
