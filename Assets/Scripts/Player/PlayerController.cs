using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerb;
    public float inputMovimiento;
    public bool IsGrounded;
    public GroundedController gc;
    public float speed;
    public float speedJump;
    public float Life;
    public PlayerStats playerStats;
    public Animator anim;
    //  public ResetLevel resetLevel;
    public GameObject reset;

    void Start()
    {
        playerb = GetComponent<Rigidbody2D>();
        Life = playerStats.MaxLife;
        speed = playerStats.Speed;
        speedJump = playerStats.SpeedJump;
    }

    void Update()
    {
        inputMovimiento = Input.GetAxis("Horizontal");
        IsGrounded = gc.IsGrounded();

        // Flip del sprite
        if (inputMovimiento < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if (inputMovimiento > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        // Animacion
        anim.SetBool("Walking", inputMovimiento != 0);

        if (Life <= 0) Die();

        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void FixedUpdate()
    {
        // Movimiento horizontal
        playerb.velocity = new Vector2(inputMovimiento * speed, playerb.velocity.y);

        // Salto
        if (Input.GetKey("space") && gc.IsGrounded())
        {
            playerb.AddForce(transform.up * speedJump, ForceMode2D.Impulse);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        reset.SetActive(true);
        Debug.Log("me mori");
        //añadir menu de volver a jugar

    }

    public void Shoot()
    {
        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = playerb.transform.position;
            bullet.transform.rotation = playerb.transform.rotation;
            if (Time.timeScale != 0)
                bullet.SetActive(true);
        }
    }
}