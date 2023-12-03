using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   

    public int HP = 10;
    private new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    private Vector2[] directions = {Vector2.up, Vector2.down, Vector2.left, Vector2.right};
    private System.Random rnd = new System.Random();
    private int v1 = 3;
    private float nextActionTime = 0.0f;
    public float period = 1.0f;
    public float speed = 5f;
    public bool isWalking = false;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererRight;
        isWalking = false;
    }

    void Update()
    {
        v1 = rnd.Next(3);
        if(Time.time > nextActionTime){
            nextActionTime += period;
            if (directions[v1] == Vector2.up){
                SetDirection(directions[v1], spriteRendererUp);
            } else if (directions[v1] == Vector2.down){
                SetDirection(directions[v1], spriteRendererDown);
            } else if (directions[v1] == Vector2.left){
                SetDirection(directions[v1], spriteRendererLeft);
            } else {
                SetDirection(directions[v1], spriteRendererRight);
            }
        }
    }

    private void FixedUpdate()
    {   
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {   
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
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
        if( target.gameObject.tag.Equals("TileMap") == true ){
            direction = direction * -1;
            if (direction == Vector2.up){
                SetDirection(direction, spriteRendererUp);
            } else if (direction == Vector2.down){
                SetDirection(direction, spriteRendererDown);
            } else if (direction == Vector2.left){
                SetDirection(direction, spriteRendererLeft);
            } else {
                SetDirection(direction, spriteRendererRight);
            }
        }
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
