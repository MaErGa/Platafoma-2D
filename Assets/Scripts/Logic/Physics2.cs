using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics2 : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 3); //se ignora balas y player
        Physics2D.IgnoreLayerCollision(7, 6); // se ignora las balas con el entorno
        Physics2D.IgnoreLayerCollision(3, 3); // ingnoramos a nosotros mismos
    }



}
