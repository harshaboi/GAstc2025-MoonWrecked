using TMPro;
using UnityEngine;

public class Mini1Trigger : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private bool showText = false;
    private bool changeToOne = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(changeToOne){
            changeToOne = !changeToOne;
        }
        if(showText){
            text.SetText("Interact");
        }else{
            text.SetText("");
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            showText = true;
            if(Input.GetButtonDown("Interact")){
                changeToOne = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            showText = false;
        }
    }
    public bool changeToOneCam(){
        return changeToOne;
    }
}
