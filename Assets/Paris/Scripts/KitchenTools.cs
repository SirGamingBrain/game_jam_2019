using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTools : MonoBehaviour
{
    public GameObject Cauldron;
    public GameObject Mixer;
    public GameObject Extractor;
    public GameObject Oven;

    public Transform OvenSpawn;
    public Transform ExtractorSpawn;
    public Transform GrinderSpawn;
    public Transform PotionSpawn;

    GameObject player;
    GameObject clone;
    GameObject temp_Item;

    List<string> GrindedItems = new List<string>();
    List<string> BakedItems = new List<string>();
    List<string> ExtractedItems = new List<string>();
    List<string> Potions = new List<string>();

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

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Temp Player");
        Transform lHand = player.GetComponentInChildren(typeof(Transform)) as Transform;
        Transform rHand = player.GetComponentInChildren(typeof(Transform)) as Transform;


    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.P))
        //{
            
        //    baking();
        //    mixing();
        //    extracting();
        //    cauldron();
        //    Combinations();
        //    num = 0;

        //}

        if (FurnaceItems.Count >= 1|| GrindingItems.Count >= 1 || ExtractorItems.Count >= 1)
        {
            Combinations();
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

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ObjectsName = other.gameObject.name;
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
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Strength Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           

        }

        if (CauldronItems.ContainsKey("Power Stone(Clone)") && CauldronItems.ContainsKey("Eternal Flame(Clone)") && CauldronItems.ContainsKey("Blackeye Sugar(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Manna Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Light Spirit(Clone)") && CauldronItems.ContainsKey("Blood Rose Sugar(Clone)") && CauldronItems.ContainsKey("Smooth Horn(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Healing Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Empty Vessel(Clone)") && CauldronItems.ContainsKey("Eternal Flame(Clone)") && CauldronItems.ContainsKey("Blood Rose Petals(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Revive Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Venom(Clone)") && CauldronItems.ContainsKey("Dark Spirit(Clone)") && CauldronItems.ContainsKey("Draconic Dust(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Poison Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Moon Sugar(Clone)") && CauldronItems.ContainsKey("Blood Rose Sugar(Clone)") && CauldronItems.ContainsKey("Blackeye Sugar(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Speed Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
          
        }
        if (CauldronItems.ContainsKey("Moon Petals(Clone)") && CauldronItems.ContainsKey("Cyclops Tears(Clone)") && CauldronItems.ContainsKey("Rage of the Dragon(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Stamina Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Iris Extract(Clone)") && CauldronItems.ContainsKey("Crystal Eye(Clone)") && CauldronItems.ContainsKey("Mini Star(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Perception Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }

        if (CauldronItems.ContainsKey("Magic Powder(Clone)") && CauldronItems.ContainsKey("Draconic Dust(Clone)") && CauldronItems.ContainsKey("Gold Seeds(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Exp Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Moon Sugar(Clone)") && CauldronItems.ContainsKey("Sun Petals(Clone)") && CauldronItems.ContainsKey("Nova Core(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Jumping Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Goo(Clone)") && CauldronItems.ContainsKey("Scales(Clone)") && CauldronItems.ContainsKey("Cyclops Tears(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Underwater Breathing Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Blood Rose Petals(Clone)") && CauldronItems.ContainsKey("Magic Powder(Clone)") && CauldronItems.ContainsKey("Fungus(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Potion of Life");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Blood Seeds(Clone)") && CauldronItems.ContainsKey("Magic Powder(Clone)") && CauldronItems.ContainsKey("Rage of the Dragon(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Seeds of Necromancy");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Smooth Horn(Clone)") && CauldronItems.ContainsKey("Venom(Clone)") && CauldronItems.ContainsKey("Nova Core(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Death Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }
        if (CauldronItems.ContainsKey("Mini Star(Clone)") && CauldronItems.ContainsKey("Moon Sugar(Clone)") && CauldronItems.ContainsKey("Magic Powder(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                Debug.Log("Swimming Speed Potion");
                CauldronItems.Remove(ObjectsName);
                timer = 0;
            }
           
        }

        //Grinding Section
        if (GrindingItems.ContainsKey("Dragon Horn(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Smooth Horn");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Smooth Horn");
                timer = 0;
                Debug.Log(timer);
               // temp_Item.name = GrindedItems[0];
                if (GrindedItems.Count == 1)
                {
                    clone = Instantiate(temp_Item.gameObject, GrinderSpawn.transform.position, temp_Item.transform.rotation);
                    //clone.transform.parent = leftHand.transform;
                }


            }
           
        }
        if (GrindingItems.ContainsKey("Cyclops Eye(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Cyclops Tears");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Cyclops Tears");
                timer = 0;
            }
            
        }
        if (GrindingItems.ContainsKey("Undead Soul(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Empty Vessel");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Empty Vessel");
                timer = 0;
            }
           
        }
        if (GrindingItems.ContainsKey("Blood Rose(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Blood Rose Petals");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Blood Rose Petals");
                timer = 0;
            }
           
        }
        if (GrindingItems.ContainsKey("Blackeyed Gold(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Sun Petals");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Sun Petals");
                timer = 0;
            }
           
        }
        if (GrindingItems.ContainsKey("Blooming Moon(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Moon Petals");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Moon Petals");
                timer = 0;
            }
           
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
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Scales");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Scales");
                timer = 0;
            }
           
        }
        if (GrindingItems.ContainsKey("Magic Mushrooms(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Magic Powder");
                GrindingItems.Remove(ObjectsName);
                GrindedItems.Add("Magic Powder");
                timer = 0;
            }
           
           
        }
        //Grinding Ends

        //Extraction Section
        if (ExtractorItems.ContainsKey("Dragon Horn(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Rage of the Dragon");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Rage of the Dragon");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Cyclops Eye(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Iris Extract");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Iris Extract");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Undead Soul(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Light Spirit");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Light Spirit");
                timer = 0;
            }
         
        }
        if (ExtractorItems.ContainsKey("Blood Rose(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Blood Seeds");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Blood Seeds");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Blackeyed Gold(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Gold Seeds");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Blood Seeds");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Blooming Moon(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Moon Seeds");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Moon Seeds");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Dark Matter(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Nova Core");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Nova Core");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Volcanic Core(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("External Flame");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("External Flame");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Snake(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Venom");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Venom");
                timer = 0;
            }
           
        }
        if (ExtractorItems.ContainsKey("Magic Mushrooms(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                Debug.Log("Fungus");
                ExtractorItems.Remove(ObjectsName);
                ExtractedItems.Add("Fungus");
                timer = 0;
            }
           
        }
        //Extraction Ends


        //Baking Section
        if (FurnaceItems.ContainsKey("Dragon Horn(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Draconic Dust");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Draconic Dust");
                timer = 0;
            }
           
        }
        if (FurnaceItems.ContainsKey("Cyclops Eye(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Crystal Eye");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Crystal Eye");
                timer = 0;
            }
           
        }
        if (FurnaceItems.ContainsKey("Undead Soul(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Dark Spirit");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Dark Spirit");
                timer = 0;
            }
           
        }
        if (FurnaceItems.ContainsKey("Blood Rose(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Blood Rose Sugar");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Blood Rose Sugar");
                timer = 0;
            }
           
        }
        if (FurnaceItems.ContainsKey("Blackeyed Gold(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Blackeye Sugar");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Blackeye Sugar");
                timer = 0;
            }
          
        }
        if (FurnaceItems.ContainsKey("Blooming Moon(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Moon Sugar");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Moon Sugar");
                timer = 0;
            }
           
        }
        if (FurnaceItems.ContainsKey("Dark Matter(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Mini Star");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Mini Star");
                timer = 0;
            }
           
        }
        if (FurnaceItems.ContainsKey("Volcanic Ore(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Power Stone");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("Power Stone");
                timer = 0;
            }
           
        }
        if (FurnaceItems.ContainsKey("Snake(Clone)"))
        {
            Debug.Log("What's wrong with you.. you can't bake a snake!");
            FurnaceItems.Remove(ObjectsName);
        }
        if (FurnaceItems.ContainsKey("Magic Mushrooms(Clone)"))
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Debug.Log("Goo");
                FurnaceItems.Remove(ObjectsName);
                BakedItems.Add("God");
                timer = 0;
            }
           
        }
        //Baking Ends

    }
}
