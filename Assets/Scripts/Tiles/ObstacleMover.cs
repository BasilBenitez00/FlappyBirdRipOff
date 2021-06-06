using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;



    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    void ObstacleMove()
    {
       transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
    }

}
