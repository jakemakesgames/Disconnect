using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour 
{
	public Item item;

	[Header("Consumables")]
	public string itemName;

	public bool food;
	public bool water;
	public bool health;
	public float value;
	[Space(10)]

	[Header("Interactables")]
	[SerializeField] private bool bed;
	[SerializeField] private SleepController sleepController;

	public SurvivorTraits survivorTraits;

	void Start()
	{
		sleepController = GameObject.FindGameObjectWithTag ("SleepController").GetComponent<SleepController> ();
	}

	public void Interaction(SurvivorTraits survivorTraits)
	{
		//if the FOOD bool is true
		if (food) {
			survivorTraits.hungerSlider.value += value;
		} 
		// if the WATER bool is true
		else if (water) 
		{
			survivorTraits.thirstSlider.value += value;
		}
		// if the HEALTH bool is true
		else if (health) 
		{
			survivorTraits.healthSlider.value += value;
		} 
		else if (bed) 
		{
			sleepController.EnableSleepUI();
		}
	}

	public void PickUp()
	{
		if (!bed) {
			bool wasPickedUp = Inventory.instance.Add (item);

			if (wasPickedUp) {
				Destroy (gameObject);
			}

		}

	}

}
