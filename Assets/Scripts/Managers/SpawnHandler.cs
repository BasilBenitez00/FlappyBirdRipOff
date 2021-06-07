using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{

    [SerializeField]
    private float spawnTimer;
    private float crateTimer;
    private float enemyTimer;
    [SerializeField]
    private float spawnInterval;
    private float crateInterval;
    private float enemyInterval;

    [SerializeField]
    private float ceilingHeight = -2;

    [SerializeField]
    private float floorHeight = 0.5f;


    [SerializeField]
    private Transform spawnPoint;

    private const float delay = 15f;


    public Transform[] propSpawnPoints;

    private void Start() {
        
        SpawnObstacles();
        crateInterval = 10f;
        enemyInterval = 5f;
        
    }

    private void Update() 
    {
        SpawnObstacles();
        SpawnCrates();
        SpawnEnemy();
        
    }

    void SpawnObstacles()
    {
        if(spawnTimer > spawnInterval)
        {
            GameObject obj = ObjectPooler.Instance.GetPooledObject("Obstacle");
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

    void SpawnCrates()
    {
         if(crateTimer > crateInterval)
        {
            GameObject obj = ObjectPooler.Instance.GetPooledObject("Crate");
            obj.SetActive(true);
            obj.transform.position = RandomizePosition();
            crateTimer = 0;
           
            
        }
        crateTimer +=Time.deltaTime;
    }

    void SpawnEnemy()
    {
         if(enemyTimer > enemyInterval)
        {
            GameObject obj = ObjectPooler.Instance.GetPooledObject("Enemy");
            obj.SetActive(true);
            obj.transform.position = RandomizePosition();
            enemyTimer = 0;
            
        }
        enemyTimer +=Time.deltaTime;
    }

    Vector3 RandomizePosition()
    {
        int rand = Random.Range(1,3);
        switch (rand)
        {
            case 1:
            return propSpawnPoints[0].position;
            case 2:
            return propSpawnPoints[1].position;
            case 3:
            return propSpawnPoints[2].position;
        }
        return spawnPoint.position;

    }

    

   
}
