using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour{

	public float healthAmount;
	public AudioClip pickUpSFX;

	// Use this for initialization
	void Start (){
		
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){
			PlayerHealth theHealth = other.gameObject.GetComponent<PlayerHealth> ();
			if (pickUpSFX != null){
				AudioSource.PlayClipAtPoint (pickUpSFX, transform.position);
			}
				
			theHealth.addHealth (healthAmount);
			Destroy (gameObject);
			Destroy (transform.parent.gameObject);
		}
	}

}
