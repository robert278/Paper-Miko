using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAlcoholismIcon : MonoBehaviour
{

	[SerializeField]
	private GameObject a1;

	[SerializeField]
	private GameObject a2;

	private float targetTime = 0.45f;

    // Update is called once per frame
    void Update()
    {
		targetTime -= Time.deltaTime;
		if(targetTime <= 0.0f){
			targetTime = 0.45f;
			if(a1.activeSelf){
				a1.SetActive(false);
				a2.SetActive(true);

			} else if(a2.activeSelf){
				a1.SetActive(true);
				a2.SetActive(false);

			}
		}

    }
}
