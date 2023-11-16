using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDirection : MonoBehaviour
{   

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode trigger = KeyCode.Mouse2;
    private KeyCode lastUsedKey;
    private Vector2 lastVector2;
    private float lastRotate;
    public Transform player;
    public GameObject projectilePrefab;
    public float bulletSpeed = 20f;

    private void Awake(){
        lastUsedKey = inputRight;
        lastVector2 = Vector2.right;
        lastRotate = -90;
    } 

    void Update()
    {
        if (Input.GetKey(inputUp)){
            lastUsedKey = inputUp;
            lastVector2 = Vector2.up;
            lastRotate = 0;
            shoot();//0
        } else if (Input.GetKey(inputDown)){
            lastUsedKey = inputDown;
            lastVector2 = Vector2.down;
            lastRotate = 180;
            shoot();//180
        } else if (Input.GetKey(inputLeft)){
            lastUsedKey = inputLeft;
            lastVector2 = Vector2.left;
            lastRotate = 90;
            shoot();//90
        } else if (Input.GetKey(inputRight)){
            lastUsedKey = inputRight;
            lastVector2 = Vector2.right;
            lastRotate = -90;
            shoot();//90
        } else {
            shoot();
        }
    }

    void shoot(){
        if(Input.GetKeyDown(trigger)){
            GameObject projectile = Instantiate(projectilePrefab, player.position, Quaternion.Euler(0, 0, lastRotate));
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(lastVector2 * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
