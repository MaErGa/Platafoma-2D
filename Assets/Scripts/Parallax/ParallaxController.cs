using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool scrollLeft;
    private GameObject player;
    float singleTextureWidth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetupTexture();
        if (scrollLeft) moveSpeed = -moveSpeed;
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = transform.localScale.x * sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime * player.GetComponent<PlayerController>().inputMovimiento;
        transform.position += new Vector3(delta, 0f, 0f);
    }

    void CheckReset()
    {
        if ((Mathf.Abs(transform.position.x) - singleTextureWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        Scroll();
        CheckReset();
    }
}