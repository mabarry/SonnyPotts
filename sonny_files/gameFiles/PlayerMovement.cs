using UnityEngine;
//The code for moving and jumping and farting and shitting
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask wallLayer;
    private float wallJumpCooldown;
    private float horizontalInput;
    [Header ("SFX")]
    [SerializeField]private AudioClip jumpSound;
 
    bool canDoubleJump;
 
    private void Awake()
    {
        //Grab references for rigidbody and animator functions from game object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
 
    private void Update()
    {
        //This sets the movement of the character
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput * speed,body.velocity.y);
        //This moves the character up and down, so the jumping action
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isGrounded()){
                Jump();
                canDoubleJump = true;
            //Allows for a double jump
            }else if(canDoubleJump){
                Jump();
                canDoubleJump = false;
 
            }
        }
        //This will flip the player when moving left
        if (horizontalInput> 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
 
        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        //Wall Jumping
        if(wallJumpCooldown < 0.2f){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(isGrounded()){
                    Jump();
                    canDoubleJump = true;
                }
            }
            body.velocity = new Vector3(horizontalInput * speed,body.velocity.y);
            //Allows players to stick to the wall
            /*if(onWall() && !isGrounded()){
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }else{
                //prevents levitation after hitting a wall
                body.gravityScale = 1;
            }*/
        }else{
            wallJumpCooldown += Time.deltaTime;
        }    
    }
    //Jump Method
   
    private void Jump()
    {
        if(isGrounded() || canDoubleJump){
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
        }else if(onWall() && !isGrounded()){
            //Changes the direction that the character is going when jumping off of the wall
            if (horizontalInput == 0){
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }else{
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 1, 6);
            }
            wallJumpCooldown = 0;
        }
       
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
 
    //Boolean for whether the character is on the ground
    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    //Returns boolean for whether a character is on the wall
    private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}

