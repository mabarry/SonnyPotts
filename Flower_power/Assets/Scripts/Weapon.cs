using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [Header("SFX")]
    [SerializeField] private AudioClip shoot_sound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }   
    }

    void Shoot()
    {
        SoundManager.instance.PlaySound(shoot_sound);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

