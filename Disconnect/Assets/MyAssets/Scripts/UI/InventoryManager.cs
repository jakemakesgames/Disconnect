using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour 
{
	[SerializeField] private DisableManager dm;
	public GameObject inventoryCanvas;

	void Start()
	{
		inventoryCanvas.SetActive (false);
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.I)) {
			DisplayInventoryUI ();
		}
	}

	public void DisplayInventoryUI()
	{
		inventoryCanvas.SetActive (true);
		dm.DisablePlayer ();
	}

	public void HideInventoryUI()
	{
		inventoryCanvas.SetActive (false);
		dm.EnablePlayer ();
	}



}
