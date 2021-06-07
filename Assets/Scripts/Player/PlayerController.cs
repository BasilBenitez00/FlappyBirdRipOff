using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private float jumpForce;


    // shooting variables
    private float fireRate = 0.7f;
    public Transform shootPoint;
    private float range;
    private float currentShootRate;

    private float replenishTime;
    private float timer;

    private int currentBullets;
    private int maxTotalAmmo;
   

    public LineRenderer lineRenderer;





    // Start is called before the first frame update
     void Awake() 
    {

        if(playerRigidbody == null)
        {
            playerRigidbody = GetComponent<Rigidbody2D>();

        }
        currentShootRate = 0f;
        currentBullets = 50;
        maxTotalAmmo = 50;
        fireRate = 0.5f;
        replenishTime = 1.5f;
        range =3f;
        
    }
  

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine (shootPoint.position, new Vector3(range ,shootPoint.position.y,0), Color.red);
        if(Input.GetKeyDown(KeyCode.Space))
        {
           Jump();
        }
        if(Input.GetMouseButton(0))
        {
            if (currentShootRate < fireRate || currentBullets <= 0 )
		    return;

            StartCoroutine(Shoot()) ;
        }

        if(currentBullets!= maxTotalAmmo)
            ReplenishAmmo();

        if(currentShootRate < fireRate)											// rate of fire, for keeping it in check.			
		{
			currentShootRate += Time.deltaTime;
		}
    }


    private void Jump()
    {
        playerRigidbody.velocity = Vector2.up * jumpForce;
    }

    IEnumerator Shoot()
    {
        

        
        RaycastHit2D hitInfo = Physics2D.Raycast(shootPoint.position, shootPoint.right,range);
        
    
        if(hitInfo)
        {
            
           
            GameObject obj = hitInfo.transform.gameObject;
            if(obj.CompareTag("Enemy"))
            {
                obj.SetActive(false);
                Debug.Log("Hit");
                
                lineRenderer.SetPosition(0, shootPoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
              
        }
        else
        {
            Debug.Log("hit nothing");
            lineRenderer.SetPosition(0, shootPoint.position);
            lineRenderer.SetPosition(1, shootPoint.position + shootPoint.right * 5f);

        }

        currentBullets--;
        currentShootRate =0f;
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.03f);

        lineRenderer.enabled = false;

       
        
    }

    void ReplenishAmmo()
    {
        
        if(currentBullets < maxTotalAmmo)
        {
          
           timer += Time.deltaTime;
           if(timer >= replenishTime)
           {
               currentBullets++;
               timer =0;
           }
            
        }
    }

}
