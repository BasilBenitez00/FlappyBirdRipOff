using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{

    [SerializeField]
    private float spawnTimer;
    [SerializeField]
    private float spawnInterval;

    [SerializeField]
    private float ceilingHeight = -2;

    [SerializeField]
    private float floorHeight = 0.5f;


    [SerializeField]
    private Transform spawnPoint;

    private const float delay = 20f;

    private void Start() {
        
        SpawnObstacles();
    }

    private void Update() 
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        if(spawnTimer > spawnInterval)
        {
            GameObject obj = ObjectPooler.Instance.GetPooledObject();
            obj.SetActive(true);
            obj.transform.position = spawnPoint.transform.position + new Vector3(0, Random.Range(ceilingHeight, floorHeight), 0);
            spawnTimer = 0;
            StartCoroutine(DeSpawnObstacles(obj, delay));
            
        }
        spawnTimer +=Time.deltaTime;
    }

    IEnumerator DeSpawnObstacles(GameObject obj,float delay)
    {
        
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        
    }

    

   
}
