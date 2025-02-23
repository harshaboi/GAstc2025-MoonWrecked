using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject impact;
    private StartMenuFadeIn cGroup;
    private AudioSource source;
    void Start(){
        source = GetComponent<AudioSource>();
        cGroup = canvas.GetComponent<StartMenuFadeIn>();
    }
    public void destroySelf(){
        cGroup.fadeIn();
        Destroy(gameObject);
    }

    public void playSound(){
        impact.SetActive(true);
    }
}
