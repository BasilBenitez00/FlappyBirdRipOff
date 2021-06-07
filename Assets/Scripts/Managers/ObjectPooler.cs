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
    public GameObject[] objectToPool;
    public int amount;


    public void InitializePool()
    {
        pooledObjects = new List<GameObject>();

        foreach (var item in objectToPool)
        {
            for (int i = 0; i < amount; i++) 
            {
               AddPooledObjects(item);
            }
        }
    }

    public void AddPooledObjects(GameObject poolObject)
    {
       
        GameObject obj = (GameObject)Instantiate(poolObject);
        obj.SetActive(false); 
        pooledObjects.Add(obj);
        
    }

    public GameObject GetPooledObject(string tag)
    {
        
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag))
            {
               
                return pooledObjects[i];
            }
        }
       return null;
    }



}
