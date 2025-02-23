using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{   
    private float speed = 15f;
    public Rigidbody2D rb;

    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        rb.linearVelocity = new Vector2(0f, 0f);
        Player_Movement pMovement = hitInfo.GetComponent<Player_Movement>();
        if(pMovement != null){
            pMovement.takeDamage(1);
        }
        anim.SetBool("Collided", true);
    }
    public void destroyThis(){
        Destroy(gameObject);
    }
}