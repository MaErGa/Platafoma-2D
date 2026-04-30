using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSubeBaja : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject puntoA;
    public GameObject puntoB;
    public Transform currentPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = puntoB.transform;
    }

    void Update()
    {

        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = new Vector2(0, direction.y * speed);


        if (Vector2.Distance(transform.position, currentPoint.position) < 0.9f)
        {

            currentPoint = (currentPoint == puntoA.transform)
                ? puntoB.transform
                : puntoA.transform;
        }
    }


    private void OnDrawGizmos()
    {

        if (puntoA != null && puntoB != null)
        {
            Gizmos.DrawWireSphere(puntoA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(puntoB.transform.position, 0.5f);

            Gizmos.DrawLine(puntoA.transform.position, puntoB.transform.position);
        }
    }
}