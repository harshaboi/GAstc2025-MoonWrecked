using UnityEngine;

public class Bullet : MonoBehaviour
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
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            enemy.takeDamage();
        }
        anim.SetBool("Collided", true);
    }
    public void destroyThis(){
        Destroy(gameObject);
    }
}
