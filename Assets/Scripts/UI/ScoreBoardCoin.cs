using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Texto unity

public class ScoreBoardCoin : MonoBehaviour
{
    public InventoryStats inventoryStats;
    public TextMeshProUGUI scoreCoins;
    void Awake()
    {
        inventoryStats.Coins = 0; // cambia el texto a 0 nada mas entrar, esto se hace para que siempre inicie visualmente con 0 monedas
    }


    void Update()
    {
        scoreCoins.text = inventoryStats.Coins.ToString();
        // sustituye el texto actual por la cantidad de monedas que el jugador ha recolectado 
    }
}
