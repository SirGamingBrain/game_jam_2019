using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {

    float nRand = 0;
    bool go = true;

    private void Start()
    {
        StartCoroutine("flicker", .05f);
    }

    void Update ()
    {
        //nRand = Random.Range(4f, 5f);
        //this.transform.GetComponent<Light>().intensity = nRand;
    }

    public IEnumerator flicker(float waitTime)
    {
        while (go) {
            nRand = Random.Range(3.5f, 5f);
            this.transform.GetComponent<Light>().intensity = nRand;

            yield return new WaitForSeconds(.05f);
        }
        go = false;
    }
}
