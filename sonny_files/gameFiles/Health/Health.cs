using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
   [SerializeField] private float startingHealth;
   public float currentHealth { get; private set;}
   private bool dead;
   
    [Header ("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numFlashes;
    private SpriteRenderer spriteRend;



   private void Awake() 
   {
       currentHealth = startingHealth;
       spriteRend = GetComponent<SpriteRenderer>();
   }

   public void AddHealth()
   {
       currentHealth += 1;
   }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // no dead
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;

            }

        }
    }
    
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        for(int i = 0; i < numFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6,7,false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}