using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D rbBullet;
    public float force = 20f; 
    public int Damage = 2;
    public float maxDistance = 15f; 

    private GameObject player;
    private SpriteRenderer playerSpr;

    void Awake()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerSpr = player.GetComponent<SpriteRenderer>();
        }
    }

    void OnEnable()
    {
        
        rbBullet.velocity = Vector2.zero;

        if (playerSpr != null)
        {
            
            float direccionX = playerSpr.flipX ? -1f : 1f;

           
            rbBullet.velocity = new Vector2(direccionX * force, 0);

            
            transform.localScale = new Vector3(direccionX, 1, 1);
        }
    }

    void Update()
    {
        
        if (player != null && Vector2.Distance(transform.position, player.transform.position) > maxDistance)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.life -= Damage;
            }
            gameObject.SetActive(false);
        }
    }
}