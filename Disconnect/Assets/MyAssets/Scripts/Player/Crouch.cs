using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour 
{
	[SerializeField] private CharacterController characterCollider;
	//[SerializeField] private float crouchHeight;

	void Start()
	{
		characterCollider = gameObject.GetComponent<CharacterController> ();
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.LeftControl)) {
			characterCollider.height = 0.1f;
		} else {
			characterCollider.height = 1.8f;
		}
	}

}
