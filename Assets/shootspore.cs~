using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootspore : MonoBehaviour{

	public GameObject projectile;
	public float shootTime;
	public int fireChance;
	public Transform shootFrom;
	public GameObject fireEffect;


	float nextShootTime;
	Animator cannonAnim;

	// Use this for initialization
	void Start (){
		cannonAnim = GetComponentInChildren<Animator> ();
		nextShootTime = 0f;

		
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Player" && nextShootTime < Time.time){

			nextShootTime = Time.time + shootTime;

			if (Random.Range (0, 10) >= fireChance){
				Instantiate (projectile, shootFrom.position, Quaternion.identity);
				Instantiate (fireEffect, shootFrom.position, Quaternion.identity);
				cannonAnim.SetTrigger ("cannonFire");
			}
		}
	}
}
