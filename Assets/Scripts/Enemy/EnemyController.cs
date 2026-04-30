using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats enemyStats;
    public float life;
    public float damage;
    public float speed;
    public Rigidbody2D rb;
    public GameObject puntoA;
    public GameObject puntoB;
    public Transform currentPoint;
    void Awake()
    {
        life = enemyStats.MaxLife;
        damage = enemyStats.Damage;
        speed = enemyStats.Speed;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = puntoA.transform;
    }
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position; // un vector 2 que reste las posiciones del enemigo y la del punto exacto en el que se encuentra para que pueda salir a buscarlo
        if (currentPoint == puntoB.transform)
        {
            rb.velocity = new Vector2(speed, 0); // x,y,z
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.9f && currentPoint == puntoB.transform)
        {
            currentPoint = puntoA.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 0.9f && currentPoint == puntoA.transform)
        {
            currentPoint = puntoB.transform;
        }
        if (life <= 0)
        {
            Destroy(gameObject); //desaparece de la jerarquia 
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(puntoA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(puntoB.transform.position, 0.5f);
        Gizmos.DrawLine(puntoA.transform.position, puntoB.transform.position);
    }
}
