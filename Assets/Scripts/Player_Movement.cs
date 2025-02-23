using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Cinemachine;
using UnityEditor;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator anim;
    private float horizontalMove;
    private float verticalMove;
    private bool jump = false;
    private float runSpeed = 25f;

    private int health = 5;

    private bool isDead = false;

    public bool isRolling = false;

    private bool facingRight = true;

    private float rollCooldown = 0;
    //this tempRoll float resets the rollCooldown float to the amount of seconds to wait before rolling again
    private float rollTemp = 1;

    private float rollDistance = 5f;
    public Rigidbody2D rb;
    [SerializeField] private AudioSource deadSFX;
    private CharacterController2D charControl;
    [SerializeField] private CinemachineCamera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        charControl = GetComponent<CharacterController2D>();
        deadSFX.Stop();
    }

    // Update is called once per frame
    void Update(){     
        facingRight = charControl.getFacing();
        verticalMove = rb.linearVelocityY;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
        //TODO Create roll implementation
        anim.SetFloat("jumpFloat", rb.linearVelocityY);
        if(Input.GetButtonDown("Roll") && rollCooldown <= 0 && Mathf.Abs(getVertical()) <= 0.01){
            isRolling = true;
            anim.SetBool("isRolling", isRolling);
        }
    }

    void FixedUpdate(){
        //Since FixedUpdate runs at 50 frames per second, by subtracting 0.02(1/50) each frame from runCooldown, each second, rollCooldown reduces by 1 in value each second
        rollCooldown -= 0.02f;
        //makes sure the not keep the rolling animation looping
        anim.SetBool("isRolling", isRolling);
        //if dead or is shooting, dont move or jump
        if(anim.GetBool("isShooting") || isDead){
            horizontalMove = 0f;
            jump = false;
        }
        //if not rolling, then player can move manually
        if(!isRolling && cam.Priority != 0){
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
    //getter to get horizontal movement
    public float getHorizontal(){
        return horizontalMove;
    }
    //getter to get vertical movement
    public float getVertical(){
        return verticalMove;
    }
    //Makes player take damage
    public void takeDamage(int damage){
        health -= damage;
        if(health <= 0){
            die();
        }
    }
    //Makes player die
    void die(){
        isDead = true;
        anim.SetBool("isDead", true);
        deadSFX.Play();
    }
    //getter that returns health
    public int getHealth(){
        return health;
    }
    //makes player roll(called in an event in the animation tab)
    private void roll(){
        //sets rollCooldown to rollTemp to reset the cooldown
        rollCooldown = rollTemp; 
        //Changes direction in which player rolls depending on direction player is facing
        if(facingRight){
            rb.linearVelocity = new Vector2(rollDistance, 0f);
        }else{
            rb.linearVelocity = new Vector2(-rollDistance, 0f);
        }
    }
    //Stops the player from rolling
    private void stopRoll(){
        rb.linearVelocity = Vector2.zero;
        isRolling = false;
    }
    public bool getDead(){
        return isDead;
    }
}
