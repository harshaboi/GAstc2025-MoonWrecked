using NUnit.Framework.Interfaces;
//using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy_Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;

    private Transform firePoint;

    public GameObject robot;
    private Enemy enemy;

    private Animator anim;
    private bool isShooting = false;

    private float flipCooldown = 0.5f;
    private float lastFlipTime;
    private float shootDelay = 0.1f;

    private bool hasLineOfSight = false;

    private bool facingRight;

    private GameObject player;

    private RaycastHit2D hitInfo;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = robot.GetComponent<Enemy>();
        firePoint = enemy.firePoint;
        anim = enemy.anim;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        facingRight = enemy.getFacing();
        //Implements a cooldown between each flip
        if (Time.time - lastFlipTime > flipCooldown){
            //Flips the enemy based on the enemy's facing and player's position relative to enemy position
            if (player.transform.position.x > enemy.transform.position.x && !facingRight){
                enemy.Flip();
                lastFlipTime = Time.time;
            }
            else if (player.transform.position.x < enemy.transform.position.x && facingRight){
                enemy.Flip();
                lastFlipTime = Time.time;
            }
        }
        //sets the animation for enemy shooting(also creates the bullet through events in animation tab) and turns off shooting animation if not currently shooting
        anim.SetBool("isShooting", isShooting);
        //Creates rays to detect player based on facing
        if (facingRight){
            hitInfo = Physics2D.Raycast(firePoint.position, Vector2.right, 5f, LayerMask.GetMask("Player", "Obstacles"));
            Debug.DrawRay(firePoint.position, Vector2.right * 5, Color.blue);
        }
        else{
            hitInfo = Physics2D.Raycast(firePoint.position, Vector2.left, 5f, LayerMask.GetMask("Player", "Obstacles"));
            Debug.DrawRay(firePoint.position, Vector2.left * 5, Color.blue);
        }
        //if the ray hits the player, the enemy has line of sight, if not, no line of sight.
        if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player")){
            hasLineOfSight = true;
        }
        else{
            hasLineOfSight = false;
        }
        //if the enemy has line of sight, the enemy stops moving and shoots
        if(hasLineOfSight){
            enemy.stopMoving();
            isShooting = true;
            anim.SetBool("isShooting", isShooting);
        }
        //if enemy isnt shooting, they move towards the player
        if(!isShooting){
            if(enemy.getFacing()){
                enemy.moveRight();
            }else{
                enemy.moveLeft();
            }
        }
    }

    //Creates the bullet
    public void shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Invoke("stopShooting", shootDelay);
    }

    //This si used to stop the shooting animation once the bullet is fired
    private void stopShooting(){
        isShooting = false;
    }

}
