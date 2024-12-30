using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public Rigidbody[] shardRbs; // Assign in Inspector: all the individual shard prefabs
    public float explosionForce = 5f; // Adjust as needed
    public float explosionRadius = 2f;
    public float upwardsModifier = 0.5f;


    void Start ()
    {
        Explode();
    }
    public void Explode()
    {
        shardRbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody shard in shardRbs)
        {
            shard.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
        }
        gameObject.GetComponent<AudioSource>().Play();
    }
}
