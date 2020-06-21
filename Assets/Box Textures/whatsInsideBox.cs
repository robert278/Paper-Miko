using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whatsInsideBox : MonoBehaviour
{
    [SerializeField]
	private GameObject insideTheBox;
	[SerializeField]
	private GameObject theBox;
	[SerializeField]
	private Material emptyBox;

	void OnTriggerEnter(Collider other){
		if(other.name == "Player"){
			if(insideTheBox != null){
				if(insideTheBox.name != "null (there was nothing inside the box)"){
					insideTheBox.SetActive(true);
					theBox.GetComponent<Renderer>().material = emptyBox;
				}

				gameObject.transform.position += new Vector3(0.0f, 0.1f, 0.0f);
				StartCoroutine(Waiting(0.125f));
			}
		}
	}

	IEnumerator Waiting(float time){
		yield return new WaitForSeconds(time);
		gameObject.transform.position += new Vector3(0.0f, -0.1f, 0.0f);
	}

}
