using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraTracking : MonoBehaviour {

    private Transform playerCamera;
    [Tooltip("Reference the Receiver Portal Parent")]
    [SerializeField]
    private Transform receiverPortal;
    [Tooltip("Reference the Sender Portal Parent with the corresponding letter suffix")]
    [SerializeField]
    private Transform senderPortalToTrack;

    void Start()
    {
        playerCamera = GameObject.FindWithTag("Player").GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - senderPortalToTrack.position;
        transform.position = receiverPortal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(receiverPortal.rotation, senderPortalToTrack.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
