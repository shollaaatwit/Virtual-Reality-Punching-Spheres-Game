using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectsForward : MonoBehaviour
{
    public float speed = 2f;
    public LevelManager levelManager;

    public void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    void FixedUpdate()
    {
        if(levelManager.gameState)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
    }
}
