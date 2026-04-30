using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public InventoryStats inventoryStats;
    // una variable para la animacion
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventoryStats.Coins += 1; //esto suma uno al coger una moneda
            gameObject.SetActive(false); //desactiva la moneda
        }
    }
}
