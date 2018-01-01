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
        Debug.Log(animator.GetInteger("Direction"));
        if((Input.GetAxis("Left Joy Right") == 1 || Input.GetKey(KeyCode.RightArrow)) && collisionJoy != 0 )//&&transform.position.x < 8.5)
        {
            //animator.enabled = true;
            lastJoy = 0;
            animator.SetInteger("Direction", 2);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            isMoving = true;
        }
        if((Input.GetAxis("Left Joy Right") == -1 || Input.GetKey(KeyCode.LeftArrow)) && collisionJoy != 1 )//&& transform.position.x > -9)
        {
            //animator.enabled = true;
            lastJoy = 1;
            animator.SetInteger("Direction", 3);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            isMoving = true;
        }
        if ((Input.GetAxis("Left Joy Up") == 1 || Input.GetKey(KeyCode.DownArrow)) && collisionJoy != 2 )//&& transform.position.y > -.5)
        {
            //animator.enabled = true;
            lastJoy = 2;
            animator.SetInteger("Direction", 1);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            isMoving = true;
        }
        if ((Input.GetAxis("Left Joy Up") == -1 || Input.GetKey(KeyCode.UpArrow)) && collisionJoy != 3 )//&& transform.position.y < 7)
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
        //Debug.Log("collisde");
        //collisionJoy = lastJoy;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        //collisionJoy = -1;
    }

}
