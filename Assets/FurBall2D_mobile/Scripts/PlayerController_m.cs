﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController_m : MonoBehaviour {
	
	public float maxSpeed = 6f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float verticalSpeed = 20;
	[HideInInspector]
	public bool lookingRight = true;
	bool doubleJump = false;
	public GameObject Boost;
//	private Animator cloudanim;
	public GameObject Cloud;
	private Rigidbody2D rb2d;
	private Animator anim;
	private bool isGrounded = false;
    private float speed_player = 0;

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		Cloud = GameObject.Find("Cloud");
	}
	

	void OnCollisionEnter2D(Collision2D collision2D) {
		
		if (collision2D.relativeVelocity.magnitude > 20){
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		}
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        if (CrossPlatformInputManager.GetButtonDown ("Jump") && (isGrounded || !doubleJump))
		{
			rb2d.AddForce(new Vector2(0,jumpForce));

			if (!doubleJump && !isGrounded)
			{
				doubleJump = true;
				Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
			//	cloudanim.Play("cloud");		
			}
		}



		if (CrossPlatformInputManager.GetButtonDown("Fire3") && !isGrounded)
		{
			rb2d.AddForce(new Vector2(0,-jumpForce));
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		}

	}


	void FixedUpdate()
	{
		if (isGrounded) 
			doubleJump = false;


        //		float hor = CrossPlatformInputManager.GetAxis ("Horizontal");
        speed_player += 0.5f * Time.deltaTime;
        if (speed_player > maxSpeed)
            speed_player = maxSpeed;

        anim.SetFloat ("Speed", Mathf.Abs (speed_player));

		rb2d.velocity = new Vector2 (speed_player * maxSpeed, rb2d.velocity.y);
		  
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((speed_player > 0 && !lookingRight)||(speed_player < 0 && lookingRight))
			Flip ();
		 
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}


	
	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

}
