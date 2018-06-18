using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    [SerializeField] private AudioSource audioClip;
    [SerializeField] private bool isPlaying;
    [SerializeField] private bool hasPlayed;


    private void Update()
    {
       if(audioClip.isPlaying == true)
        {
            hasPlayed = true;
            isPlaying = true;
        }
        if (hasPlayed && !isPlaying)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isPlaying)
        {
            audioClip.Play();
        }
    }

}
