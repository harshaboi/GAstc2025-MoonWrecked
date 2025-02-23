using Vector3 = UnityEngine.Vector3;
using UnityEngine;

public class Spaceship2 : MonoBehaviour
{
    private Vector3 scaleChange;
    private Vector3 posChange;
    private int counter = 0;
    private Animator shipAnim;
    [SerializeField] private CanvasGroup cGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        cGroup.alpha = 0;
        scaleChange = new Vector3(0.03f, 0.03f, 0f);
        posChange = new Vector3(0.07662668f, 0.036f, 0f);
        shipAnim = GetComponent<Animator>();
    }

    // Fixed Update is called 50 times per second
    void FixedUpdate(){
        counter++;
        if(counter >= 250){
            cGroup.alpha += 0.02f;
            Invoke("DestroySelf", 1f);
        }
        transform.localScale += scaleChange;
        transform.localPosition += posChange;
    }

    private void DestroySelf(){
        Destroy(gameObject);
    }
}
