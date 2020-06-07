using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MoveAlong : MonoBehaviour {

    //public Transform moveTransform;
    public Transform[] followTransforms;
    [Range(0.0f, 1.0f)]
    public float percentage;

    private int numPath;
    private float[] transPercent;
    private List<float> percentList;

	// Use this for initialization
	void Start () {
        if (followTransforms.Length > 0) {
            transform.position = followTransforms[0].position;
        }
        if (followTransforms.Length > 2) {
            GetDistancePercentages();
        }
	}
	
	// Update is called once per frame
	void Update () {
        MoveTransform();
    }

    void MoveTransform () {
        var numPath = SortCurrentPercentage();
        Debug.Log(numPath);
        var relPercent = (percentage - transPercent[numPath]) / (transPercent[numPath + 1] - transPercent[numPath]);
        transform.position = Vector3.Lerp(followTransforms[numPath].position, followTransforms[numPath + 1].position, relPercent);
    }

    int SortCurrentPercentage () {
        numPath = 0;
        for (int i = 0; i < transPercent.Length-1; i++) {
            if (percentage > transPercent[i] && percentage <= transPercent[i + 1])
                numPath = i;
        }
        return numPath;
    }

    void GetDistancePercentages() {
        percentList = new List<float>();
        float totalDistance = GetTotalDistance();
        //Debug. Log(totalDistance);
        float accPercent = 0;
        percentList.Add(accPercent);
        for (int i = 0; i < followTransforms.Length - 1; i++) {
            var distance = (followTransforms[i + 1].position - followTransforms[i].position).magnitude;
            var percent = distance / totalDistance;
            accPercent += percent;
            percentList.Add(accPercent);
            /*
            Debug.Log(distance);
            Debug.Log(percent);
            Debug.Log(accPercent);
            */
        }
        transPercent = percentList.ToArray();
        Debug.Log("Arreglo de porcentajes:");
        foreach (float percent in transPercent) {
            Debug.Log(percent);
        }
    }

    float GetTotalDistance() {
        float distance = 0;
        for (int i= 0; i < followTransforms.Length-1; i++) {
            distance += (followTransforms[i + 1].position - followTransforms[i].position).magnitude;
        }
        return distance;
    }
}
