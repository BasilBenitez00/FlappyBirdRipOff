using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDisabler : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) {
       

       if(other.CompareTag("Disabler"))
       {
           GameObject obj = other.gameObject;
           obj.SetActive(false);
       }
   }
}
