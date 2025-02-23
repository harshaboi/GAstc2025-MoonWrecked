//This code was aided by ChatGPT
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : MonoBehaviour
{
    [SerializeField] private Button[] buttons; // Assign in Inspector
    private List<int> sequence = new List<int>();
    private int currentStep = 0;
    private bool playerTurn = false;
    [SerializeField] private CinemachineCamera cam;
    [SerializeField] private CinemachineCamera mainCam;
    [SerializeField] private GameObject canvas;
    private int counter = 0;
    private AudioSource source;
    [SerializeField] private AudioClip wrongClip;
    [SerializeField] private AudioClip correctClip;
    private bool gameWon = false;
    void Start()
    {
        source = cam.GetComponent<AudioSource>();
        StartCoroutine(GenerateSequence());
    }

    void Update(){
        //If the player presses x, exit the game
        if(Input.GetKeyDown(KeyCode.X)){
            cam.Priority = 0;
            mainCam.Priority = 1;
        }
        if(cam.Priority == 1){
            canvas.SetActive(true);
        }else{
            canvas.SetActive(false);
        }
        if(counter == 5){
            mainCam.Priority = 1;
            cam.Priority = 0;
        }
    }

    IEnumerator GenerateSequence()
{
    yield return new WaitForSeconds(1f);
    
    sequence.Add(Random.Range(0, buttons.Length)); // Add new step to sequence
    
    for (int i = 0; i < sequence.Count; i++)
    {
        int index = sequence[i];
        buttons[index].image.color = Color.white; // Highlight button
        yield return new WaitForSeconds(0.5f);
        buttons[index].image.color = Color.gray; // Reset color
        yield return new WaitForSeconds(0.5f);
    }

    playerTurn = true;
    currentStep = 0;
}


    public void PlayerPress(int buttonIndex){
    if (!playerTurn || sequence.Count == 0) return; // Prevent out-of-range error

    if (buttonIndex == sequence[currentStep])
    {
        currentStep++;
        if (currentStep == sequence.Count){
            source.PlayOneShot(correctClip);
            counter++;
            playerTurn = false;
            gameWon = true;
            StartCoroutine(GenerateSequence()); // Start new round
        }
    }
    else{
        source.PlayOneShot(wrongClip);
        counter = 0;
        sequence.Clear();
        StartCoroutine(GenerateSequence());
    }
}

    public bool getWon(){
        return gameWon;
    }
}
