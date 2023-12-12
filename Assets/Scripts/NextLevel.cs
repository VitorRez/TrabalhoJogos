using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{   
    public int nextscene = 0;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag.Equals("Player") == true){
            SceneManager.LoadSceneAsync(nextscene);
        }
    }
}
