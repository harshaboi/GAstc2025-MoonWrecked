using Unity.Cinemachine;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject player;

    private bool isShooting;

    public float shootDelay;

    [SerializeField] private CinemachineCamera cam;

    [SerializeField]private AudioSource source;
    [SerializeField] private AudioClip clip;


    // Update is called once per frame
    void Update()
    {
        Player_Movement pMovement = player.GetComponent<Player_Movement>();
        Animator animator = pMovement.anim;
        animator.SetBool("isShooting", isShooting);
        if(Input.GetButtonDown("Fire1") && pMovement.getHorizontal() == 0 && pMovement.getVertical() > - 0.01 && pMovement.getVertical() < 0.01 && cam.Priority != 0){
            isShooting = true;
            animator.SetBool("isShooting", isShooting);
        }
    }

    public void Shoot(){
        source.PlayOneShot(clip);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Invoke("stopShooting", shootDelay);
        
    }

    void stopShooting(){
        isShooting = false;
    }

    public bool getShooting(){
        return isShooting;
    }
}
