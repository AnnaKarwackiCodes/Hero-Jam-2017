using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TA : MonoBehaviour {
    
    private int speed;
    private int lastJoy;
    private int collisionJoy;
    private Animator animator;
    private bool isMoving;
	// Use this for initialization
	void Start () {
        speed = 5;
        collisionJoy = -1;
        animator = this.GetComponent<Animator>();
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        //KeyDebug();
        //checking for the two key combos
        if ((Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.UpArrow))) && collisionJoy != 4)
        {
            //animator.enabled = true;
            lastJoy = 4;
            animator.SetInteger("Direction", 2);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            isMoving = true;
        }
        //checking for the single key inputs
        if ((Input.GetAxis("Left Joy Right") == 1 || Input.GetKey(KeyCode.RightArrow)) && collisionJoy != 0)
        {
            //animator.enabled = true;
            lastJoy = 0;
            animator.SetInteger("Direction", 2);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            isMoving = true;
        }
        if((Input.GetAxis("Left Joy Right") == -1 || Input.GetKey(KeyCode.LeftArrow)) && collisionJoy != 1)
        {
            //animator.enabled = true;
            lastJoy = 1;
            animator.SetInteger("Direction", 3);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            isMoving = true;
        }
        if ((Input.GetAxis("Left Joy Up") == 1 || Input.GetKey(KeyCode.DownArrow)) && collisionJoy != 2)
        {
            //animator.enabled = true;
            lastJoy = 2;
            animator.SetInteger("Direction", 1);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            isMoving = true;
        }
        if ((Input.GetAxis("Left Joy Up") == -1 || Input.GetKey(KeyCode.UpArrow)) && collisionJoy != 3)
        {
            //animator.enabled = true;
            lastJoy = 3;
            animator.SetInteger("Direction", 0);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            isMoving = true;
        }
        if((Input.GetAxis("Left Joy Right") == 0 && Input.GetAxis("Left Joy Up") == 0) && (!Input.GetKey(KeyCode.UpArrow)&& !Input.GetKey(KeyCode.DownArrow)&& !Input.GetKey(KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.RightArrow)))
        {
            isMoving = false;
        }
        if (!isMoving)
        {
            //animator.enabled = false;
            
            if (animator.GetInteger("Direction") == 0)
            {
                animator.SetInteger("Direction", 4);
            }
            else if (animator.GetInteger("Direction") == 1)
            {
                animator.SetInteger("Direction", 5);
            }
            else if (animator.GetInteger("Direction") == 2)
            {
                animator.SetInteger("Direction", 6);
            }
            else if (animator.GetInteger("Direction") == 3)
            {
                animator.SetInteger("Direction", 7);
            }

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collide");
        collisionJoy = lastJoy;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        collisionJoy = -1;
    }
    public void KeyDebug()
    {
        Debug.Log("THIS ROUND");
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left");
        }
        
        if (Input.GetKey(KeyCode.UpArrow)&& Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("up and right");
        }
        
    }
}
