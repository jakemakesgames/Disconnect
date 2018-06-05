using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour {

    private Camera cameraA;
    private Camera cameraB;
    private Camera cameraC;
    private Camera cameraWrongCor;
    private Camera cameraCorrectCor;


    [Tooltip("Reference the CameraTexture_A directly from the project")]
    [SerializeField] private Material cameraMatA;
    [Tooltip("Reference the CameraTexture_B directly from the project")]
    [SerializeField] private Material cameraMatB;
    [Tooltip("Reference the CameraTexture_C directly from the project")]
    [SerializeField] private Material cameraMatC;
    [Tooltip("Reference the CameraTexture_WrongCor directly from the project")]
    [SerializeField] private Material cameraMatWrongCor;
    [Tooltip("Reference the CameraTexture_CorrectCor directly from the project")]
    [SerializeField] private Material cameraMatCorrectCor;


    // Use this for initialization
    void Start () {
        cameraA = GameObject.FindGameObjectWithTag("Camera_A").GetComponent<Camera>();
        cameraB = GameObject.FindGameObjectWithTag("Camera_B").GetComponent<Camera>();
        cameraC = GameObject.FindGameObjectWithTag("Camera_C").GetComponent<Camera>();
        cameraWrongCor = GameObject.FindGameObjectWithTag("Camera_WrongCor").GetComponent<Camera>();
        cameraCorrectCor = GameObject.FindGameObjectWithTag("Camera_CorrectCor").GetComponent<Camera>();


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

        if (cameraC.targetTexture != null)
        {
            cameraC.targetTexture.Release();
        }
        cameraC.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatC.mainTexture = cameraC.targetTexture;

        if (cameraWrongCor.targetTexture != null)
        {
            cameraWrongCor.targetTexture.Release();
        }
        cameraWrongCor.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatWrongCor.mainTexture = cameraWrongCor.targetTexture;

        if (cameraCorrectCor.targetTexture != null)
        {
            cameraCorrectCor.targetTexture.Release();
        }
        cameraCorrectCor.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatCorrectCor.mainTexture = cameraCorrectCor.targetTexture;

    }
}
	
