using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePartnerBox : MonoBehaviour
{
		[SerializeField]
		private Material f1;
		[SerializeField]
		private Material f2;
		[SerializeField]
		private Material f3;
		[SerializeField]
		private Material f4;

		private float time = 0.0f;

		// Update is called once per frame
		void Update()
		{
			if(time % 4 == 0){
				gameObject.GetComponent<Renderer>().material = f1;
			} else if (time % 4 == 1){
				gameObject.GetComponent<Renderer>().material = f2;

			}else if (time % 4 == 2){
				gameObject.GetComponent<Renderer>().material = f3;

			}else if (time % 4 == 3){
				gameObject.GetComponent<Renderer>().material = f4;

			}

			time += 0.125f;
		}
}
