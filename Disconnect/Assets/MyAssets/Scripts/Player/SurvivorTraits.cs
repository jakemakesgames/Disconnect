using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SurvivorTraits : MonoBehaviour 
{
	[Header("HEALTH")]
	public Slider healthSlider;
	public int maxHealth;
	public int healthFallRate;

	[Header("THIRST")]
	public Slider thirstSlider;
	public int maxThirst;
	public int thirstFallRate;

	[Header("HUNGER")]
	public Slider hungerSlider;
	public int maxHunger;
	public int hungerFallRate;

	[Header("STAMINA")]
	public Slider staminaSlider;
	public int maxStamina;
	private int staminaFallRate;
	public int staminaFallMultiplier;
	private int staminaRegainRate;
	public int staminaRegainMultiplier;

	private CharacterController charController;
	private FirstPersonController playerController;

	void Start()
	{
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
		staminaSlider.maxValue = maxStamina;
		staminaSlider.value = maxStamina;
		staminaFallRate = 1;
		staminaRegainRate = 1;

		// Instantly finding Character & First Person Controller components
		charController = GetComponent<CharacterController>();
		playerController = GetComponent<FirstPersonController>();
	}

	void Update()
	{
		// HEALTH CONTROLLER 
		// If the hunger AND thirst slider is less than or equal to 0, begin degrading health TWICE as fast
		if (hungerSlider.value <= 0 && (thirstSlider.value <= 0)) 
		{
			healthSlider.value -= Time.deltaTime / healthFallRate * 2;
		} 
		// If the hunger OR thirst slider is less than or equal to 0, begin degrading health at a normal speed
		else if (hungerSlider.value <= 0 || thirstSlider.value <= 0) 
		{
			healthSlider.value -= Time.deltaTime / healthFallRate * 2;
		}

		if (healthSlider.value <= 0) 
		{
			// If the health slider is less than or equal to 0, call this function
			CharacterDeath ();
		}

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

		// THIRST SLIDER
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

		// STAMINA CONTROLLER
		if (charController.velocity.magnitude > 0 && Input.GetKey (KeyCode.LeftShift)) {
			// If the player is moving AND they're pressing the shift key to sprint, deplete the stamina bar
			staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMultiplier;
		} 
		else 
		{
			// If the player is NOT holding shift and sprinting, increase the stamina
			staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMultiplier;
		}

		if (staminaSlider.value >= maxStamina) {
			// Capping the Stamina value at the Max Stamina value
			staminaSlider.value = maxStamina;
		} else if (staminaSlider.value <= 0) {
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

	void CharacterDeath()
	{
		// DEATH CONTROLLER
	}
}
