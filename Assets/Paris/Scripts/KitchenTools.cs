using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTools : MonoBehaviour
{
    public GameObject Cauldron;
    public GameObject Mixer;
    public GameObject Extractor;
    public GameObject Oven;

    GameObject player;

    //List<string> CauldronItems = new List<string>();
    //List<string> MixerItems = new List<string>();
    //List<string> ExtractorItems = new List<string>();

    Dictionary<string, int> CauldronItems = new Dictionary<string, int>();
    Dictionary<string, int> MixerItems = new Dictionary<string, int>();
    Dictionary<string, int> ExtractorItems = new Dictionary<string, int>();
    Dictionary<string, int> OvenItems = new Dictionary<string, int>();


    string name;
    string ObjectsName;

    int num;
   
    int itemValue;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Temp Player");


    }

    // Update is called once per frame
    void Update()
    {
        Itemvalues();
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            baking();
            mixing();
            extracting();
            cauldron();
            Combinations();
            num = 0;

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            testing();
        }
    }



    void cauldron()
    {
        //cauldron
        foreach (KeyValuePair<string, int> ingredients in CauldronItems)
        {
            //CauldronItems
            num++;

            Debug.Log("Cauldron Items" + "\n" + num + "." + " " + ingredients);

        }

    }

    void extracting()
    {
        //extractor
        foreach (KeyValuePair<string, int> ingredients in ExtractorItems)
        {

            num++;

            Debug.Log("Extractor Items" + "\n" + num + "." + " " + ingredients);

        }
    }

    void mixing()
    {
        //mixer
        foreach (KeyValuePair<string, int> ingredients in MixerItems)
        {

            num++;

            Debug.Log("Mixer Items" + "\n" + num + "." + " " + ingredients);

        }
    }

    void baking()
    {
        //bake
        foreach (KeyValuePair<string, int> ingredients in OvenItems)
        {
            num++;
            Debug.Log("Oven Items" + "\n" + num + "." + " " + ingredients);
        }
    }

    void Itemvalues()
    {
        if (ObjectsName == "Pick up 1(Clone)")
        {
            itemValue = 1;
        }

        if (ObjectsName == "Pick up 2(Clone)")
        {
            itemValue = 2;
        }
        if (ObjectsName == "Pick up 3(Clone)")
        {
            itemValue = 3;
        }
        if (ObjectsName == "Pick up 4(Clone)")
        {
            itemValue = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ObjectsName = other.gameObject.name;
            Itemvalues();
            name = player.GetComponent<Player_Movement>().selectionName;

            if (name == "Cauldron")
            {

                CauldronItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Cauldron!");

            }
            else if (name == "Mixer")
            {
                MixerItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Mixer!");
            }
            else if (name == "Extractor")
            {
                ExtractorItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Extractor!");
            }

            else if (name == "Oven")
            {

                OvenItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Oven!");
            }
        }
    }

    void Combinations()
    {
        if (CauldronItems.Count != 0)
        {
            int num1 = 0;
            int num2 = 0;
            int sum = 0;
            List<int> hey = new List<int>();
            Dictionary<string, int>.ValueCollection mixes = CauldronItems.Values;
            foreach (int mixture in mixes)
            {
                Debug.Log(mixture);
                hey.Add(mixture);


            }

            foreach (int i in hey)
            {
                Debug.Log(i);
            }

            hey[1] = num1;
            hey[2] = num2;
            sum = num1 + num2;
            Debug.Log(sum);
        }

        else
        {
            Debug.Log("we empty dog");
        }
       
    }

    void testing()
    {
        int num1 = 0;
        int num2 = 0;
        int sum = 0;
        List<int> dumb = new List<int>();
        dumb.Add(1);
        dumb.Add(3);
        dumb.Add(10);
        foreach (int j in dumb)
        {
            Debug.Log(j);
            sum += dumb[j];
            
        }
        Debug.Log(dumb.Count);
        Debug.Log(sum);
    }
}
