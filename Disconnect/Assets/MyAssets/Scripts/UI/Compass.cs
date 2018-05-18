using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour 
{
	[Header("Elements")]
	public RawImage compassImg;
	public Transform player;
	public Text compassDirectionText;

	void Update()
	{
		// Get a handle on the img uvRect
		compassImg.uvRect = new Rect (player.localEulerAngles.y / 360, 0, 1, 1);

		// Get a copy of your forward vector
		Vector3 forward = player.transform.forward;
		// Zero out the y component of your vector to only ger the direction in the X, Z plane
		forward.y = 0;

		// Clamp the angles to 5 degree increments
		float headingAngle = Quaternion.LookRotation (forward).eulerAngles.y;
		headingAngle = 5 * (Mathf.RoundToInt (headingAngle / 5.0f));

		// Convert the flot to an int for the switch statement
		int displayAngle;
		displayAngle = Mathf.RoundToInt (headingAngle);

		// Set the text of the Compass Degree Text to the clamped value, but change it to the letter if it is a true direction
		switch (displayAngle) 
		{
		case 0:
			//Do this
			compassDirectionText.text = "N";
			break;
		case 360:
			//Do this
			compassDirectionText.text = "N";
			break;
		case 45:
			//Do this
			compassDirectionText.text = "NE";
			break;
		case 90:
			//Do this
			compassDirectionText.text = "E";
			break;
		case 130:
			//Do this
			compassDirectionText.text = "SE";
			break;
		case 180:
			//Do this
			compassDirectionText.text = "S";
			break;
		case 225:
			//Do this
			compassDirectionText.text = "SW";
			break;
		case 270:
			//Do this
			compassDirectionText.text = "W";
			break;
		default:
			compassDirectionText.text = headingAngle.ToString ();
			break;
		}
	}
}
