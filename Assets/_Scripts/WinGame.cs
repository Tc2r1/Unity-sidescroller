using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour{

	public AudioClip victorySFX;

	private AudioSource myAS;

	// Use this for initialization
	void Start (){
		myAS = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){
			other.gameObject.GetComponent<PlayerHealth> ().winGame ();
			if (myAS != null){
				if (myAS.clip != null){
					myAS.volume = 1;
					myAS.Play ();
				}
			}
		}
	}
}
