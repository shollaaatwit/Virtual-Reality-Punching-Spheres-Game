using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDoor : MonoBehaviour
{
    public AudioSource wrongHit;
    public ScoreManager scoreManager;

    private bool gate = true;    
    // Start is called before the first frame update
    void Start()
    {
        wrongHit = GameObject.Find("IncorrectAudioSound").GetComponent<AudioSource>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        gate = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftController" || other.tag == "RightController")
        {
            if(gate)
            {
                scoreManager.ChangeScore(-100);
                wrongHit.Play();
                gate = false;
            }
        }
    }
}
