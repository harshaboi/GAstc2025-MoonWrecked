using System;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;

    private Ray2D ray;

    public Transform firePoint;

    private bool facingRight = true;
    private Rigidbody2D rb;

    [SerializeField] private GameObject player;
    private Player_Movement pMovement;
    private float speed = 2f;
    private bool playerDead = false;

    [SerializeField] private AudioSource deadSFX;
    // public GameObject deathEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        deadSFX.Stop();
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        pMovement = player.GetComponent<Player_Movement>();

    }

    // Update is called once per frame
    void Update(){
        playerDead = pMovement.getDead();
        //if the player is dead, or on a different floor, the enemy will not move
        if(playerDead || player.transform.position.y > transform.position.y + 0.15f || player.transform.position.y < transform.position.y - 0.15f){
            stopMoving();
        }
    }
    //If the player bullet hits the enemy, the enemy dies
    public void takeDamage(){
        //stops enemy from moving but FIX HERE CUS IT STILL MOVES
        stopMoving();
        //Starts enemy death animation
        anim.SetBool("isDead", true);
    }

    //once death animation is done, destroy enemy gameobject
    public void die(){
        Invoke("delayed", 0.3f);
    }
    private void delayed(){
        Destroy(gameObject);
    }
    public void playDeathSFX(){
        deadSFX.Play();
    }
    //flips the enemy based on the enemy weapon script
    public void Flip()
	{
		facingRight = !facingRight;
		transform.Rotate(0f, 180f, 0f);
	}
    //Getter method for facingRight
    public bool getFacing(){
        return facingRight;
    }
    //makes enemy move left
    public void moveLeft(){
        rb.linearVelocity = new Vector2(-speed, 0f);
        anim.SetFloat("Speed", speed);
    }
    //makes enemy move right
    public void moveRight(){
        rb.linearVelocity = new Vector2(speed, 0f);
        anim.SetFloat("Speed", speed);
    }
    //Makes enemy stop moving
    public void stopMoving(){
        rb.linearVelocity = Vector2.zero;
        anim.SetFloat("Speed", 0);
    }
}
