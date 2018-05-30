using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTeleport : MonoBehaviour
{
    //public Transform player;
    public Transform newPos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.transform.position = newPos.transform.position;
        }
    }
}
