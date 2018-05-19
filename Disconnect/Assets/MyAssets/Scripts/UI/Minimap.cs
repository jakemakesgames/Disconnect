using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour 
{
	public Transform player;

	float storedShadowDistance;

	void LateUpdate()
	{
		// Have the Minimap Camera follow the player
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;

		// Have the Minimap Camera rotate with the player
		transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
	}

	void OnPreRender()
	{
		storedShadowDistance = QualitySettings.shadowDistance;
		QualitySettings.shadowDistance = 0;
	}

	void OnPostRender()
	{
		QualitySettings.shadowDistance = storedShadowDistance;
	}
}
