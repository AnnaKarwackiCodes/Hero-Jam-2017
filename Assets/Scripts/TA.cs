using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TA : MonoBehaviour {
    
    private int speed;
    private int lastJoy;
    private int collisionJoy;
    private Animator animator;
	// Use this for initialization
	void Start () {
        speed = 5;
        collisionJoy = -1;
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        if(Input.GetAxis("Left Joy Right") == 1 && collisionJoy != 0 &&transform.position.x < 8.5)
        {
            animator.enabled = true;
            lastJoy = 0;
            animator.SetInteger("Direction", 2);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(Input.GetAxis("Left Joy Right") == -1 && collisionJoy != 1 && transform.position.x > -9)
        {
            animator.enabled = true;
            lastJoy = 1;
            animator.SetInteger("Direction", 3);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Left Joy Up") == 1 && collisionJoy != 2 && transform.position.y > -.5)
        {
            animator.enabled = true;
            lastJoy = 2;
            animator.SetInteger("Direction", 1);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Left Joy Up") == -1 && collisionJoy != 3 && transform.position.y < 7)
        {
            animator.enabled = true;
            lastJoy = 3;
            animator.SetInteger("Direction", 0);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            animator.enabled = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collisde");
        collisionJoy = lastJoy;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        collisionJoy = -1;
    }

}
