using TMPro;
using UnityEngine;

public class Mini2Trigger : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private bool showText = false;
    private bool changeToTwo = false;
    [SerializeField]private GameObject circle;
    private Minigame2 mini2;
    private AudioSource source;
    [SerializeField] private AudioClip clip;
    private bool sound = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        mini2 = circle.GetComponent<Minigame2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mini2.playSound() && sound){
            PlaySounds();
        }
        if(changeToTwo){
            changeToTwo = !changeToTwo;
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
                changeToTwo = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            showText = false;
        }
    }
    public bool changeToTwoCam(){
        return changeToTwo;
    }
    private void PlaySounds(){
        sound = false;
        source.PlayOneShot(clip);
    }
}
