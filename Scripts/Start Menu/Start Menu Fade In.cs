using UnityEngine;

public class StartMenuFadeIn : MonoBehaviour
{
    private CanvasGroup cGroup;
    private bool start = false;
    [SerializeField] private GameObject source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        cGroup = GetComponent<CanvasGroup>();
        cGroup.alpha = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(start && cGroup.alpha <= 255){
            source.SetActive(true);
            cGroup.alpha += 0.02f;
        }
    }
    
    public void fadeIn(){
        start = true;
    }
}
