using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerUIScript timerStuff;
    public OrderScript createOrders;

    public GameObject[] customerPrefabs = new GameObject[5];
    public GameObject[] spawnpoints = new GameObject[4];

    public float respawnTime = 60f;
    public float timer = 60f;
    public float waitingTime = 300f;
    int customerIndex;
    int spawnIndex;
    int potionType;
    readonly int maxPotionType = 15;

    public int spawns = 0;

    private void FixedUpdate()
    {
        if (timerStuff.levelTimer < 300f)
        {
            respawnTime = 60f;
            waitingTime = 20f;
        }
        else if (timerStuff.levelTimer < 600f)
        {
            respawnTime = 45f;
            waitingTime = 180f;
        }
        else if (timerStuff.levelTimer < 900f)
        {
            respawnTime = 30f;
            waitingTime = 150f;
        }
        else
        {
            respawnTime = 25f;
            waitingTime = 90f;
        }

        //Debug.Log(waitingTime + " " + potionType);

        customerIndex = Random.Range(0, customerPrefabs.Length);
        spawnIndex = Random.Range(0, spawnpoints.Length);
        potionType = Random.Range(0, maxPotionType);

        timer += Time.deltaTime;

        if (timer >= respawnTime && spawns < 5)
        {
            spawns++;
            GameObject instantiatedObject = Instantiate(customerPrefabs[customerIndex], spawnpoints[spawnIndex].transform.position, Quaternion.identity);
            createOrders.CreateOrder(waitingTime, potionType, instantiatedObject);
            timer = 0;
        }
    }

    /*private void SpawnEnemy ()
    {
        timer += Time.deltaTime;

        if (timer >= respawnTime)
        {
           GameObject instantiatedObject = Instantiate(customerPrefabs[customerIndex], spawnpoints[spawnIndex].transform.position, Quaternion.identity);
           createOrders.CreateOrder(waitingTime, potionType);
           timer = 0;
        }
    }*/


}
