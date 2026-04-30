using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawCoin : MonoBehaviour
{
    public GameObject coinPool;
    public float x;
    public float y;
    void Start()
    {
        StartCoroutine(Spawn());

    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3);
        GameObject coin = coinPool.GetComponent<CoinPool>().GetPooledObject();
        //baja pantalla X 99.56 y-29.69 // alta x 108.5 y -2.5 
        if (coin != null)
        {
            x = Random.Range(99.56f, 108.5f);
            y = Random.Range(-29.69f, -2.5f);
            coin.transform.position = new Vector3(x, y, 0);
            coin.SetActive(true);
        }
        StartCoroutine(Spawn());
    }
}
