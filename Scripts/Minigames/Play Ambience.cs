using UnityEngine;

public class PlayAmbience : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private AudioSource source;
    private int rand;
    private bool playing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        source = GetComponent<AudioSource>();
        source.Stop();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(!playing){
            play();
        }
    }

    private void play(){
        source.PlayOneShot(clip);
        playing = true;
        Invoke("stopPlaying", 16f);
    }

    private void stopPlaying(){
        playing = false;
    }
}
