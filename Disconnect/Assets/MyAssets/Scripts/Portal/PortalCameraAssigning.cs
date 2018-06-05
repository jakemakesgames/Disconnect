using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraAssigning : MonoBehaviour {

    [SerializeField] private GameObject correctCamera;

    private PortalCameraTracking pct;
	// Use this for initialization
	void Start () {
        pct = correctCamera.GetComponent<PortalCameraTracking>();
	}

    private void OnTriggerEnter(Collider other)
    {
        pct.secondRoom = true;
    }

}
