using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] customerPrefabs = new GameObject[5];
    
    public Vector3 spawnPoint;
    public float respawnTime = 5.0f;
    public float timer;
    int randomIndex;


    private void Update()
    {
        spawnEnemy();
        randomIndex = Random.Range(0, customerPrefabs.Length);
    }

    private void spawnEnemy ()
    {
        timer += Time.deltaTime;
        if (timer > respawnTime)
        {
            //can be edited in scene
            GameObject instantiatedObject = Instantiate(customerPrefabs[randomIndex], spawnPoint, Quaternion.identity);
           timer = 0;
            
        }
    }


}
