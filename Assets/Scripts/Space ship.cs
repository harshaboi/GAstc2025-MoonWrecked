using Vector3 = UnityEngine.Vector3;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Vector3 scaleChange;
    private Vector3 posChange;
    private int counter = 0;
    private GameObject explosion;
    private Explosion exp;
    private Animator expAnim;
    private Animator shipAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        scaleChange = new Vector3(0.03f, 0.03f, 0f);
        posChange = new Vector3(0.15325336f, 0.072f, 0f);
        explosion = GameObject.Find("Explosion");
        //exp = explosion.GetComponent<Explosion>();
        expAnim = explosion.GetComponent<Animator>();
        shipAnim = GetComponent<Animator>();
    }

    // Fixed Update is called 50 times per second
    void FixedUpdate(){
        counter++;
        transform.localScale -= scaleChange;
        transform.localPosition += posChange;
        if(counter == 125){
            expAnim.SetBool("Explode", true);
            scaleChange = new Vector3(0, 0, 0);
            posChange = new Vector3(0, 0, 0);
            shipAnim.SetBool("stopMove", true);
        }
    }
}
