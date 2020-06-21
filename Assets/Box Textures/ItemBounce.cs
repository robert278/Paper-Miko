using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBounce : MonoBehaviour
{
	[SerializeField]
	private GameObject item10;

	private float startlocation;

    // Start is called before the first frame update
    void Start()
    {
		gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(150, 300, 0));
		startlocation = gameObject.transform.position.y;
    }

	void OnCollisionEnter(Collision col){
		Collider other = col.collider;

		if(other.tag == "Enemy"){
			//item gets 'attached' to enemy's head as if they picked it up
		} else if(other.name == "Player"){
			//collect the item then destroy the gameObject
			if(item10.tag == "no item"){ 
				Destroy(gameObject);
			}
		}
	}

	void Update(){
		if(gameObject.transform.position.y < startlocation){
			gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity * 20);
		}
	}
}
