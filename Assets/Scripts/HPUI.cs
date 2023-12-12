using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{  
    public GameObject Player;
    private int PlayerHP;
    private float width = 190;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = Player.GetComponent<MovementController>().HP;
    }

    // Update is called once per frame
    void Update()
    {   
        PlayerHP = Player.GetComponent<MovementController>().HP;
        print(PlayerHP);
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 10);
    }
}
