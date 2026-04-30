using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public EnemyStats enemyStats; //primero llamo al script y luego le pongo el nombre por el cual yo lo voy a usar
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().Life -= enemyStats.Damage; //resta el daño a la vida del player
            if (collision.transform.position.x > gameObject.transform.position.x)
            {
                Debug.Log("here");
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            }
            else if (collision.transform.position.x < gameObject.transform.position.x)
            {
                Debug.Log("there");
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 5);
            }
        }
    }
}
