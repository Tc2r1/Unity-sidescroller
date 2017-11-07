using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour{

	public float rocketSpeed;

	private Rigidbody2D rigBody;

	// Use this for initialization
	void Start (){
		rigBody = GetComponent<Rigidbody2D> ();


		Debug.Log (transform.rotation.z);

		if (transform.localRotation.z > 0){
			// Use Impulse force to fire projectile
			rigBody.AddForce (new Vector2 (-1, .01f) * rocketSpeed, ForceMode2D.Impulse);
		
		} else{
			// Use Impulse force to fire projectile
			rigBody.AddForce (new Vector2 (1, .01f) * rocketSpeed, ForceMode2D.Impulse);
		
		}
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	// stops the gameobject completely
	public void removeForce (){
		rigBody.velocity = new Vector2 (0, 0);
	}
}
