using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeShapeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rightBlock;
    public GameObject leftBlock;
    public GameObject obstruction;

    public int randNumber = 0;
    void Update()
    {
        randNumber = Random.Range(0, 100);
    }

    public void SpawnObjectChance()
    {
        Vector3 offsetPosition = transform.position 
            + transform.forward * Random.Range(-0.5f, 0.5f)
            + transform.up * Random.Range(-0.2f, 0.2f);
        if(randNumber <= 35 && randNumber >= 0) {
            GameObject spawnedObject = Instantiate(leftBlock, offsetPosition, leftBlock.transform.rotation);
            spawnedObject.transform.localScale *= Random.Range(0.6f, 1.3f);

        }
        else if(randNumber >= 36 && randNumber <= 85) 
        {
            GameObject spawnedObject = Instantiate(rightBlock, offsetPosition, rightBlock.transform.rotation);
            spawnedObject.transform.localScale *= Random.Range(0.6f, 1.3f);
        }
        else
        {
            Instantiate(obstruction, transform.position 
            - transform.right * 8.0f
            - transform.up * 0.5f
            + transform.forward * Random.Range(-0.4f, 0.4f), 
            obstruction.transform.rotation);
        }
    }
}
