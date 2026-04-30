using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect; // Valor entre 0 y 1

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
