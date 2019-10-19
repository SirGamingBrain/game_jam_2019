using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTools : MonoBehaviour
{
    public GameObject Cauldron;
    public GameObject Mixer;
    public GameObject Extractor;

    GameObject player;

    //List<string> CauldronItems = new List<string>();
    //List<string> MixerItems = new List<string>();
    //List<string> ExtractorItems = new List<string>();

    Dictionary<string, int> CauldronItems = new Dictionary<string, int>();
    Dictionary<string, int> MixerItems = new Dictionary<string, int>();
    Dictionary<string, int> ExtractorItems = new Dictionary<string, int>();

    string name;
    string ObjectsName;

    int num;
    int itemValue;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Temp Player");
        Itemvalues();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            baking();
            mixing();
            extracting();
            num = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ObjectsName = other.gameObject.name;
            name = player.GetComponent<Player_Movement>().selectionName;
            if (name == "Cauldron")
            {
                //add the items to the list of cauldron items
                // CauldronItems.Add(ObjectsName,itemValue);
                CauldronItems.Add(ObjectsName, Itemvalues());
                Debug.Log("You have added " + ObjectsName + " to the Cauldron!");
            }
            else if (name == "Mixer")
            {
                //add the items to the list of Mixer items
                // MixerItems.Add(ObjectsName);
                MixerItems.Add(ObjectsName, Itemvalues());
                Debug.Log("You have added " + ObjectsName + " to the Mixer!");
            }
            else if (name == "Extractor")
            {
                //add the items to the list of Extractor items
                //  ExtractorItems.Add(ObjectsName);
                ExtractorItems.Add(ObjectsName, Itemvalues());
                Debug.Log("You have added " + ObjectsName + " to the Extractor!");
            }
        }
    }

    void baking()
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
        foreach (KeyValuePair<string,int> ingredients in ExtractorItems)
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

    int Itemvalues()
    {
        if (ObjectsName == "Pick up 1 (Clone)")
        {
            itemValue = 1;
            return itemValue;
        }

        if (ObjectsName == "Pick up 2 (Clone)")
        {
            itemValue = 2;
            return itemValue;
        }
        if (ObjectsName == "Pick up 3 (Clone)")
        {
            itemValue = 3;
            return itemValue;
        }
        if (ObjectsName == "Pick up 4 (Clone)")
        {
            itemValue = 4;
            return itemValue;
        }
        return itemValue;
    }
}
