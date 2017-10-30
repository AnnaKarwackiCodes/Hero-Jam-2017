using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingStuff : MonoBehaviour {

    public string[] easyWords;
    public GameObject[] display;
    public GameObject input;
    public GameObject scoreBox;

    private string wordTyping;
    private string typeWord;
    private int curLetterPos;
    private float time;
    private int score;
    private string[] wordQueue;
    private int[] multiplier;
    private int wordsMissed;
    private int studentsMissed;
    // Use this for initialization
    void Start () {
        wordQueue = new string[5];
        multiplier = new int[5];
        for(int i = 0; i < 5; i++)
        {
            wordQueue[i] = SelectWord();
            multiplier[i] = 1;
        }
        curLetterPos = 0;
        time = 4f;
        score = 0;
        wordsMissed = 0;
        studentsMissed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ReadKeyInput();

        if(wordQueue[0] != "")
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 4f;
                curLetterPos = 0;
                wordTyping = "";
                score -= 5;
                wordsMissed++;
                ShiftArray();
            }
        }
        for (int i = 0; i < 5; i++) {
            if(multiplier[i] > 1)
            {
                display[i].GetComponent<Text>().color = Color.green;
            }
            else
            {
                display[i].GetComponent<Text>().color = Color.black;
            }
            display[i].GetComponent<Text>().text = wordQueue[i];
        }
        //QueueAddTest();
    }

    void ReadKeyInput()
    {
        if(curLetterPos < wordQueue[0].Length)
        {
            if (Input.GetKeyDown(KeyCode.A) && wordQueue[0][curLetterPos] == 'A')
            {
                wordTyping += "A";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.B) && wordQueue[0][curLetterPos] == 'B')
            {
                wordTyping += "B";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.C) && wordQueue[0][curLetterPos] == 'C')
            {
                wordTyping += "C";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.D) && wordQueue[0][curLetterPos] == 'D')
            {
                wordTyping += "D";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.E) && wordQueue[0][curLetterPos] == 'E')
            {
                wordTyping += "E";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.F) && wordQueue[0][curLetterPos] == 'F')
            {
                wordTyping += "F";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.G) && wordQueue[0][curLetterPos] == 'G')
            {
                wordTyping += "G";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.H) && wordQueue[0][curLetterPos] == 'H')
            {
                wordTyping += "H";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.I) && wordQueue[0][curLetterPos] == 'I')
            {
                wordTyping += "I";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.J) && wordQueue[0][curLetterPos] == 'J')
            {
                wordTyping += "J";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.K) && wordQueue[0][curLetterPos] == 'K')
            {
                wordTyping += "K";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.L) && wordQueue[0][curLetterPos] == 'L')
            {
                wordTyping += "L";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.M) && wordQueue[0][curLetterPos] == 'M')
            {
                wordTyping += "M";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.N) && wordQueue[0][curLetterPos] == 'N')
            {
                wordTyping += "N";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.O) && wordQueue[0][curLetterPos] == 'O')
            {
                wordTyping += "O";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.P) && wordQueue[0][curLetterPos] == 'P')
            {
                wordTyping += "P";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.Q) && wordQueue[0][curLetterPos] == 'Q')
            {
                wordTyping += "Q";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.R) && wordQueue[0][curLetterPos] == 'R')
            {
                wordTyping += "R";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.S) && wordQueue[0][curLetterPos] == 'S')
            {
                wordTyping += "S";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.T) && wordQueue[0][curLetterPos] == 'T')
            {
                wordTyping += "T";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.U) && wordQueue[0][curLetterPos] == 'U')
            {
                wordTyping += "U";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.V) && wordQueue[0][curLetterPos] == 'V')
            {
                wordTyping += "V";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.W) && wordQueue[0][curLetterPos] == 'W')
            {
                wordTyping += "W";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.X) && wordQueue[0][curLetterPos] == 'X')
            {
                wordTyping += "X";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.Y) && wordQueue[0][curLetterPos] == 'Y')
            {
                wordTyping += "Y";
                curLetterPos++;
            }
            else if (Input.GetKeyDown(KeyCode.Z) && wordQueue[0][curLetterPos] == 'Z')
            {
                wordTyping += "Z";
                curLetterPos++;
            }
        }
        input.GetComponent<Text>().text = wordTyping;
        scoreBox.GetComponent<Text>().text = "Score: " + score;
        if (curLetterPos >= wordQueue[0].Length && Input.GetKeyDown(KeyCode.Space))
        {
            //enter word
            score += 10 * multiplier[0];
            curLetterPos = 0;
            wordTyping = "";
            time = 4f;
            ShiftArray();
        }
        
    }

    string SelectWord()
    {
        //pick a word
         return easyWords[Random.Range(15, easyWords.Length - 1)];
    }

    void ShiftArray()
    {
        for(int i = 0; i < 4; i++)
        {
            wordQueue[i] = wordQueue[i + 1];
            multiplier[i] = multiplier[i + 1];
        }
        wordQueue[4] = "";
    }
    public string pickWord() {
        return SelectWord();
    }
    public string AddToQueue(string temp)
    {
        //if (Input.GetKeyDown(KeyCode.Return)
        //string temp = "";
        bool found = false;
        //check to see if the word is already in the array
        //temp = SelectWord();
        for (int i = 0; i < 5; i++)
        {
            //if it is increase the multiplier for that word
            if (wordQueue[i] == temp)
            {
                multiplier[i] += 2;
                found = true;
                break;
            }
        }
        //if not at it to the end of the list
        if (!found)
        {
            for (int i = 0; i < 5; i++)
            {
                if (wordQueue[i] == "")
                {
                    wordQueue[i] = temp;
                    multiplier[i] = 1;
                    break;
                }
            }
        }
        return temp;
    }

    public int Score
    {
        get { return score; }
    }
    public int WordsMissed
    {
        get { return wordsMissed; }
    }
    public int StudentsMissed
    {
        get { return studentsMissed; }
        set { studentsMissed = value; }
    }
}
