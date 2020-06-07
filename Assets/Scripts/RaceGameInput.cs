using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaceGameInput : MonoBehaviour {

    public float addedPercent;
    public float time;
    public Text timeText;

    private GameObject player;
    private bool leftKeyPressed = false;
    private bool timerRunning = false;
    private bool finished = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        CheckKeys();
        if (timerRunning) {
            UpdateTimer();
            CheckComplete();
        }
    }

    void CheckComplete () {
        if (player.GetComponent<MoveAlong>().percentage >= 0.93f) {
            timerRunning = false;
            finished = true;
            Debug.Log("Finished!");
            GetComponent<AddHS>().CheckFinalScore();
            GetComponent<UIController>().gameState = 2;
        }
    }

    void CheckKeys () {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            StartTimer();
            leftKeyPressed = true;
        }
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && leftKeyPressed) {
            StartTimer();
            leftKeyPressed = false;
            player.GetComponent<MoveAlong>().percentage += addedPercent;
        }
    }

    public void StartTimer () {
        if (!timerRunning && !finished) {
            timerRunning = true;
            GetComponent<UIController>().gameState = 1;
        }
    }

    void UpdateTimer() {
        time += Time.deltaTime;
        //Debug.Log(time);
        int minutes = Mathf.FloorToInt(time / 60.0f);
        int seconds = Mathf.FloorToInt(time - minutes * 60.0f);
        int cents = Mathf.FloorToInt((time - (minutes*60+seconds))*100);
        timeText.text = minutes.ToString("00") + " : " + seconds.ToString("00") + " : " + cents.ToString("00");
    }
}
