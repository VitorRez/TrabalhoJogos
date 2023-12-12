using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] enemies;
    public GameObject door;
    public GameObject doorSound;

    void Start(){
        doorSound.SetActive(false);
    }

    void Update(){
        CheckWinState();
    }

    public void CheckWinState()
    {
        int aliveCount = 0;
        int enemieCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf) {
                aliveCount++;
            }
        }

        foreach (GameObject enemie in enemies)
        {
            if (enemie.activeSelf) {
                enemieCount++;
            }
        }

        if (aliveCount < 1) {
            Invoke(nameof(NewRound), 3f);
        }

        if (enemieCount == 0){
            doorSound.SetActive(true);
            door.SetActive(false);
        }

    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
