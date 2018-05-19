using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DisableManager : MonoBehaviour 
{
	[SerializeField] private FirstPersonController fpsController;

	public void DisablePlayer()
	{
		// Disable the First Person Controller
		fpsController.enabled = false;
		// Unlock the Mouse Cursor
		Cursor.lockState = CursorLockMode.None;
		// Set the Mouse Cursor to Visible
		Cursor.visible = true;
	}

	public void EnablePlayer()
	{
		// Enable the First Person Controller
		fpsController.enabled = true;
		// Lock the Mouse Cursor
		Cursor.lockState = CursorLockMode.Locked;
		// Set the Mouse Cursor to Invisible
		Cursor.visible = false;
	}

}
