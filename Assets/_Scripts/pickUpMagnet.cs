using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpMagnet : MonoBehaviour{

	public GameObject target;
	public float speed;

	Transform pickUp;
	Transform targetTransform;
	bool magnet = false;

	// Use this for initialization
	void Start (){
		pickUp = GetComponentInChildren<Transform> ();

		if (target == null){
			target = GameObject.FindGameObjectWithTag ("Player");
		}
		targetTransform = target.GetComponent<Transform> ();
		
		
	}
	
	// Update is called once per frame
	void Update (){

		if (pickUp != null && magnet == true){
			pickUp.position = Vector2.MoveTowards (pickUp.position, targetTransform.position, speed * Time.deltaTime);
		}				
	}

	// when player enters range, pickup goes toward player.
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){
			magnet = true;
		}
	}
}
