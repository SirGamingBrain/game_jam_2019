using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public GameObject player;
   // public GameObject Pickup1;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject[] interactions = new GameObject[0];


    public Camera FPV_Camera;

    public Rigidbody rb;

    public float speed;

   
    GameObject clone;
    // string selectionName;

     //[SerializeField]
    public string selectionName;
    public string selectedIngredient;

    float rotateY;
    float rotateX;
    float minY = -90.0f, maxY = 90.0f;
    float sensitivity = 3f;
    float dist;


    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
       // selectionName = gameObject.GetComponent<GameObject>().name;
        interactions = GameObject.FindGameObjectsWithTag("Interactable");
        Cursor.lockState = CursorLockMode.Locked;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Interactions();

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
       
        
    }

    void Movement()
    {
        rotateY = Mathf.Clamp(rotateY, minY, maxY);
        FPV_Camera.transform.rotation = Quaternion.Euler(-rotateY, rotateX, 0);
        transform.rotation = Quaternion.Euler(0, rotateX, 0);

        rotateX += (Input.GetAxis("Mouse X") * sensitivity);
        rotateY += (Input.GetAxis("Mouse Y") * sensitivity);


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && leftHand.transform.childCount == 1)
        {
            Debug.Log("using left hand"); 
            leftHand.transform.Translate(Vector3.forward * 25 * Time.deltaTime);
            Detection();
            StartCoroutine(Left());

        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && rightHand.transform.childCount == 1)
        {
            Debug.Log("using right hand");
            rightHand.transform.Translate(Vector3.forward * 25 * Time.deltaTime);
            Detection();
            StartCoroutine(Right());
           
        }

        if (Input.GetKeyDown(KeyCode.Space) && leftHand.transform.childCount == 1 && rightHand.transform.childCount == 1)
        {
            Destroy(leftHand.transform.GetChild(0).gameObject);
            Destroy(rightHand.transform.GetChild(0).gameObject);
        }
    }

    void Interactions()
    {
        //for(int i = 0; i < interactions.Length; i++)
        //{
        //    dist = Vector3.Distance(this.transform.position, interactions[i].transform.position);
        //    //Debug.Log(dist);
        //    if (dist <= 1.75f)
        //    {

        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            if (leftHand.transform.childCount == 0 )
        //            {
        //                clone = Instantiate(interactions[i], leftHand.transform.position, interactions[i].transform.rotation);
        //                clone.transform.parent = leftHand.transform;
        //            }


        //            else if (leftHand.transform.childCount > 0 && rightHand.transform.childCount == 0 )
        //            {
        //                clone = Instantiate(interactions[i], rightHand.transform.position, interactions[i].transform.rotation);
        //                clone.transform.parent = rightHand.transform;
        //            }

        //            if (leftHand.transform.childCount == 1 && rightHand.transform.childCount == 1)
        //            {
        //                Debug.Log("Hands are full fam!");
        //            }

        //        }
        //    }
        //}

        var ray = FPV_Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            var hitObj = hit.transform;
            selectedIngredient = hitObj.gameObject.name;
            if (hitObj.CompareTag("Interactable"))
            {
                if (selectedIngredient != null)
                {
                    Debug.Log(selectedIngredient);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (leftHand.transform.childCount == 0)
                        {
                            clone = Instantiate(hitObj.gameObject, leftHand.transform.position, hitObj.transform.rotation);
                            clone.transform.parent = leftHand.transform;
                        }


                        else if (leftHand.transform.childCount > 0 && rightHand.transform.childCount == 0)
                        {
                            clone = Instantiate(hitObj.gameObject, rightHand.transform.position, hitObj.transform.rotation);
                            clone.transform.parent = rightHand.transform;
                        }

                        if (leftHand.transform.childCount == 1 && rightHand.transform.childCount == 1)
                        {
                            Debug.Log("Hands are full fam!");
                        }
                    }
                }


            }
        }

    }

  

    IEnumerator Left()
    {
        yield return new WaitForSeconds(1f);
        leftHand.transform.Translate(Vector3.back * 25 * Time.deltaTime);
        Destroy(leftHand.transform.GetChild(0).gameObject);
    }

    IEnumerator Right()
    {
        yield return new WaitForSeconds(1f);
        rightHand.transform.Translate(Vector3.back * 25 * Time.deltaTime);
        Destroy(rightHand.transform.GetChild(0).gameObject);
    }

    void Detection()
    {
        var ray = FPV_Camera.ScreenPointToRay(Input.mousePosition + (Vector3.left * 100f));
       // var ray2 = FPV_Camera.ScreenPointToRay(Input.mousePosition + (Vector3.right * 100f));
   
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            selectionName = selection.gameObject.name;
            if (selectionName != null)
            {
                Debug.Log(selectionName);
                Debug.DrawRay(ray.origin, Vector3.forward, Color.yellow, 5f);
            }
        }
          
    }

}

