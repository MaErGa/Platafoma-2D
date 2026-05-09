using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public EnemyStats enemyStats;
    private float cooldown = 1f; // daño cada 1 segundo
    private float timer = 0f;

    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timer <= 0)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.Life -= enemyStats.Damage;
            Debug.Log("Vida del jugador: " + player.Life);

            if (collision.transform.position.x > gameObject.transform.position.x)
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            else if (collision.transform.position.x < gameObject.transform.position.x)
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 5);

            timer = cooldown;
        }
    }
}