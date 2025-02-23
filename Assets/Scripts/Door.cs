using UnityEngine;
using TMPro;
public class Door : MonoBehaviour
{
    [SerializeField] private GameObject but;
    private DoorButton button;

    private bool animDone = true;
    private Animator anim;
    private bool prevState = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = but.GetComponent<DoorButton>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(prevState != button.getOpen()){
            anim.SetBool("Open", button.getOpen());
        }
        prevState = button.getOpen();
    }

    public void animFinished(){
        animDone = true;
    }
    public bool getAnim(){
        return animDone;
    }
}
