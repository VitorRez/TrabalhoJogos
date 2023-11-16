using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{

    public GameObject footstep;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<MovementController>().isWalking){
            Footsteps();
        }else{
            StopFootsteps();
        }
    }

    void Footsteps(){
        footstep.SetActive(true);
    }
    void StopFootsteps(){
        footstep.SetActive(false);
    }
}
