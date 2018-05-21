using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour 
{
	public DisableManager dm;

	void Awake()
	{
		dm = GameObject.FindGameObjectWithTag ("DisableController").GetComponent<DisableManager> ();

		dm.EnablePlayer ();
	}



}
