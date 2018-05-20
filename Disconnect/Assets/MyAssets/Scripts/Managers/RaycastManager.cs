using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour 
{
	private GameObject raycastedObj;

	[Header("Raycast Settings")]
	[SerializeField] private float rayLength = 10;
	[SerializeField] private LayerMask newLayerMask;

	[Header("References")]
	[SerializeField] private Image reticle;
	[SerializeField] private Text itemNameText;
	[SerializeField] private SurvivorTraits survivorTraits;

	void Start()
	{
		survivorTraits = GameObject.FindObjectOfType<SurvivorTraits> ();
	}


	void Update()
	{
		// Cast a raycast out forward from the player
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		// Check what the raycast hits
		if (Physics.Raycast (transform.position, fwd, out hit, rayLength, newLayerMask.value)) {
			if (hit.collider.CompareTag ("Consumable")) 
			{
				ReticleActive ();
				raycastedObj = hit.collider.gameObject;

				// Update the UI name
				itemNameText.text = raycastedObj.GetComponent<ItemProperties>().itemName;

				if (Input.GetMouseButtonDown (0)) 
				{
					// Select OBJ properties
					raycastedObj.GetComponent<ItemProperties>().Interaction(survivorTraits);
					//Destroy (raycastedObj);
				}

				if (Input.GetMouseButtonDown (1)) 
				{
					// Pickup Function
					raycastedObj.GetComponent<ItemProperties>().PickUp();
				}
			}
		} 
		else 
		{
			// Update the UI name
			ReticleNormal ();
			itemNameText.text = null;
		}

	}

	void ReticleActive()
	{
		// Sets the reticle colour to Green
		reticle.color = Color.green;
	}

	void ReticleNormal()
	{
		// Sets the reticle crosshair to White
		reticle.color = Color.white;
	}

}
