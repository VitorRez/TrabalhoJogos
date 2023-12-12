using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureAttack : MonoBehaviour
{

    public int HP = 10;
    public bool sound = false;
    public GameObject P;
    public Transform player;
    public float speed;
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    private bool move = false;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteFlyRight;
    public AnimatedSpriteRenderer spriteFlyLeft;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {   
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move){
            if (movement.x <= 0){
                SetDirection(spriteFlyLeft);
            } else {
                SetDirection(spriteFlyRight);
            }
        }
        if(P.activeInHierarchy == false){
            gameObject.SetActive(false);
        }
    }

    private void SetDirection(AnimatedSpriteRenderer spriteRenderer){
        spriteFlyLeft.enabled = spriteRenderer == spriteFlyLeft;
        spriteFlyRight.enabled = spriteRenderer == spriteFlyRight;

        activeSpriteRenderer = spriteRenderer;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag.Equals("Player") == true){
            //print("close");
            move = true;
        }
    }

    void OnCollisionEnter2D(Collision2D target){
        if( target.gameObject.tag.Equals("Projectile") == true ){
            HP--;
            //print("hit");
            if( HP <= 0 ){
                //print("Dead");
                sound = true;
                DeathSequence();
            }
        }
    }

    void FixedUpdate(){
        if(move){
            this.GetComponent<EnemyMovement>().enabled = false;
            this.GetComponent<EnemyMovement>().spriteRendererUp.enabled = false;
            this.GetComponent<EnemyMovement>().spriteRendererDown.enabled = false;
            this.GetComponent<EnemyMovement>().spriteRendererLeft.enabled = false;
            this.GetComponent<EnemyMovement>().spriteRendererRight.enabled = false;
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

        spriteFlyLeft.enabled = false;
        spriteFlyRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 0.5f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
    }
}
