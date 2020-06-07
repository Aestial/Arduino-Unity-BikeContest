using UnityEngine;
using System.IO.Ports;

public class ArduinoRead : MonoBehaviour {

    public float addedPercent = 0.01f;
    private GameObject player;
    private SerialPort stream = new SerialPort("COM9", 115200);
    
    // Use this for initialization
    void Start() {
        stream.Open();
        stream.ReadTimeout = 5;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (stream.IsOpen) {
            try {
                string value = stream.ReadLine();
                if (value.Length > 0) {
                    Debug.Log("Valor Recibido:");
                    Debug.Log(value);
                    GetComponent<RaceGameInput>().StartTimer();
                    player.GetComponent<MoveAlong>().percentage += addedPercent;
                }
            }
            catch {
                Debug.Log("No se lee valor (buffer vacio)");
            }
        }
    }

}
