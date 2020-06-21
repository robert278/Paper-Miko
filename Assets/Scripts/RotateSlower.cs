using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlower : MonoBehaviour
{
	private Vector3 originalPosition;

	void Start(){
		originalPosition = gameObject.transform.localScale;	
	}

	void OnEnable(){
		if(originalPosition != Vector3.zero){
		print("BAttle Transition");
		gameObject.transform.localScale = originalPosition;
		}
	}

    // Update is called once per frame
    void Update()
    {
		transform.Rotate (new Vector3 (0, 0, 150) * Time.deltaTime);

		if(gameObject.transform.localScale.x > 0.06870736){
			gameObject.transform.localScale *= 0.95f;
		}
    }
}
