using Unity.VisualScripting;
using UnityEngine;

public class Canvasmusic : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip clip;
    private CanvasGroup cGroup;
    private bool play = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        cGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cGroup.alpha != 0 && play){
            playSound();
        }
    }

    private void playSound(){
        play = false;
        source.PlayOneShot(clip);
    }
}
