using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;

    public GameObject player;

    private Player_Movement pMovement;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pMovement = player.GetComponent<Player_Movement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        health = pMovement.getHealth();
        anim.SetInteger("Health", health);
    }
}
