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
    Dictionary<string, int> GrindingItems = new Dictionary<string, int>();
    Dictionary<string, int> ExtractorItems = new Dictionary<string, int>();
    Dictionary<string, int> FurnaceItems = new Dictionary<string, int>();


    string name;
    string ObjectsName;

    int num;
    int sum;
    int sum2;
    int sum3;
    int sum4;
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
        foreach (KeyValuePair<string, int> ingredients in GrindingItems)
        {

            num++;

            Debug.Log("Grinding Items" + "\n" + num + "." + " " + ingredients);

        }
    }

    void baking()
    {
        //bake
        foreach (KeyValuePair<string, int> ingredients in FurnaceItems)
        {
            num++;
            Debug.Log("Furnace Items" + "\n" + num + "." + " " + ingredients);
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
            else if (name == "GrindingStation")
            {
                GrindingItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Grinder!");
            }
            else if (name == "Extractor")
            {
                ExtractorItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Extractor!");
            }

            else if (name == "Furnace")
            {

                FurnaceItems.Add(ObjectsName, itemValue);
                Debug.Log("You have added " + ObjectsName + " to the Furnace!");
            }
        }
    }

    void Combinations()
    {
        if (CauldronItems.Count != 0)
        {

            List<string> hey = new List<string>();
            Dictionary<string, int>.KeyCollection mixes = CauldronItems.Keys;
            foreach (string mixture in mixes)
            {
                Debug.Log(mixture);
                hey.Add(mixture);


            }

            foreach (string i in hey)
            {
                Debug.Log(i);
            }

            //sum += hey[0];
            //sum += hey[1];

            //Debug.Log(sum);
        }

        else if (GrindingItems.Count != 0)
        {
            List<string> hey = new List<string>();
            Dictionary<string, int>.KeyCollection mixes = GrindingItems.Keys;
            foreach (string mixture in mixes)
            {
                Debug.Log(mixture);
                hey.Add(mixture);


            }

            foreach (string i in hey)
            {
                Debug.Log(i);
            }

            
        }

        else if (ExtractorItems.Count != 0)
        {
            List<string> hey = new List<string>();
            Dictionary<string, int>.KeyCollection mixes = ExtractorItems.Keys;
            foreach (string mixture in mixes)
            {
                Debug.Log(mixture);
                hey.Add(mixture);


            }

            foreach (string i in hey)
            {
                Debug.Log(i);
            }

            
        }
        else if (FurnaceItems.Count != 0)
        {
            List<string> hey = new List<string>();
            Dictionary<string, int>.KeyCollection mixes = FurnaceItems.Keys;
            foreach (string mixture in mixes)
            {
                Debug.Log(mixture);
                hey.Add(mixture);


            }

            foreach (string i in hey)
            {
                Debug.Log(i);
            }

           
        }
        else
        {
            Debug.Log("we empty dog");
        }

        if (CauldronItems.ContainsKey("Rage of the Dragon(Clone)") && CauldronItems.ContainsKey("Power Stone(Clone)") && CauldronItems.ContainsKey("Eternal Flame(Clone)"))
        {
            Debug.Log("Strength Potion");
            CauldronItems.Remove(ObjectsName);

        }

        if (CauldronItems.ContainsKey("Power Stone(Clone)") && CauldronItems.ContainsKey("Eternal Flame(Clone)") && CauldronItems.ContainsKey("Blackeye Sugar(Clone)"))
        {
            Debug.Log("Manna Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Light Spirit(Clone)") && CauldronItems.ContainsKey("Blood Rose Sugar(Clone)") && CauldronItems.ContainsKey("Smooth Horn(Clone)"))
        {
            Debug.Log("Healing Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Empty Vessel(Clone)") && CauldronItems.ContainsKey("Eternal Flame(Clone)") && CauldronItems.ContainsKey("Blood Rose Petals(Clone)"))
        {
            Debug.Log("Revive Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Venom(Clone)") && CauldronItems.ContainsKey("Dark Spirit(Clone)") && CauldronItems.ContainsKey("Draconic Dust(Clone)"))
        {
            Debug.Log("Poison Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Moon Sugar(Clone)") && CauldronItems.ContainsKey("Blood Rose Sugar(Clone)") && CauldronItems.ContainsKey("Blackeye Sugar(Clone)"))
        {
            Debug.Log("Speed Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Moon Petals(Clone)") && CauldronItems.ContainsKey("Cyclops Tears(Clone)") && CauldronItems.ContainsKey("Rage of the Dragon(Clone)"))
        {
            Debug.Log("Stamina Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Iris Extract(Clone)") && CauldronItems.ContainsKey("Crystal Eye(Clone)") && CauldronItems.ContainsKey("Mini Star(Clone)"))
        {
            Debug.Log("Perception Potion");
            CauldronItems.Remove(ObjectsName);
        }

        if (CauldronItems.ContainsKey("Magic Powder(Clone)") && CauldronItems.ContainsKey("Draconic Dust(Clone)") && CauldronItems.ContainsKey("Gold Seeds(Clone)"))
        {
            Debug.Log("Exp Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Moon Sugar(Clone)") && CauldronItems.ContainsKey("Sun Petals(Clone)") && CauldronItems.ContainsKey("Nova Core(Clone)"))
        {
            Debug.Log("Jumping Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Goo(Clone)") && CauldronItems.ContainsKey("Scales(Clone)") && CauldronItems.ContainsKey("Cyclops Tears(Clone)"))
        {
            Debug.Log("Underwater Breathing Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Blood Rose Petals(Clone)") && CauldronItems.ContainsKey("Magic Powder(Clone)") && CauldronItems.ContainsKey("Fungus(Clone)"))
        {
            Debug.Log("Potion of Life");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Blood Seeds(Clone)") && CauldronItems.ContainsKey("Magic Powder(Clone)") && CauldronItems.ContainsKey("Rage of the Dragon(Clone)"))
        {
            Debug.Log("Seeds of Necromancy");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Smooth Horn(Clone)") && CauldronItems.ContainsKey("Venom(Clone)") && CauldronItems.ContainsKey("Nova Core(Clone)"))
        {
            Debug.Log("Death Potion");
            CauldronItems.Remove(ObjectsName);
        }
        if (CauldronItems.ContainsKey("Mini Star(Clone)") && CauldronItems.ContainsKey("Moon Sugar(Clone)") && CauldronItems.ContainsKey("Magic Powder(Clone)"))
        {
            Debug.Log("Swimming Speed Potion");
            CauldronItems.Remove(ObjectsName);
        }

        //Grinding Section
        if (GrindingItems.ContainsKey("Dragon Horn(Clone)"))
        {
            Debug.Log("Smooth Horn");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Cyclops Eye(Clone)"))
        {
            Debug.Log("Cyclops Tears");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Undead Soul(Clone)"))
        {
            Debug.Log("Empty Vessel");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Blood Rose(Clone)"))
        {
            Debug.Log("Blood Rose Petals");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Blackeyed Gold(Clone)"))
        {
            Debug.Log("Sun Petals");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Blooming Moon(Clone)"))
        {
            Debug.Log("Moon Petals");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Dark Matter(Clone)"))
        {
            Debug.Log("You can not Grind this item!");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Volcanic Ore(Clone)"))
        {
            Debug.Log("You can not Grind this item");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Snake(Clone)"))
        {
            Debug.Log("Scales");
            GrindingItems.Remove(ObjectsName);
        }
        if (GrindingItems.ContainsKey("Magic Mushrooms(Clone)"))
        {
            Debug.Log("Magic Powder");
            GrindingItems.Remove(ObjectsName);
        }
        //Grinding Ends

        //Extraction Section
        if (ExtractorItems.ContainsKey("Dragon Horn(Clone)"))
        {
            Debug.Log("Rage of the Dragon");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Cyclops Eye(Clone)"))
        {
            Debug.Log("Iris Extract");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Undead Soul(Clone)"))
        {
            Debug.Log("Light Spirit");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Blood Rose(Clone)"))
        {
            Debug.Log("Blood Seeds");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Blackeyed Gold(Clone)"))
        {
            Debug.Log("Gold Seeds");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Blooming Moon(Clone)"))
        {
            Debug.Log("Moon Seeds");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Dark Matter(Clone)"))
        {
            Debug.Log("Nova Core");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Volcanic Core(Clone)"))
        {
            Debug.Log("External Flame");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Snake(Clone)"))
        {
            Debug.Log("Venom");
            ExtractorItems.Remove(ObjectsName);
        }
        if (ExtractorItems.ContainsKey("Magic Mushrooms(Clone)"))
        {
            Debug.Log("Fungus");
            ExtractorItems.Remove(ObjectsName);
        }
        //Extraction Ends


        //Baking Section
        if (FurnaceItems.ContainsKey("Dragon Horn(Clone)"))
        {
            Debug.Log("Draconic Dust");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Cyclops Eye(Clone)"))
        {
            Debug.Log("Crystal Eye");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Undead Soul(Clone)"))
        {
            Debug.Log("Dark Spirit");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Blood Rose(Clone)"))
        {
            Debug.Log("Blood Rose Sugar");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Blackeyed Gold(Clone)"))
        {
            Debug.Log("Blackeye Sugar");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Blooming Moon(Clone)"))
        {
            Debug.Log("Moon Sugar");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Dark Matter(Clone)"))
        {
            Debug.Log("Mini Star");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Volcanic Ore(Clone)"))
        {
            Debug.Log("Power Stone");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Snake(Clone)"))
        {
            Debug.Log("What's wrong with you.. you can't bake a snake!");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Magic Mushrooms(Clone)"))
        {
            Debug.Log("Goo");
            FurnaceItems.Remove(ObjectsName);
        }
        //Baking Ends

    }

    //void testing()
    //{
    //    int num1 = 0;
    //    int num2 = 0;
    //    int sum = 0;
    //    List<int> dumb = new List<int>();
    //    dumb.Add(1);
    //    dumb.Add(3);
    //    dumb.Add(10);
    //    foreach (int j in dumb)
    //    {
    //        Debug.Log(j);
           
    //    }
    //    sum += dumb[0];
    //    sum += dumb[1];
    //    sum += dumb[2];
    //    Debug.Log(dumb.Count);
    //    Debug.Log(sum);
    //}
   
}
