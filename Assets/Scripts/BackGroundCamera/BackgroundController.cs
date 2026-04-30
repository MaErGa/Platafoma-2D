using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform Camera;
    void FixedUpdate()
    {// queremos que esto ocurra en runtime pero despues de actualizar
        transform.position = Camera.transform.position + new Vector3(0, 0, 15);// el fondo nos sigue
    }
}
