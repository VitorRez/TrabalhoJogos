using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadeiraDeathSound : MonoBehaviour
{
    public GameObject DeathSound;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        DeathSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetComponent<EnemyMovement>().sound){
            playAudio();
        }
    }

    void playAudio(){
        DeathSound.SetActive(true);
        Invoke(nameof(stopAudio), 2f);
    }
    void stopAudio(){
        DeathSound.SetActive(false);
    }
}
