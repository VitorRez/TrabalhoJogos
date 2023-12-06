using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{   
    public int HP = 10;
    public GameObject P;
    public Transform player;
    public float speed;
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    private bool move = false;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(move){
            if (movement.y > 0){
                SetDirection(spriteRendererUp);
            } else if (movement.y < 0){
                SetDirection(spriteRendererDown);
            } else if (movement.x < 0){
                SetDirection(spriteRendererLeft);
            } else {
                SetDirection(spriteRendererRight);
            }
        }
        if(P.activeInHierarchy == false){
            gameObject.SetActive(false);
        }
    }

    private void SetDirection(AnimatedSpriteRenderer spriteRenderer)
    {   
        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag.Equals("Player") == true){
            print("close");
            move = true;
        }
    }

    void OnCollisionEnter2D(Collision2D target){
        if( target.gameObject.tag.Equals("Projectile") == true ){
            HP--;
            print("hit");
            if( HP <= 0 ){
                print("Dead");
                DeathSequence();
            }
        }
    }

    void FixedUpdate(){
        if(move){
            this.GetComponent<EnemyMovement>().enabled = false;
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
            MoveCharacter();
        }
    }

    private void MoveCharacter(){
        rigidbody.MovePosition((Vector2)transform.position + (movement * speed *Time.deltaTime));
    }

    private void DeathSequence()
    {
        enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 0.5f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
    }
}
