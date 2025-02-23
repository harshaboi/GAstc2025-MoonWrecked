using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPriorities : MonoBehaviour
{
    [SerializeField] CinemachineCamera main;
    [SerializeField] CinemachineCamera cm1;
    [SerializeField] CinemachineCamera cm2;

    [SerializeField] private GameObject mini1Trigger;
    [SerializeField] private GameObject mini2Trigger;
    private Mini1Trigger trig1;
    private Mini2Trigger trig2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trig1 = mini1Trigger.GetComponent<Mini1Trigger>();
        trig2 = mini2Trigger.GetComponent<Mini2Trigger>();
        cm1.Priority = 0;
        cm2.Priority = 0;
        main.Priority = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (trig1.changeToOneCam()) {
            goToMini1();
        }
        if (trig2.changeToTwoCam()) {
            goToMini2();
        }
    }

    public void goToMini1(){
        cm1.Priority = 1;
        cm2.Priority = 0;
        main.Priority = 0;
    }

        public void goToMini2(){
        cm1.Priority = 0;
        cm2.Priority = 1;
        main.Priority = 0;
    }

    public void goToMain(){
        cm1.Priority = 0;
        cm2.Priority = 0;
        main.Priority = 1;
    }

}
