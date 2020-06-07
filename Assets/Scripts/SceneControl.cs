using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextScene() {
        SceneManager.LoadScene(1);
    }

    public void CloseApp () {
        Application.Quit();
    }
}
