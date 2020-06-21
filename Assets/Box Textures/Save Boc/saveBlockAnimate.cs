using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveBlockAnimate : MonoBehaviour
{
	[SerializeField]
	private Material f1;
	[SerializeField]
	private Material f2;
	[SerializeField]
	private Material f3;
	[SerializeField]
	private Material f4;
	[SerializeField]
	private Material f5;
	[SerializeField]
	private Material f6;
	[SerializeField]
	private Material f7;
	[SerializeField]
	private Material f8;
	[SerializeField]
	private Material f9;

	private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
		if(time % 9 == 0){
			gameObject.GetComponent<Renderer>().material = f1;
		} else if (time % 9 == 1){
			gameObject.GetComponent<Renderer>().material = f2;

		}else if (time % 9 == 2){
			gameObject.GetComponent<Renderer>().material = f3;

		}else if (time % 9 == 3){
			gameObject.GetComponent<Renderer>().material = f4;

		}else if (time % 9 == 4){
			gameObject.GetComponent<Renderer>().material = f5;

		}else if (time % 9 == 5){
			gameObject.GetComponent<Renderer>().material = f6;

		}else if (time % 9 == 6){
			gameObject.GetComponent<Renderer>().material = f7;

		}else if (time % 9 == 7){
			gameObject.GetComponent<Renderer>().material = f8;

		}else if (time % 9 == 8){
			gameObject.GetComponent<Renderer>().material = f9;

		}

		time += 0.125f;
    }
}
