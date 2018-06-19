using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EndGame : MonoBehaviour 
{
    public Animator anim;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("FadeBool", true);
        }
    }


}
