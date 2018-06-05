using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraTracking : MonoBehaviour {

    private Transform playerCamera;
    [Tooltip("Reference the Receiver Portal Parent")]
    [SerializeField]
    private Transform firstReceiverPortal;
    [SerializeField]
    private Transform secondReceiverPortal;
    [Tooltip("Reference the Sender Portal Parent with the corresponding letter suffix")]
    [SerializeField]
    private Transform firstSenderPortalToTrack;
    [Tooltip("Reference the Sender Portal Parent with the corresponding letter suffix")]
    [SerializeField]
    private Transform secondSenderPortalToTrack;

    public bool secondRoom = false;

    void Start()
    {
        playerCamera = GameObject.FindWithTag("Player").GetComponentInChildren<Camera>().transform;
        if(secondSenderPortalToTrack == null && secondReceiverPortal == null)
        {
            //secondSenderPortalToTrack = null;
            //secondReceiverPortal = null;
            //return;
        }
    }

    void Update()
    {
        if (!secondRoom)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - firstSenderPortalToTrack.position;
            transform.position = firstReceiverPortal.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(firstReceiverPortal.rotation, firstSenderPortalToTrack.rotation);

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        else if (secondRoom)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - secondSenderPortalToTrack.position;
            transform.position = secondReceiverPortal.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(secondReceiverPortal.rotation, secondSenderPortalToTrack.rotation);

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}
