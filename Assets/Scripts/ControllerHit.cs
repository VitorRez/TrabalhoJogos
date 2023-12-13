using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHit : MonoBehaviour
{

    private void Start(){
        GameObject player = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}
