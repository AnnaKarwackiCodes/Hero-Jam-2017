using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class myTime : MonoBehaviour {
    private float time;
    public GameObject Box;
    public GameObject Type;     
	// Use this for initialization
	void Start () {
        time = 60f;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        Box.GetComponent<Text>().text = "Time: " + Mathf.RoundToInt(time);
        if(time < 0)
        {
            PlayerPrefs.SetInt("Score", Type.GetComponent<TypingStuff>().Score);
            PlayerPrefs.SetInt("Words Missed", Type.GetComponent<TypingStuff>().WordsMissed);
            PlayerPrefs.SetInt("Students Missed", Type.GetComponent<TypingStuff>().StudentsMissed);
            SceneManager.LoadScene("GameOver");
        }
	}
}
