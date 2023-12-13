using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadeiraAttack : MonoBehaviour
{   
    public GameObject Player;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private bool close = false;

    void Start(){

    }

    void Update(){
        timer += Time.deltaTime;
        if(close){
            if(timer > 2){
                timer = 0;
                shoot();
            }
        }
        if(Player.activeInHierarchy == false){
            gameObject.SetActive(false);
        }
    }

    void shoot(){
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag.Equals("Player") == true){
            close = true;
        }
    }
}
