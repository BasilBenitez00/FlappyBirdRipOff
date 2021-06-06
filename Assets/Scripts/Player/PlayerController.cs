using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private float jumpForce;



    // Start is called before the first frame update
     void Awake() 
    {

        if(playerRigidbody == null)
        {
            playerRigidbody = GetComponent<Rigidbody2D>();

        }
            
        
    }
  

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButton(0))
        {
            Jump();
        }
    }


    private void Jump()
    {
        playerRigidbody.velocity = Vector2.up * jumpForce;
    }

}
