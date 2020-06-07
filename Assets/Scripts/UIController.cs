using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    public int gameState = 0;
    public GameObject TitlePanel;
    public GameObject TimerPanel;
    public GameObject HSPanel;
    public GameObject Environment;
    public AudioClip[] clips;

    private int oldState = -1;
    private AudioSource audioSrc;

    // Use this for initialization
    void Start () {
        gameState = 0;
        audioSrc = Environment.GetComponent<AudioSource>();
        audioSrc.clip = clips[gameState];
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update () {
        if ( gameState != oldState ) {
            if (gameState == 2)
                audioSrc.loop = false;
            else
                audioSrc.loop = true;
            audioSrc.clip = clips[gameState];
            audioSrc.Play();
            /*switch (gameState) {
                case 0:
                    
            }*/
            Debug.Log(gameState);
            oldState = gameState;
        }
        TitlePanel.SetActive(gameState == 0);
        TimerPanel.SetActive(gameState == 1 || gameState == 2 );
        HSPanel.SetActive(gameState == 2);
        
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
