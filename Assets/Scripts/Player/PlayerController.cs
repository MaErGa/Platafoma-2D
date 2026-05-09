using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private SpriteRenderer spr;

    [Header("Game Over")]
    public ResetLevel resetLevel;

    [Header("Sistema de Munición")]
    public int municionMax = 10;
    public int municionActual;
    private bool estaRecargando = false;

    void Start()
    {
        playerb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        Life = playerStats.MaxLife;
        speed = playerStats.Speed;
        speedJump = playerStats.SpeedJump;

        municionActual = municionMax;
    }

    void Update()
    {
        IsGrounded = gc.IsGrounded();
        ProcesarMovimiento();
        
        Debug.Log("Life: " + Life);

        if (Life <= 0) Die();

        // Satlar con barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            playerb.velocity = new Vector2(playerb.velocity.x, speedJump);
        }

        
        if (Input.GetMouseButtonDown(0) && !estaRecargando && municionActual > 0)
        {
            Shoot();
        }

        // Recarga automatica de balas al desaparecer las balas de la scene
        if (municionActual <= 0 && !estaRecargando)
        {
            StartCoroutine(Recargar());
        }
    }

    void ProcesarMovimiento()
    {
        inputMovimiento = Input.GetAxis("Horizontal");
        playerb.velocity = new Vector2(inputMovimiento * speed, playerb.velocity.y);
        anim.SetBool("Walking", true);

        if (inputMovimiento < 0)
            spr.flipX = true;
        else if (inputMovimiento > 0)
            spr.flipX = false;

        if (inputMovimiento == 0) anim.SetBool("Walking", false);
    }

    public void Shoot()
    {
        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            // Disparo segun direccion del jugador
            float offset = spr.flipX ? -0.7f : 0.7f;
            bullet.transform.position = transform.position + new Vector3(offset, 0, 0);
            bullet.transform.rotation = playerb.transform.rotation;

            if (Time.timeScale != 0)
            {
                municionActual--;
                bullet.SetActive(true);
            }
        }
    }

    IEnumerator Recargar()
    {
        estaRecargando = true;
        yield return null; 
        municionActual = municionMax;
        estaRecargando = false;
        Debug.Log("¡RECARGA COMPLETADA!");
    }

   public void Die()
    {
        Debug.Log("me mori");
        if (resetLevel != null)
            resetLevel.MostrarBoton(); 
        gameObject.SetActive(false);  
    }
    
}

