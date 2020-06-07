using UnityEngine;
using System.Collections;

public class AddHS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckFinalScore () {
        if (GetComponent<RaceGameInput>().time < GetComponent<HSController>().GetMaxScore()) {
            Debug.Log("Ready to post!");
            StartCoroutine(GetComponent<HSController>().PostScores("YOU", GetComponent<RaceGameInput>().time));
            StartCoroutine(GetComponent<HSController>().GetScores());
        }
    }
}
