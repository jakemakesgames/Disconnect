using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour {

    private Camera cameraA;
    private Camera cameraB;

    [Tooltip("Reference the CameraTexture_A directly from the project")]
    [SerializeField] private Material cameraMatA;
    [Tooltip("Reference the CameraTexture_B directly from the project")]
    [SerializeField] private Material cameraMatB;


    // Use this for initialization
    void Start () {
        cameraA = GameObject.FindGameObjectWithTag("Camera_A").GetComponent<Camera>();
        cameraB = GameObject.FindGameObjectWithTag("Camera_B").GetComponent<Camera>();

        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;


        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;

    }
}
	
