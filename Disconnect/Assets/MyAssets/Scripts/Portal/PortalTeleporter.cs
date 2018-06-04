using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

    
    private Transform player;
    [Tooltip("Reference the ColliderPlane inside the Destination Portal to choose where to send the player")]
    [SerializeField] private Transform receiver;
    [Tooltip("Reference the Destination Portal's parent")]
    [SerializeField] private Transform destinationPortal;
    private int angleToRotatePortal = 0;

    private bool playerIsOverlapping = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        angleToRotatePortal = (int)destinationPortal.rotation.y;
    }

    void Update () {
        if (playerIsOverlapping)
        {
            
        }
	}

    IEnumerator Teleport()
    {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                //Teleport me
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += angleToRotatePortal;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                //playerIsOverlapping = false;
                yield return new WaitForSeconds(2);
            }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //playerIsOverlapping = true;
            StartCoroutine("Teleport");
        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //playerIsOverlapping = false;
        }
    }
}
