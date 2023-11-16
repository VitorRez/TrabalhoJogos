using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{   
    public int HP = 10;
    public AnimatedSpriteRenderer spriteRendererDeath;
    
    void OnCollisionEnter2D(Collision2D target){
        if( target.gameObject.tag.Equals("Projectile") == true ){
            HP--;
            print("hit");
            if( HP <= 0 ){
                print("Dead");
            }
        }
    }

    
}
