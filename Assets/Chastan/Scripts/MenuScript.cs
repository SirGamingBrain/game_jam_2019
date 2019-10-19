using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    GameObject titlePage;
    GameObject settingsPage;
    GameObject confirmationPage;


    //Awake is called on script instantiation.
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        titlePage = GameObject.Find("Title Page");
        settingsPage = GameObject.Find("Settings Page");
        confirmationPage = GameObject.Find("Confirmation Page");

        titlePage.SetActive(true);
        settingsPage.SetActive(false);
        confirmationPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    public void StartOnePlayer()
    {

    }

    public void StartTwoPlayer()
    {

    }

    public void ContinueOnePlayer()
    {

    }

    public void ContinueTwoPlayer()
    {

    }

    public void Settings()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void VolumeSlider(Slider value)
    {

    }

    public void Fullscreen(Toggle value)
    {

    }

    public void ResIncrease()
    {

    }

    public void ResDecrease()
    {

    }

    public void QIncrease()
    {

    }

    public void QDecrease()
    {

    }
}
