using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPMadeira : MonoBehaviour
{
    private int HP;
    private int width = 450;
    private Collider2D collider;
    public GameObject HPBar;

    // Start is called before the first frame update
    void Start()
    {
        HP = this.GetComponent<EnemyMovement>().HP;
        collider = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag.Equals("Projectile") == true){
            width = width - 450/HP;
            HPBar.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 10);
        }
    }
}
