using TMPro;
using UnityEngine;

public class ElevatorText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Elevator elevator;
    [SerializeField] private TMP_Text text;
    void Start(){
        elevator = GetComponent<Elevator>();
    }

    void Update(){
        if(elevator.getTextEnable() && !elevator.getMoving()){
            text.SetText("Change Floor");
        }else{
            text.SetText("");
        }
    }

}
