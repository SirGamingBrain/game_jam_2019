using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    GameObject titlePage;
    GameObject settingsPage;
    GameObject confirmationPage;

    Slider volumeBar;

    Toggle fullscreenToggle;

    TextMeshProUGUI volume;
    TextMeshProUGUI resolution;
    TextMeshProUGUI quality;
    TextMeshProUGUI debugger;

    Resolution[] resolutions;

    string[] names;

    int qualityIndex = 0;
    int maxQualityIndex = 0;
    int index = 0;
    int currentIndex = 0;
    int maxIndex = 0;

    float timer = 0f;

    //Awake is called on script instantiation.
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            index++;
        }

        maxIndex = index;
        index = 0;

        names = QualitySettings.names;

        foreach (string qualityLevel in names)
        {
            qualityIndex++;
        }

        maxQualityIndex = qualityIndex;
        qualityIndex = 0;

        titlePage = GameObject.Find("Title Page");
        settingsPage = GameObject.Find("Settings Page");
        confirmationPage = GameObject.Find("Confirmation Page");

        volume = GameObject.Find("Volume Value").GetComponent<TextMeshProUGUI>();
        resolution = GameObject.Find("Resolution").GetComponent<TextMeshProUGUI>();
        quality = GameObject.Find("Current Quality").GetComponent<TextMeshProUGUI>();
        debugger = GameObject.Find("Debug Text").GetComponent<TextMeshProUGUI>();

        volumeBar = GameObject.Find("Volume Slider").GetComponent<Slider>();
        fullscreenToggle = GameObject.Find("Fullscreen").GetComponent<Toggle>();

        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 75);
            volumeBar.value = (PlayerPrefs.GetFloat("Volume"));
            volume.text = (PlayerPrefs.GetFloat("Volume").ToString());
        }
        else
        {
            volumeBar.value = (PlayerPrefs.GetFloat("Volume"));
            volume.text = (PlayerPrefs.GetFloat("Volume").ToString());
        }

        if (!PlayerPrefs.HasKey("Fullscreen"))
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
            Screen.fullScreen = true;
            fullscreenToggle.isOn = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("Fullscreen") == 1)
            {
                Screen.fullScreen = true;
                fullscreenToggle.isOn = true;
            }
            else
            {
                Screen.fullScreen = false;
                fullscreenToggle.isOn = false;
            }
        }

        if (!PlayerPrefs.HasKey("Resolution"))
        {
            foreach (Resolution Object in resolutions)
            {
                index++;

                if (Object.height == 720)
                {
                    currentIndex = index - 1;
                    Screen.fullScreen = false;

                    if (!fullscreenToggle.isOn)
                    {
                        Screen.SetResolution(resolutions[currentIndex].width, resolutions[currentIndex].height, false);
                    }
                    else
                    {
                        Screen.SetResolution(resolutions[currentIndex].width, resolutions[currentIndex].height, true);
                    }

                    PlayerPrefs.SetInt("Resolution", currentIndex);
                    resolution.text = (resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString());
                }
            }
        }
        else
        {
            currentIndex = PlayerPrefs.GetInt("Resolution");
            Screen.fullScreen = false;

            if (!fullscreenToggle.isOn)
            {
                Screen.SetResolution(resolutions[currentIndex].width, resolutions[currentIndex].height, false);
            }
            else
            {
                Screen.SetResolution(resolutions[currentIndex].width, resolutions[currentIndex].height, true);
            }

            resolution.text = (resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString());
        }

        if (!PlayerPrefs.HasKey("Quality"))
        {
            QualitySettings.SetQualityLevel(maxQualityIndex-1);
            PlayerPrefs.SetString("Quality", names[maxQualityIndex-1]);
            quality.text = names[maxQualityIndex-1];
        }
        else
        {
            foreach (string qLevel in names)
            {
                qualityIndex++;

                if (qLevel == PlayerPrefs.GetString("Quality"))
                {
                    break;
                }
            }

            //Debug.Log(qualityIndex - 1);
            QualitySettings.SetQualityLevel(qualityIndex - 1);
            quality.text = names[qualityIndex - 1];
        }

        Debug.Log("Volume: " + PlayerPrefs.GetFloat("Volume") + ", Fullscreen: " +  PlayerPrefs.GetInt("Fullscreen") + ", Resolution: " + resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString() + ", Quality: " + PlayerPrefs.GetString("Quality") + ".");

        titlePage.SetActive(true);
        settingsPage.SetActive(false);
        confirmationPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Resolution[] resolutions = Screen.resolutions;

        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            Debug.Log("Volume: " +  volumeBar.value + ", Fullscreen: " + PlayerPrefs.GetInt("Fullscreen") + ", Resolution: " + resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString() + ", Quality: " + PlayerPrefs.GetString("Quality") + ".");
            timer = 0f;
        }
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
        titlePage.SetActive(false);
        settingsPage.SetActive(true);
    }

    public void ExitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void VolumeSlider(Slider slider)
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        volume.text = (PlayerPrefs.GetFloat("Volume").ToString());
    }

    public void Fullscreen(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
    }

    public void ResIncrease()
    {
        Resolution[] resolutions = Screen.resolutions;

        if (currentIndex < maxIndex - 1)
        {
            currentIndex++;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString());
        }
        else
        {
            currentIndex = 0;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString());
        }

        debugger.text = "Clicked Up";
    }

    public void ResDecrease()
    {
        Resolution[] resolutions = Screen.resolutions;

        if (currentIndex > 0)
        {
            currentIndex--;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString());
        }
        else
        {
            currentIndex = maxIndex - 1;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (resolutions[currentIndex].width.ToString() + " x " + resolutions[currentIndex].height.ToString());
        }

        debugger.text = "Clicked Down";
    }

    public void QIncrease()
    {
        names = QualitySettings.names;

        if (qualityIndex < maxQualityIndex - 1)
        {
            qualityIndex++;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex];
        }
        else
        {
            qualityIndex = 0;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex];
        }
    }

    public void QDecrease()
    {
        names = QualitySettings.names;

        if (qualityIndex > 0)
        {
            qualityIndex--;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex];
        }
        else
        {
            qualityIndex = maxQualityIndex - 1;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex];
        }
    }

    public void SaveAndExit()
    {
        Resolution[] resolutions = Screen.resolutions;

        Screen.fullScreen = false;

        if (!fullscreenToggle.isOn)
        {
            Screen.SetResolution(resolutions[currentIndex].width, resolutions[currentIndex].height, false);
        }
        else
        {
            Screen.SetResolution(resolutions[currentIndex].width, resolutions[currentIndex].height, true);
        }

        PlayerPrefs.Save();
        titlePage.SetActive(true);
        settingsPage.SetActive(false);
    }
}
