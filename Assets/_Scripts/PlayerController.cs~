using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour{

	// Movement Variables
	public float maxSpeed;

	// Jumping Variables
	private bool grounded = false;
	private float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
	public AudioClip jumpSFX;


	private Rigidbody2D myRigidbody;
	private Animator myAnim;
	private AudioSource myAudioSource;
	private Vector3 theScale;
	private bool facingRight;

	// Projectile Firing
	public Transform barrelTip;
	public GameObject bullet;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start (){

		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		myAudioSource = GetComponent<AudioSource> ();
		facingRight = true;

	}

	// Update is called once per frame
	void Update (){

		if (grounded && Input.GetButtonDown ("Jump")){
			if (myRigidbody.velocity.y < 1){
				grounded = false;
				myAnim.SetBool ("isGrounded", grounded);
				myRigidbody.AddForce (new Vector2 (0, jumpHeight));


				myAudioSource.volume = .7f;
				myAudioSource.PlayOneShot (jumpSFX);

			}
		}

		if (Input.GetAxisRaw ("Fire1") > 0){
			fireRocket ();
		}
	}

	void fireRocket (){
		// check if we can fire. 
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;

			// Check direction player is facing to fire projectile
			if (facingRight){
				Instantiate (bullet, barrelTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else{
				Instantiate (bullet, barrelTip.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		}
	}

	// Fixed update is called exactly at the same time
	void FixedUpdate (){

		// check if we are grounded, if no we are falling.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool ("isGrounded", grounded);

		myAnim.SetFloat ("verticalSpeed", myRigidbody.velocity.y);


		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		myRigidbody.velocity = new Vector2 (
			move * maxSpeed,
			myRigidbody.velocity.y);

		if (move > 0 && !facingRight){
			flip ();

		} else if (move < 0 && facingRight){
			flip ();

		}
	}

	void flip (){
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
