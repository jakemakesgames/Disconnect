using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour 
{
	[SerializeField] private Light sun;
	[SerializeField] private float secondsInFullDay = 120f;

	[Range(0,1)] public float currentTimeOfDay = 0;
	private float timeMultiplier = 1f;
	private float sunInitialIntensity;

	void Start()
	{
		// The sun intensity is based off the intensity of the directional light (sun) in the scene
		sunInitialIntensity = sun.intensity;
	}

	void Update()
	{
		UpdateSun ();

		// Over time define time.deltaTime by the seconds in the day then multiply it my timeMultiplier
		currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

		// If the current time of day is greater or equal to 1 - "restart the day"
		if (currentTimeOfDay >= 1) 
		{
			currentTimeOfDay = 0;
		}
	}

	void UpdateSun()
	{
		// Update Sun

		//rotate the sun around based on the current time of day by 360 degrees (-90 = sunset, 170 = horizon)
		sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) -90, 170, 0);

		float intensityMultiplier = 1;

		// <= 0.25f = sun rise || >= 0.75f = sun set
		if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
			intensityMultiplier = 0;
		} 
		else if (currentTimeOfDay <= 0.25f) 
		{
			// Set intensity multiplier to value (sunrise)
			intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1/ 0.02f));
		}

		else if (currentTimeOfDay >= 0.73f)
		{
			// Set intensity multiplier to value (sunset)
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1/ 0.02f)));
		}

		sun.intensity = sunInitialIntensity * intensityMultiplier;

	}


}
