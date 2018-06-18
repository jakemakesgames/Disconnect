using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EndGame : MonoBehaviour 
{
	public GameObject platform;
	public float speed;
	public Transform endPoint;

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			platform.GetComponent<Rigidbody> ();

			other.GetComponent<FirstPersonController> ().enabled = false;

			float moveSpd = speed * Time.deltaTime;
			platform.transform.position = Vector3.MoveTowards (platform.transform.position, endPoint.position, moveSpd);
		}
	}
}
