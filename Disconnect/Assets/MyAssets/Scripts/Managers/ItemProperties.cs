using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour 
{
	[Header("Consumables")]
	public string itemName;

	[SerializeField] private bool food;
	[SerializeField] private bool water;
	[SerializeField] private bool health;
	[SerializeField] private bool bed;
	[Space(10)]
	[SerializeField] private float value;
	[SerializeField] private SleepController sleepController;

	[SerializeField] SurvivorTraits survivorTraits;

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

}
