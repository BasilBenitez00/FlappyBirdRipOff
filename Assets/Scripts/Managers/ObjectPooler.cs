using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
     private static ObjectPooler instance;

    public static ObjectPooler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPooler>();
            }

            return instance;
        }
    }

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amount;

    public void AddPooledObjects()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amount; i++) 
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
               
                return pooledObjects[i];
            }
        }
       return null;
    }

}
