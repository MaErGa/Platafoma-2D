using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLife : MonoBehaviour
{
    public Image barra;
    public PlayerStats playerStats;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = player.GetComponent<PlayerController>().Life / playerStats.MaxLife;

    }
}
