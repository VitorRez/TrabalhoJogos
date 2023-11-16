using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{   
    public int HP = 10;
    private new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;
    public bool isWalking = false;

    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

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

    private void Update()
    {   
        if (Input.GetKey(inputUp) && Input.GetKey(inputLeft)) {
            isWalking = true;
            SetDirection(Vector2.up + Vector2.left, spriteRendererUp);
        } else if (Input.GetKey(inputUp) && Input.GetKey(inputRight)) {
            isWalking = true;
            SetDirection(Vector2.up + Vector2.right, spriteRendererUp);
        } else if (Input.GetKey(inputDown) && Input.GetKey(inputRight)) {
            isWalking = true;
            SetDirection(Vector2.down + Vector2.right, spriteRendererDown);
        } else if (Input.GetKey(inputDown) && Input.GetKey(inputLeft)) {
            isWalking = true;
            SetDirection(Vector2.down + Vector2.left, spriteRendererDown);
        } else if (Input.GetKey(inputUp)) {
            isWalking = true;
            SetDirection(Vector2.up, spriteRendererUp);
        } else if (Input.GetKey(inputDown)) {
            isWalking = true;
            SetDirection(Vector2.down, spriteRendererDown);
        } else if (Input.GetKey(inputLeft)) {
            isWalking = true;
            SetDirection(Vector2.left, spriteRendererLeft);
        } else if (Input.GetKey(inputRight)) {
            isWalking = true;
            SetDirection(Vector2.right, spriteRendererRight);
        } else if (Input.GetKey(inputUp)) {
            isWalking = true;
            SetDirection(Vector2.right, spriteRendererRight);
        } else {
            isWalking = false;
            SetDirection(Vector2.zero, activeSpriteRenderer);
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
        //FindObjectOfType<GameManager>().CheckWinState();
    }

}
