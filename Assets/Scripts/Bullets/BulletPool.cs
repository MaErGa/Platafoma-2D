using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance; //se instancia a si mismo
    public List<GameObject> pooledObjects; //la lista para la piscina de objetos
    public GameObject objectToPool; //los objetos que van a ir en la piscina
    public int amountToPool; // cantidad de objectos a meter en la piscina

    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>(); //declaramos la lista
        GameObject tmp; //agregamos un gameobject temporal
        for (int i = 0; i < amountToPool; i++) // le decimos que si i es igual a cero que i si es menor a la cantidad de objectos en la piscina, luego autoincrementa i
        {
            tmp = Instantiate(objectToPool); // instanciamos los objectos en la piscina
            tmp.SetActive(false); // les decimos que inicien como desactivados
            pooledObjects.Add(tmp); // añade los objectos temporales a la piscina
        }
    }
    public GameObject GetPooledObject()//rellena la piscina de los objectos pooleados para que siempre este la lista "llena"
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
