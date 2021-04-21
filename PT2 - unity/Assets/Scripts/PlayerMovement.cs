using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Rspeed = 3.5f;
    public float Jspeed = 12.0f;
    public Transform feetpos;
    
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatisGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private float moveInput;
    private bool isjumping;
    Rigidbody2D rbody;
    public Animator anim;
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start(){
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal");
        rbody.velocity = new Vector2(moveInput * Rspeed, rbody.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
        }
        
    }
    void Update(){
        anim.SetFloat("Hspeed", Mathf.Abs(rbody.velocity.x));
        anim.SetFloat("Jspeed", Mathf.Abs(rbody.velocity.y));
        anim.SetBool("isgrounded", isGrounded);
        anim.SetBool("isjumping", isjumping);
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatisGround);

        if(rbody.velocity.x>0){
            render.flipX = false;
        }else if(rbody.velocity.x == 0){
            render.flipX = false;
        }
        else{
            render.flipX = true;
        }
        if(isGrounded == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))){
            isjumping = true;
            jumpTimeCounter = jumpTime;
            rbody.velocity = new Vector2(rbody.velocity.x, Jspeed);
        }
        
        if(isjumping == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))){
            if(jumpTimeCounter>0){
                rbody.velocity = new Vector2(rbody.velocity.x, Jspeed);
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isjumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)){
            isjumping = false;
        }
    }
}
