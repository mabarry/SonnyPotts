using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed_x = 20f;
    public float speed_y = 10f;
    public Rigidbody2D rb;
    public float spinSpeed = 10f;
    private float timer = 0.0f;

   
    // Start is called before the first frame update
    void Start()
    {
            rb.velocity = transform.right * speed_x + transform.up * speed_y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime * spinSpeed);
        timer += Time.deltaTime;
        if (timer>1.0f)
        {
            Destroy(gameObject);
        }
    }


    // Rotation speed (degrees/sec)
 


}
