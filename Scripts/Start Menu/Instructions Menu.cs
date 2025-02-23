using UnityEngine;

public class InstructionsMenu : MonoBehaviour
{
    [SerializeField]private GameObject canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instructionOn(){
        canvas.SetActive(true);
    }
    public void instructionOff(){
        canvas.SetActive(false);
    }
}
