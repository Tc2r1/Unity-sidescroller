using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformer : MonoBehaviour{

	// what camera is following.
	public Transform followTarget;
	public float smoothing;

	public Vector3 followOffset;

	// lowest point camera will go.
	private float lowY;

	// Use this for initialization
	void Start (){
		// get init distance from target.
		followOffset = transform.position - followTarget.position;
		lowY = transform.position.y;
		
	}


	void FixedUpdate (){
		if (followTarget == null){
			return;
		}
		Vector3 targetCamPos = followTarget.position + followOffset;

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

		if (transform.position.y < lowY){
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
		
	}
}
