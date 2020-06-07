using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HSController : MonoBehaviour {
    public string addScoreURL = "http://localhost/bike_scores/addscore.php?"; //be sure to add a ? to your url
    public string highscoreURL = "http://localhost/bike_scores/display.php";

    public Text HSText;

    private float maxScore;


    void Start() {
        StartCoroutine(GetScores());
        StartCoroutine(LoadMaxScore());
    }

    // remember to use StartCoroutine when calling this function!
    public IEnumerator PostScores(string name, float score) {
        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        Debug.Log(post_url);
        yield return hs_post; // Wait until the download is done
        Debug.Log(hs_post);
        if (hs_post.error != null) {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    public IEnumerator GetScores() {
        HSText.text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null) {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else {
            HSText.text = hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
    public float GetMaxScore() {
        StartCoroutine(LoadMaxScore());
        Debug.Log(maxScore);
        return maxScore;
    }

    IEnumerator LoadMaxScore() {
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null) {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else {
            var maxIndex = hs_get.text.IndexOf("MAX:") + 4;
            float maxTime;
            float.TryParse(hs_get.text.Substring(maxIndex), out maxTime);
            Debug.Log(maxTime);
            maxScore = maxTime;
        }
    }
}