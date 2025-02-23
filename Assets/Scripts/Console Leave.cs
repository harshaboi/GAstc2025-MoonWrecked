using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsoleLeave : MonoBehaviour
{
    [SerializeField] private Minigame1 mini1;
    [SerializeField] private Minigame2 mini2;
    void OnCollisionStay2D(Collision2D collider){
        if(collider.gameObject.tag == "Player"){
            if(Input.GetButtonDown("Interact") && mini1.getWon() && mini2.getWon()){
                SceneManager.LoadScene("End", LoadSceneMode.Single);
            }
        }
    }
}
