using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

    
    private Transform player;
    [Tooltip("Reference the ReceiverLocation inside the Receiver Portal to choose where to send the player")]
    [SerializeField] private Transform receiverLocation;
    [Tooltip("Reference the Receiver Portal's parent")]
    [SerializeField] private Transform receiverPortalParent;
    private int angleToRotatePortal = 0;

    private bool playerIsOverlapping = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        angleToRotatePortal = (int)receiverPortalParent.rotation.y;
    }

    IEnumerator Teleport()
    {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                //Teleport me
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiverLocation.rotation);
                rotationDiff += angleToRotatePortal;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiverLocation.position + positionOffset;

                yield return new WaitForSeconds(2);
            }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("Teleport");
        }
    }
}
