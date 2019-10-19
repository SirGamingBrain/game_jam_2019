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
        if (Input.GetKeyDown(KeyCode.P))
        {
            baking();
            mixing();
            extracting();
            cauldron();
            Itemvalues();
            num = 0;
            //if (OvenItems.TryGetValue("Pick up 1(Clone)", out itemValue)) 
            //Debug.Log(OvenItems);
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
        Debug.Log("Hey");
        if (ObjectsName == "Pick up 1 (Clone)")
        {
            itemValue = 1;
            
          
        }

        if (ObjectsName == "Pick up 2 (Clone)")
        {
            itemValue = 2;

        }
        if (ObjectsName == "Pick up 3 (Clone)")
        {
            itemValue = 3;

        }
        if (ObjectsName == "Pick up 4 (Clone)")
        {
            itemValue = 4;

        }

       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ObjectsName = other.gameObject.name;
           // Itemvalues();
            name = player.GetComponent<Player_Movement>().selectionName;

            if (name == "Cauldron")
            {

                //add the items to the list of cauldron items
                // CauldronItems.Add(ObjectsName,itemValue);
              
                CauldronItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Cauldron!");
               
            }
            else if (name == "Mixer")
            {

                //add the items to the list of Mixer items
                // MixerItems.Add(ObjectsName);
                MixerItems.Add(ObjectsName, itemValue);
               
                Debug.Log("You have added " + ObjectsName + " to the Mixer!");
            }
            else if (name == "Extractor")
            {

                //add the items to the list of Extractor items
                //  ExtractorItems.Add(ObjectsName);
                ExtractorItems.Add(ObjectsName, itemValue);
               
                Debug.Log("You have added " + ObjectsName + " to the Extractor!");
            }

            else if (name == "Oven")
            {

                //add the items to the list of Extractor items
                //  ExtractorItems.Add(ObjectsName);
                OvenItems.Add(ObjectsName, itemValue);
               
                Debug.Log("You have added " + ObjectsName + " to the Oven!");
            }
        }
    }
}
