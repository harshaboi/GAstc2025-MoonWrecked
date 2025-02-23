using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Elevator : MonoBehaviour
{
    private bool textEnable = false;
    private Rigidbody2D rb;
    private bool onSecond = false;
    private bool isMoving = false;
    private bool touchingPlayer = false;
    private bool canMove = true;
    private float moveTime = 5.5f;
    private float speed = 2.5f;
    private AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Stop();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!touchingPlayer){
            touchingPlayer = false;
        }
        if(!isMoving && touchingPlayer && Input.GetButtonDown("Interact") && canMove){
            changeLevel();
        }
        if(!isMoving){
            source.Stop();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = true;
            textEnable = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            textEnable = false;
        }
    }


    private void changeLevel(){
        source.Play();
        Invoke("stopMoving", moveTime);
        onSecond = !onSecond;
        isMoving = true;
        canMove = false;
        if(!onSecond){
            rb.linearVelocity = new Vector2(0f, -speed);
            //rb.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
        }else{
            rb.linearVelocity = new Vector2(0f, speed);
            //rb.AddForce(Vector2.down * 15, ForceMode2D.Impulse);
        }
    }

    private void stopMoving(){
        isMoving = false;
        rb.linearVelocity = Vector2.zero;
        canMove = true;
    }
    public bool getTextEnable(){
	    return textEnable;
    }

    public bool getMoving(){
        return isMoving;
    }
}
