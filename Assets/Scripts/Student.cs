using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Student : MonoBehaviour {
    public GameObject ta;
    public GameObject question;
    public Sprite questionYELL;
    public Sprite questionORG;
    public Sprite questionRED;
    public Sprite turn;
    public Sprite forward;
    public GameObject studentWord;
    //public Vector3 bubbleLoc;

    private bool hasQuestion;
    private float time;
    private GameObject q;
    private bool created;
    private bool wordCreate;
    private GameObject word;
    private GameObject can;
    private string myWord;
    private GameObject wordTyping;
    private string newWord;
    private string ShowWord;

	// Use this for initialization
	void Start () {
        hasQuestion = false;
        time = 5f;
        created = false;
        wordCreate = false;
        can = GameObject.Find("Canvas");
        wordTyping = GameObject.Find("Typing Stuff");
	}
	
	// Update is called once per frame
	void Update () {
        WithInRange();
        if(hasQuestion == false)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                if (Random.Range(0, 5) == 3)
                {
                    hasQuestion = true;
                    GetComponent<SpriteRenderer>().sprite = turn;
                }
                time = Random.Range(3, 7);
            }
            if(wordCreate && time < 2)
            {
                DestroyWord();
            }
        }
        else
        {
            QuestionTime();
            time -= Time.deltaTime;
            if (time < 0)
            {
                wordTyping.GetComponent<TypingStuff>().StudentsMissed++;
                GetComponent<SpriteRenderer>().sprite = forward;
                DestroyQuestion();
            }
            else if (time < 4)
            {
                q.GetComponent<Image>().sprite = questionRED;
            }
            else if (time < 7)
            {
                q.GetComponent<Image>().sprite = questionORG;
            }   
        }
	}
    void WithInRange()
    {
        float distance = Mathf.Pow(ta.transform.position.x - transform.position.x, 2) + Mathf.Pow(ta.transform.position.y - transform.position.y, 2);
        distance = Mathf.Sqrt(distance);

        if(distance < 2f && hasQuestion)
        {
            if (Input.GetButtonDown("A Button"))
            {
                DestroyQuestion();
                newWord = wordTyping.GetComponent<TypingStuff>().AddToQueue(ShowWord);
                showNewWord(newWord);
                GetComponent<SpriteRenderer>().sprite = forward;
            }
        }
    }

    void QuestionTime()
    {
        if (!created)
        {
            ShowWord = wordTyping.GetComponent<TypingStuff>().pickWord();
            //q = Instantiate(question, new Vector3(transform.position.x, transform.position.y + 1.5f, 0), new Quaternion(0, 0, 0, 0), can.transform);
            Vector3 bubbleLoc = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1.5f, 0));
            q = Instantiate(question, bubbleLoc, new Quaternion(0, 0, 0, 0), can.transform);
            q.transform.GetChild(0).GetComponent<Text>().text = ShowWord + "?";
            q.GetComponent<Image>().sprite = questionYELL;
            created = true;
            time = 10f;
        }
    }
    void DestroyQuestion()
    {
        Destroy(q, 0);
        created = false;
        hasQuestion = false;
    }
    void showNewWord(string myword)
    {
        if(wordCreate == false)
        {
            //word = Instantiate(studentWord, new Vector3(transform.position.x, transform.position.y + 2f, 0), new Quaternion(0, 0, 0, 0), can.transform);
            Vector3 bubbleLoc = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1.5f, 0));
            word = Instantiate(studentWord, bubbleLoc, new Quaternion(0, 0, 0, 0), can.transform);
            word.transform.GetChild(0).GetComponent<Text>().text = ShowWord + "!";
            wordCreate = true;
            
            time = 3;
        }
    }
    void DestroyWord()
    {
        Destroy(word, 0);
        wordCreate = false;
    }
}
