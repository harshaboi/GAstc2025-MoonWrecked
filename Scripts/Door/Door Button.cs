using TMPro;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private bool showText = false;
    private bool doorOpen = true;
    private Door door;
    [SerializeField] private GameObject d; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = d.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if(showText && doorOpen){
            text.SetText("Close Door");
        }else if(showText && !doorOpen){
            text.SetText("Open Door");
        }else{
            text.SetText("");
        }
    }
    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            showText = true;
            if(Input.GetButtonDown("Interact") && door.getAnim()){
                changeDoorState();
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            showText = false;
        }
    }
    private void changeDoorState(){
        doorOpen = !doorOpen;
    }
    public bool getOpen(){
        return doorOpen;
    }
}
