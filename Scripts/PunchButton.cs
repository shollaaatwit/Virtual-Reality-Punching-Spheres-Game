using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PunchButton : MonoBehaviour
{
    public int scoreValue = 50;
    public GameObject smallButton;
    public GameObject mediumButton;
    public GameObject largeButton;
    public AudioSource wrongHit;
    public AudioSource correctHit;
    public ScoreManager scoreManager;
    public string correctFist = "";
    public Vector3 velocity;
    private bool gate = true;
    public OVRInput.Controller controller;

    void Start()
    {
        if(gameObject.tag != "Egg")
        {
            correctHit = GameObject.Find("CorrectAudioSound").GetComponent<AudioSource>();
            wrongHit = GameObject.Find("IncorrectAudioSound").GetComponent<AudioSource>();
            scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        }

        gate = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftController" || other.tag == "RightController")
        {
            if(correctFist == other.tag || gameObject.tag == "Egg" || gameObject.tag == "Reset")
            {
                float speed = velocity.magnitude;
                int newScore = scoreValue + (int) (speed * 10);
                if(speed > 0.5 && speed <= 1)
                {
                    SmashButton(smallButton, newScore);
                    TriggerHapticFeedback(0.1f, 0.3f, controller);
                }
                else if(speed > 1 && speed <= 2)
                {
                    SmashButton(mediumButton, newScore);
                    TriggerHapticFeedback(0.3f, 0.5f, controller);
                }
                else if(speed > 2) 
                {
                    SmashButton(largeButton, newScore);
                    TriggerHapticFeedback(0.6f, 0.7f, controller);
                }
            }
            else
            {
                Vector3 launch = (-velocity + -transform.forward) 
                    + ((-velocity + transform.up)*Random.Range(-1.0f, 1.0f)) 
                    + (-velocity + transform.right);
                gameObject.GetComponent<Rigidbody>().AddForce((launch) * 0.5f, ForceMode.Impulse);
                gameObject.GetComponent<Rigidbody>().AddForce((launch) * 0.5f, ForceMode.Impulse);
                wrongHit.Play();
                if(gate)
                {
                    scoreManager.ChangeScore(-scoreValue);
                    gate = false;
                }
                TriggerHapticFeedback(0.9f, 1.0f, controller);
                Destroy(gameObject, 2.0f);
            }
        }
    }

    private void SmashButton(GameObject theObject, int score)
    {
        if(gameObject.tag != "Egg" && gameObject.tag != "Reset")
        {
            Instantiate(theObject, transform.position, transform.rotation);
            correctHit.Play();
            scoreManager.ChangeScore(score);
            Destroy(gameObject); 
        }
        else
        {
            Instantiate(theObject, transform.position, transform.rotation);
            LoadNewScene sceneMan = GetComponent<LoadNewScene>();
            if(gameObject.tag == "Egg")
            {
                sceneMan.LoadAScene();                
            } 
            else
            {
                sceneMan.ResetScene();
            }
            foreach (Transform t in gameObject.transform) 
            {
                t.gameObject.SetActive(false);
            }
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    void Update()
    {
        velocity = OVRInput.GetLocalControllerVelocity(controller);
    }

    public void TriggerHapticFeedback(float intensity, float duration, OVRInput.Controller controller)
    {
        StartCoroutine(HapticFeedbackCoroutine(intensity, duration, controller));
    }
    
    private IEnumerator HapticFeedbackCoroutine(float intensity, float duration, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(intensity, intensity, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
