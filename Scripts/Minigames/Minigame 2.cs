//This code is aided by ChatGpt
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Cinemachine;
using UnityEngine;

public class Minigame2 : MonoBehaviour
{
    private float forceStrength = 2f; // How strong the player's movement force is
    private float driftSpeed = 0f; // How fast the object drifts randomly
    [SerializeField] private Transform centerZone; // Assign an empty GameObject as the center zone
    private float winTime = 3.5f; // How long the player must keep the object stable

    private Rigidbody2D rb;
    private float timeInCenter = 0f; // Timer for winning
    private bool gameWon = false;

    [SerializeField] private GameObject canvas;
    [SerializeField] private CinemachineCamera cam;
    [SerializeField] private CinemachineCamera mainCam;

    private float moveX;
    private float moveY;

    private bool play = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(cam.Priority == 1){
            canvas.SetActive(true);
        }else{
            canvas.SetActive(false);
        }
        if (gameWon){
            cam.Priority = 0;
            mainCam.Priority = 1;
        }

        if(cam.Priority == 1){
            // Add force to move left/right (A/D or Left/Right Arrow)
            moveX = Input.GetAxis("Horizontal");
            
            // Add force to move up/down (W/S or Up/Down Arrow)
            moveY = Input.GetAxis("Vertical");
        }


        // Apply movement force
        rb.AddForce(new Vector2(moveX * forceStrength, moveY * forceStrength));

        // Apply random drift effect (both horizontal and vertical)
        rb.linearVelocity += new Vector2(Random.Range(-driftSpeed, driftSpeed) * Time.deltaTime, 
                                   Random.Range(-driftSpeed, driftSpeed) * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("CenterZone")) // Center area must have "CenterZone" tag
        {
            timeInCenter += Time.deltaTime;
            if (timeInCenter >= winTime)
            {
                play = true;
                gameWon = true;
                Debug.Log("You stabilized the gravity! Mini-game complete.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CenterZone"))
        {
            timeInCenter = 0; // Reset timer if object leaves center zone
        }
    }

    public bool getWon(){
        return gameWon;
    }

    public bool playSound(){
        return play;
    }
}
