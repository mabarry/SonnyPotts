using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spider : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("SFX")]
    [SerializeField] private AudioClip enemy_spider_sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
             SoundManager.instance.PlaySound(enemy_spider_sound);
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    } 
    
}
