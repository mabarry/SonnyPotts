using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   [SerializeField] public float increase;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.tag == "Player")
       {
           collision.GetComponent<Health>().AddHealth();
           GameObject player = collision.gameObject;
           PlayerMovement playerscript =  player.GetComponent<PlayerMovement>();

           if (playerscript) {
               playerscript.speed *= increase;

               Destroy(gameObject);
           }
       }
   }
}
