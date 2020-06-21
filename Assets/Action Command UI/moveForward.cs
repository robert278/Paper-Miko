using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		transform.position += transform.TransformDirection (Vector3.up*0.2f);
    }
}
