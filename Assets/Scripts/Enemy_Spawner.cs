using System;
using System.Collections;
using Unity.VisualScripting;
//using UnityEditor.Rendering;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour{
    private float timeElapsed ;

    [SerializeField]private Transform spawnPoint;
    private float spawnDelay = 5f;
    private bool canSpawn = true;
    public int stage = 1;

    public GameObject Enemy;

    void FixedUpdate(){
        //timeElapsed is in seconds.
        timeElapsed = Mathf.Round(Time.fixedTime);
        Debug.Log(timeElapsed);
        // Also implement the text showing after each stage progression
        if(timeElapsed >= 10 && stage == 1){
            stage++;
        }
        if(timeElapsed >= 15 && stage == 2){
        stage++;
        }
        if(stage == 3 && timeElapsed % 35 == 0 && canSpawn){
            spawnEnemy();
        }
    }

    public void spawnEnemy(){
        Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
        canSpawn = false;
        Invoke("yesSpawn", spawnDelay);
    }

    private void yesSpawn(){
        canSpawn = true;
    }
}