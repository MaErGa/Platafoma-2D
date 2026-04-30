using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu] // para que nos cree un menu en el menu de unity
public class InventoryStats : ScriptableObject
{
    public int Coins;
    public void ResetValues()
    {
        Coins = 0;
    }

}
