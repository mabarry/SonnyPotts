using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip sun_sound;
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.tag == "Player"){
           SoundManager.instance.PlaySound(sun_sound);
           GameObject player = collision.gameObject;
           Destroy(player);
           GameManager.instance.YouWin();
       }
   }
}
