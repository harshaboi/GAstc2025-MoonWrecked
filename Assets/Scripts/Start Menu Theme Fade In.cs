using UnityEngine;

public class StartMenuThemeFadeIn : MonoBehaviour
{
    private AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        source.volume += 0.004f;
    }
}
