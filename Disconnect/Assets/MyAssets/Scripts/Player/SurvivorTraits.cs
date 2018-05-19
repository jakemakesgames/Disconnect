using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SurvivorTraits : MonoBehaviour 
{
	#region Health Variables
	[Space(10)]
	[Header("HEALTH")]
	public Slider healthSlider;
	public int maxHealth;
	public int healthFallRate;
	#endregion

	#region Thirst Variables
	[Space(10)]
	[Header("THIRST")]
	public Slider thirstSlider;
	public int maxThirst;
	public int thirstFallRate;
	#endregion

	#region Hunger Variables
	[Space(10)]
	[Header("HUNGER")]
	public Slider hungerSlider;
	public int maxHunger;
	public int hungerFallRate;
	#endregion

	#region Stamina Variables
	[Space(10)]
	[Header("STAMINA")]
	public Slider staminaSlider;
	public int normMaxStamina;
	public int fatMaxStamina;
	private int staminaFallRate;
	public int staminaFallMultiplier;
	private int staminaRegainRate;
	public int staminaRegainMultiplier;
	#endregion

	#region Fatigue Variables
	[Space(10)]
	[Header("FATIGUE")]
	public Slider fatigueSlider;
	public int maxFatigue;
	public int fatigueFallRate;
	public bool fatStage1 = true;
	public bool fatStage2 = true;
	public bool fatStage3 = true;
	#endregion

	#region Tempurature Variables
	[Space(10)]
	[Header("TEMPURATURE SETTINGS")]
	public float freezingTemp;
	public float currentTemp;
	public float normalTemp;
	public float heatTemp;
	public Text tempNumber;
	public Image tempBG;
	#endregion

	#region References
	[Space(10)]
	private CharacterController charController;
	private FirstPersonController playerController;
	#endregion

	void Start()
	{
		#region Start Sliders
		// Initiating MaxHealth values //
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;

		// Initiating MaxThirst values //
		thirstSlider.maxValue = maxThirst;
		thirstSlider.value = maxThirst;

		// Initiating MaxHunger values //
		hungerSlider.maxValue = maxHunger;
		hungerSlider.value = maxHunger;

		// Initiating MaxStamina values //
		staminaSlider.maxValue = normMaxStamina;
		staminaSlider.value = normMaxStamina;
		staminaFallRate = 1;
		staminaRegainRate = 1;

		fatigueSlider.maxValue = maxFatigue;
		fatigueSlider.value = maxFatigue;


		// Instantly finding Character & First Person Controller components
		charController = GetComponent<CharacterController>();
		playerController = GetComponent<FirstPersonController>();
		#endregion
	}

	void UpdateTempurature()
	{
		// Update the tempurature UI text element
		tempNumber.text = currentTemp.ToString ("00.0");
	}

	void Update()
	{
		
		TempuratureController();
		HealthController();
		HungerController();
		ThirstController();
		StaminaController();
		FatigueController();

	}

	#region TEMPURATURE CONTROLLER
	void TempuratureController()
	{
		// TEMPURATURE CONTROLLER
		if (currentTemp <= freezingTemp) {
			// If the current tempurature is ever below the freezing tempurature, change the BG to blue
			tempBG.color = Color.blue;
			UpdateTempurature ();

		} else if (currentTemp >= heatTemp - 0.1) {
			// If the current tempurature is ever below the freezing tempurature, change the BG to blue
			tempBG.color = Color.red;
			UpdateTempurature ();

		} 
		else 
		{
			tempBG.color = Color.green;
			UpdateTempurature ();
		}
	}
	#endregion

	#region HEALTH CONTROLLER
	void HealthController()
	{
		// HEALTH CONTROLLER 
		// If the hunger AND thirst slider is less than or equal to 0, begin degrading health TWICE as fast
		if (hungerSlider.value <= 0 && (thirstSlider.value <= 0)) 
		{
			healthSlider.value -= Time.deltaTime / healthFallRate * 2;
		} 
		// If the hunger OR thirst slider is less than or equal to 0, begin degrading health at a normal speed || if the current tempurature is less than freezing temp OR greater than heat tempurature
		else if (hungerSlider.value <= 0 || thirstSlider.value <= 0 || currentTemp <= freezingTemp || currentTemp >= heatTemp) 
		{
			healthSlider.value -= Time.deltaTime / healthFallRate * 2;
		}

		if (healthSlider.value <= 0) 
		{
			// If the health slider is less than or equal to 0, call this function
			CharacterDeath ();
		}
	}
	#endregion

	#region HUNGER CONTROLLER
	void HungerController()
	{
		// HUNGER CONTROLLER
		if (hungerSlider.value >= 0) 
		{
			// If the hunger slider is greater than 0, start depleting hunger
			hungerSlider.value -= Time.deltaTime / hungerFallRate;
		} 
		else if (hungerSlider.value <= 0) 
		{
			// If the hunger slider is less than or equal to 0, hunger equals 0
			hungerSlider.value = 0;
		} 
		else if (hungerSlider.value >= maxHunger)
		{
			// If the hunger slider is greater or equal to the maxHunger, hungerSlider equals maxHunger
			hungerSlider.value = maxHunger;
		}
	}
	#endregion

	#region THIRST CONTROLLER
	void ThirstController()
	{
		// THIRST CONTROLLER
		if (thirstSlider.value >= 0) 
		{
			// If the thirst slider is greater than 0, start depleting hunger
			thirstSlider.value -= Time.deltaTime / thirstFallRate;
		} 
		else if (thirstSlider.value <= 0) 
		{
			// If the thirst slider is less than or equal to 0, thirst equals 0
			thirstSlider.value = 0;
		} 
		else if (thirstSlider.value >= maxThirst)
		{
			// If the thirst slider is greater or equal to the maxThirst, thirstSlider equals maxThirst
			thirstSlider.value = maxThirst;
		}
	}
	#endregion

	#region STAMINA CONTROLLER
	void StaminaController()
	{
		// STAMINA CONTROLLER
		if (charController.velocity.magnitude > 0 && Input.GetKey (KeyCode.LeftShift)) {
			// If the player is moving AND they're pressing the shift key to sprint, deplete the stamina bar
			staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMultiplier;

			if (staminaSlider.value > 0) 
			{
				//if you have stamina left/ you are sprinting, increase tempurature
				currentTemp += Time.deltaTime / 5;
			}

		} 
		else 
		{
			// If the player is NOT holding shift and sprinting, increase the stamina
			staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMultiplier;

			if (currentTemp >= normalTemp) 
			{
				// Bring temp down
				currentTemp -= Time.deltaTime / 10;
			}
		}

		if (staminaSlider.value >= fatMaxStamina) 
		{
			// Capping the Stamina value at the Max Stamina value
			staminaSlider.value = fatMaxStamina;
		} 
		else if (staminaSlider.value <= 0) 
		{
			staminaSlider.value = 0;
			// If the Stamina value is less than or equal to 0, the player's run speed is epual to the walk speed
			playerController.m_RunSpeed = playerController.m_WalkSpeed;
		} 
		else if (staminaSlider.value >= 0) 
		{
			// If the stamina is above 0, run speed is equal to the normal run speed
			playerController.m_RunSpeed = playerController.m_RunSpeedNorm;
		}
	}
	#endregion

	#region FATIGUE CONTROLLER
	void FatigueController()
	{
		// STAMINA CONTROLLER
		// if the fatigue slider's value is less than or equal to 60, set the stamina value to 80
		if (fatigueSlider.value <= 60 && fatStage1) 
		{
			fatMaxStamina = 80;
			staminaSlider.value = fatMaxStamina;
			fatStage1 = false;
		} 
		// if the fatigue slider's value is less than or equal to 40, set the stamina value to 60
		else if (fatigueSlider.value <= 40 && fatStage2) 
		{
			fatMaxStamina = 60;
			staminaSlider.value = fatMaxStamina;
			fatStage2 = false;
		} 
		// if the fatigue slider's value is less than or equal to 20, set the stamina value to 20
		else if (fatigueSlider.value <= 20 && fatStage3) 
		{
			fatMaxStamina = 20;
			staminaSlider.value = fatMaxStamina;
			fatStage3 = false;
		}

		if (fatigueSlider.value >= 0) 
		{
			fatigueSlider.value -= Time.deltaTime * fatigueFallRate;
		} 
		else if (fatigueSlider.value <= 0) 
		{
			fatigueSlider.value = 0;
			healthSlider.value -= Time.deltaTime / healthFallRate * 2;
		} 
		else if (fatigueSlider.value >= maxFatigue) 
		{
			fatigueSlider.value = maxFatigue;
		}
	}
	#endregion

	void CharacterDeath()
	{
		// DEATH CONTROLLER
	}
}
