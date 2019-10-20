using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderScript : MonoBehaviour
{
    TextMeshProUGUI[] timerTexts = new TextMeshProUGUI[5];

    public PlayerUIScript strikeCounter;

    bool ordersExist = false;

    readonly int maxOrders = 5;
    int currentOrders = 0;

    float[] timers = new float[5] {0, 0, 0, 0, 0};

    public GameObject[] Orders = new GameObject[15];

    public GameObject[] customerPrefabs = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        //We ain't doing jack here right?
    }

    // Update is called once per frame
    void Update()
    {
        if (currentOrders == 0)
        {
            ordersExist = false;
        }

        if (ordersExist == true)
        {
            for (int i = 0; i < 5; i++)
            {
                if (timers[i] > 0f)
                {
                    timers[i] -= Time.deltaTime;

                    float minutes = Mathf.Floor(timers[i] / 60);
                    float seconds = (timers[i] % 60);

                    timerTexts[i].text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
                }
                else if (timers[i] <= 0f)
                {
                    switch (i)
                    {
                        case 0:
                            FindTrash(0);
                            break;
                        case 1:
                            FindTrash(1);
                            break;
                        case 2:
                            FindTrash(2);
                            break;
                        case 3:
                            FindTrash(3);
                            break;
                        case 4:
                            FindTrash(4);
                            break;
                    }
                }
            }
        }


    }

    public void FindTrash(int order)
    {
        GameObject OrderHolder = GameObject.Find("Order 1");

        switch (order)
        {
            case 0:
                OrderHolder = GameObject.Find("Order 1");
                break;
            case 1:
                OrderHolder = GameObject.Find("Order 2");
                break;
            case 2:
                OrderHolder = GameObject.Find("Order 3");
                break;
            case 3:
                OrderHolder = GameObject.Find("Order 4");
                break;
            case 4:
                OrderHolder = GameObject.Find("Order 5");
                break;
        }

        foreach (Transform child in OrderHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void CreateOrder(float timer, int potionIndex, GameObject customer)
    {
        if (currentOrders < maxOrders)
        {
            float minutes = 0f;
            float seconds = 0f;

            switch (currentOrders)
            {
                case 0:
                    timers[0] = timer;
                    GameObject newOrder1 = Instantiate(Orders[potionIndex], GameObject.Find("Order 1").transform.position, GameObject.Find("Order 1").transform.rotation);
                    newOrder1.transform.SetParent(GameObject.Find("Order 1").transform, false);
                    newOrder1.transform.rotation = new Quaternion(0f,0f,0f,0f);
                    timerTexts[0] = newOrder1.transform.Find(newOrder1.name + " Timer").GetComponent<TextMeshProUGUI>();

                    minutes = Mathf.Floor(timers[0] / 60);
                    seconds = (timers[0] % 60);

                    timerTexts[0].text = (minutes.ToString("00") + ":" + seconds.ToString("00"));

                    customerPrefabs[0] = customer;
                    break;
                case 1:
                    timers[1] = timer;
                    GameObject newOrder2 = Instantiate(Orders[potionIndex], GameObject.Find("Order 2").transform.position, GameObject.Find("Order 2").transform.rotation);
                    newOrder2.transform.SetParent(GameObject.Find("Order 2").transform, false);
                    newOrder2.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                    timerTexts[1] = newOrder2.transform.Find(newOrder2.name + " Timer").GetComponent<TextMeshProUGUI>();

                    minutes = Mathf.Floor(timers[1] / 60);
                    seconds = (timers[1] % 60);

                    timerTexts[1].text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
                    customerPrefabs[1] = customer;
                    break;
                case 2:
                    timers[2] = timer;
                    GameObject newOrder3 = Instantiate(Orders[potionIndex], GameObject.Find("Order 3").transform.position, GameObject.Find("Order 3").transform.rotation);
                    newOrder3.transform.SetParent(GameObject.Find("Order 3").transform, false);
                    newOrder3.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                    timerTexts[2] = newOrder3.transform.Find(newOrder3.name + " Timer").GetComponent<TextMeshProUGUI>();

                    minutes = Mathf.Floor(timers[2] / 60);
                    seconds = (timers[2] % 60);

                    timerTexts[2].text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
                    customerPrefabs[2] = customer;
                    break;
                case 3:
                    timers[3] = timer;
                    GameObject newOrder4 = Instantiate(Orders[potionIndex], GameObject.Find("Order 4").transform.position, GameObject.Find("Order 4").transform.rotation);
                    newOrder4.transform.SetParent(GameObject.Find("Order 4").transform, false);
                    newOrder4.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                    timerTexts[3] = newOrder4.transform.Find(newOrder4.name + " Timer").GetComponent<TextMeshProUGUI>();

                    minutes = Mathf.Floor(timers[3] / 60);
                    seconds = (timers[3] % 60);

                    timerTexts[3].text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
                    customerPrefabs[3] = customer;
                    break;
                case 4:
                    timers[4] = timer;
                    GameObject newOrder5 = Instantiate(Orders[potionIndex], GameObject.Find("Order 5").transform.position, GameObject.Find("Order 5").transform.rotation);
                    newOrder5.transform.SetParent(GameObject.Find("Order 5").transform, false);
                    newOrder5.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                    timerTexts[4] = newOrder5.transform.Find(newOrder5.name + " Timer").GetComponent<TextMeshProUGUI>();

                    minutes = Mathf.Floor(timers[4] / 60);
                    seconds = (timers[4] % 60);

                    timerTexts[4].text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
                    customerPrefabs[4] = customer;
                    break;
                default:

                    break;
            }

            currentOrders++;
            ordersExist = true;

            minutes = 0f;
            seconds = 0f;
        }
    }
}
