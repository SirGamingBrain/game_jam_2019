using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTools : MonoBehaviour
{
    public GameObject Cauldron;
    public GameObject Mixer;
    public GameObject Extractor;


   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.name == "Cauldron" || this.gameObject.name == "Mixer" || this.gameObject.name == "Extractor")
        {
            if (collision.gameObject.name == "Pick up 1 (Clone)" || collision.gameObject.name== "Pick up 2 (Clone)" || collision.gameObject.name == "Pick up 3 (Clone)" || collision.gameObject.name ==" Pick up 4 (Clone)")
            {
                Debug.Log("you put it into whatever");
            }

        }
        //if (collision.gameObject.CompareTag("Pick up 1 (Clone)"))
        //{

        //}
    }

    void baking()
    {
    }

    void extracting()
    {
    }

    void mixing()
    {

    }

   
}
