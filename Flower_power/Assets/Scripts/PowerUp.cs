using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   [SerializeField] public float increase;
   [Header("SFX")]
   [SerializeField] private AudioClip power_sound;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.tag == "Player")
       {
           SoundManager.instance.PlaySound(power_sound);
           collision.GetComponent<Health>().AddHealth();
           GameObject player = collision.gameObject;
           Player_Movement playerscript =  player.GetComponent<Player_Movement>();

           if (playerscript) {
               playerscript.hasDoubleJump = true;

               Destroy(gameObject);
           }
       }
   }
}
