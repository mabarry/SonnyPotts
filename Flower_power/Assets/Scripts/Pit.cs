using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip pit_sound;
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.tag == "Player"){
           SoundManager.instance.PlaySound(pit_sound);
           GameManager.instance.GameOver();
       }
   }
}
