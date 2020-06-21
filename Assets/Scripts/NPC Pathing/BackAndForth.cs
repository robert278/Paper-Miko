using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
	[SerializeField]
	private float cycleTime; //pause between toggles
	[SerializeField]
	private float timerDelay;

	[SerializeField]
	private string typeOfMovement;

	private float timer = 0.0f;
	bool toggle = true;

	void Start(){
		timer += timerDelay;
	}

    // Update is called once per frame
    void Update()
    {
		if(timer >= cycleTime){
			toggle = !toggle;
			timer = 0;
		} else {
			timer += Time.deltaTime;
		}

		//If not paused!
		if(Time.timeScale != 0f){
			if(typeOfMovement == "beatBlockSprite"){ //can be used for platforms 'stepping to the beat' or NPCs 'flipping' to the beat
				if(toggle == false){
					gameObject.GetComponent<SpriteRenderer>().enabled = false;
					//gameObject.GetComponent<Rigidbody>().useGravity = false;
					gameObject.GetComponent<BoxCollider>().enabled = false;
				} else {
					gameObject.GetComponent<SpriteRenderer>().enabled = true;
					//gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject.GetComponent<BoxCollider>().enabled = true;
				}
			}

			if(typeOfMovement == "beatBlockMesh"){ //can be used for platforms 'stepping to the beat' or NPCs 'flipping' to the beat
				if(toggle == false){
					gameObject.GetComponent<MeshRenderer>().enabled = false;
					//gameObject.GetComponent<Rigidbody>().useGravity = false;
					gameObject.GetComponent<BoxCollider>().enabled = false;
				} else {
					gameObject.GetComponent<MeshRenderer>().enabled = true;
					//gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject.GetComponent<BoxCollider>().enabled = true;
				}
			}

			if(typeOfMovement == "LeftRight"){ //can be used for platforms and NPCs
				if(toggle == false){
					transform.position += new Vector3(0.05f,0,0);
				} else {
					transform.position += new Vector3(-0.05f,0,0);
				}
			}

			if(typeOfMovement == "ForwardBackwards"){ //can be used for platforms and NPCs
				if(toggle == false){
					transform.position += new Vector3(0,0,0.05f);
				} else {
					transform.position += new Vector3(0,0,-0.05f);
				}
			}
				
		}	
	}

}
