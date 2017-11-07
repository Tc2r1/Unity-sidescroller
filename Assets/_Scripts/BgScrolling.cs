using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScrolling : MonoBehaviour{
	public float backgroundSize;

	// Scrolling Controls
	private float viewZone = 10;
	private Transform cameraTransform;
	private Transform[] layers;
	private int leftIndex;
	private int rightIndex;


	// Use this for initialization
	void Start (){

		cameraTransform = Camera.main.transform;
		layers = new Transform[transform.childCount];
		RectTransform childTransform = GetComponentInChildren<RectTransform> ();

		if (backgroundSize < 1){
			backgroundSize = (childTransform.rect.width * 10) * (childTransform.localScale.x / 10);
		}
		for (int i = 0; i < transform.childCount; i++){
			layers [i] = transform.GetChild (i);
		}

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}
	
	// Update is called once per frame
	void Update (){

		if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewZone)){
			ScrollLeft ();
		}

		if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone)){
			ScrollRight ();
		}
			
	}

	private void ScrollLeft (){
		int lastRight = rightIndex;
		layers [rightIndex].position = new Vector3 (1 * (layers [rightIndex].position.x - backgroundSize), transform.position.y, transform.position.z);
		//Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0){
			rightIndex = layers.Length - 1;
		}
	}

	private void ScrollRight (){

		int lastLeft = leftIndex;
		layers [leftIndex].position = new Vector3 (1 * (layers [rightIndex].position.x + backgroundSize), transform.position.y, transform.position.z);
		//Vector3.right * (layers [rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length){
			leftIndex = 0;
		}
		
	}
}
