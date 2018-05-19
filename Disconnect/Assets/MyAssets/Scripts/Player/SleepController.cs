using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepController : MonoBehaviour 
{
	[SerializeField] private GameObject sleepUI;
	[SerializeField] private Slider sleepSlider;
	[SerializeField] private Text sleepNumber;

	[SerializeField] private float hourlyRegen;
	[SerializeField] private DisableManager disableManager;

	void Start()
	{
		disableManager = GameObject.FindGameObjectWithTag ("DisableController").GetComponent<DisableManager> ();
	}

	public void EnableSleepUI()
	{
		sleepUI.SetActive (true);
		disableManager.DisablePlayer ();
	}

	public void UpdateSlider()
	{
		// Update Sleep Text to the Sleep Slider value -> convert to string
		sleepNumber.text = sleepSlider.value.ToString ("0");
	}

	public void SleepBtn(SurvivorTraits survivorTraits)
	{
		// Sets the fatigue slider value equal to the sleep slider value * the hourly regen.
		survivorTraits.fatigueSlider.value = sleepSlider.value * hourlyRegen;
		// Sets the fatigue max stamina equal to the fatigue slider value
		survivorTraits.fatMaxStamina = survivorTraits.fatigueSlider.value; 
		// Sets the stamina slider value equal to the normal max stamina value;
		survivorTraits.staminaSlider.value = survivorTraits.normMaxStamina;

		survivorTraits.fatStage1 = true;
		survivorTraits.fatStage2 = true;
		survivorTraits.fatStage3 = true;

		sleepSlider.value = 1;
		disableManager.EnablePlayer ();
		sleepUI.SetActive (false);
	}


}
