using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class returnhome : MonoBehaviour {

    public GameObject scoreBox;
    public GameObject wordsBox;
    public GameObject studentBox;
    public GameObject imagebox;
    public Sprite fail;
    public Sprite bronze;
    public Sprite silver;
    public Sprite gold;

    public AudioSource failure;
    public AudioSource sucess;
    public AudioSource click1;
    public AudioSource click2;
    public AudioSource click3;
    public AudioSource click4;
    private bool isPlaying;

    private float time;

	// Use this for initialization
	void Start () {
        time = 4f;
        isPlaying = false;

    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("A Button") || Input.GetKeyDown(KeyCode.Space))&& time < 0)
        {
            SceneManager.LoadScene("Main Menu");
        }

        time -= Time.deltaTime;
        if (time < 0)
        {
            click1.Play();
            if (PlayerPrefs.GetInt("Score") < 100)
            {
                imagebox.GetComponent<Image>().sprite = fail;
            }
            else if (PlayerPrefs.GetInt("Score") < 200)
            {
                imagebox.GetComponent<Image>().sprite = bronze;
            }
            else if (PlayerPrefs.GetInt("Score") < 300)
            {
                imagebox.GetComponent<Image>().sprite = silver;
                
            }
            else if (PlayerPrefs.GetInt("Score") >= 300)
            {
                imagebox.GetComponent<Image>().sprite = gold;
            }
        }
        else if (time < 1)
        {
            click2.Play();
            scoreBox.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("Score");
        }
        else if (time < 2)
        {
            studentBox.GetComponent<Text>().text = " " + PlayerPrefs.GetInt("Students Missed");
            click3.Play();
            if (PlayerPrefs.GetInt("Score") < 200)
            {
                if (!isPlaying)
                {
                    failure.Play();
                    isPlaying = true;
                }
            }
            else if(PlayerPrefs.GetInt("Score") > 200)
            {
                if (!isPlaying)
                {
                    sucess.Play();
                    isPlaying = true;
                }
            }
        }
        else if (time <= 3)
        {
            click4.Play();
            wordsBox.GetComponent<Text>().text = " " + PlayerPrefs.GetInt("Words Missed");
        }  
        
    }
}
