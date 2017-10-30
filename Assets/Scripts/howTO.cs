using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class howTO : MonoBehaviour {
    private bool controlReady;
    private bool keyReady;

    public GameObject control;
    public GameObject key;

	// Use this for initialization
	void Start () {
        controlReady = false;
        keyReady = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("A Button"))
        {
            controlReady = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyReady = true;
        }
        if (controlReady == false)
        {
            control.GetComponent<Text>().text = "Press 'A' To Ready Up";
        }
        else
        {
            control.GetComponent<Text>().text = "Ready";
        }
        if(keyReady == false)
        {
            key.GetComponent<Text>().text = "Press 'Space' To Ready Up";
        }
        else
        {
            key.GetComponent<Text>().text = "Ready";
        }

        if(keyReady && controlReady)
        {
            SceneManager.LoadScene("ClassRoom");
        }
	}
}
