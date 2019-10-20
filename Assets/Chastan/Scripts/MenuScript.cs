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
    GameObject fade;

    CanvasGroup fadeAlpha;

    Slider volumeBar;

    Toggle fullscreenToggle;

    TextMeshProUGUI volume;
    TextMeshProUGUI resolution;
    TextMeshProUGUI quality;
    TextMeshProUGUI highscore;

    AudioSource GUISounds;
    AudioSource BackgroundMusic;
    AudioSource Fire;

    readonly int[] widths = new int[5]{640, 1024, 1280, 1920, 2560};
    readonly int[] heights = new int[5]{360, 576, 720, 1080, 1440};

    string[] names;
    string scene = "NULL";

    int qualityIndex = 0;
    int maxQualityIndex = 0;
    int currentIndex = 0;
    readonly int maxIndex = 4;

    float timer = 0f;
    float fadeTimer = 3f;

    bool loadScene = false;

    // Start is called before the first frame update
    void Start()
    {
       
        GUISounds = GameObject.Find("GUI Sounds").GetComponent<AudioSource>();
        BackgroundMusic = GetComponent<AudioSource>();
        //Fire = GameObject.Find("CampFire").GetComponent<AudioSource>();

        names = QualitySettings.names;

        foreach (string qualityLevel in names)
        {
            qualityIndex++;
        }

        maxQualityIndex = qualityIndex;
        qualityIndex = 0;

        titlePage = GameObject.Find("Title Page");
        settingsPage = GameObject.Find("Settings Page");
        fade = GameObject.Find("Fade");

        fadeAlpha = fade.GetComponent<CanvasGroup>();

        volume = GameObject.Find("Volume Value").GetComponent<TextMeshProUGUI>();
        resolution = GameObject.Find("Resolution").GetComponent<TextMeshProUGUI>();
        quality = GameObject.Find("Current Quality").GetComponent<TextMeshProUGUI>();
        highscore = GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>();

        volumeBar = GameObject.Find("Volume Slider").GetComponent<Slider>();
        fullscreenToggle = GameObject.Find("Fullscreen").GetComponent<Toggle>();

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore.text = ("HIGHSCORE: " + PlayerPrefs.GetInt("Highscore") + " SECONDS");
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", 0);
            highscore.text = "HIGHSCORE: 0 SECONDS";
        }

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

        BackgroundMusic.volume = (PlayerPrefs.GetFloat("Volume") / 200f);
        GUISounds.volume = (PlayerPrefs.GetFloat("Volume") / 100);
        //Fire.volume = (PlayerPrefs.GetFloat("Volume") / 175f);

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
            currentIndex = 3 - 1;
            Screen.SetResolution(widths[currentIndex], heights[currentIndex], Screen.fullScreen);
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (widths[currentIndex].ToString() + " x " + heights[currentIndex].ToString());
        }
        else
        {
            currentIndex = PlayerPrefs.GetInt("Resolution");
            Screen.SetResolution(widths[currentIndex], heights[currentIndex], Screen.fullScreen);
            resolution.text = (widths[currentIndex].ToString() + " x " + heights[currentIndex].ToString());
        }

        if (!PlayerPrefs.HasKey("Quality"))
        {
            QualitySettings.SetQualityLevel(maxQualityIndex-1);
            PlayerPrefs.SetString("Quality", names[maxQualityIndex-1]);
            quality.text = names[maxQualityIndex-1].ToUpper();
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

            QualitySettings.SetQualityLevel(qualityIndex - 1);
            quality.text = names[qualityIndex - 1].ToUpper();
        }

        Debug.Log("Volume: " + PlayerPrefs.GetFloat("Volume") + ", Fullscreen: " +  PlayerPrefs.GetInt("Fullscreen") + ", Resolution: " + widths[currentIndex].ToString() + " x " + heights[currentIndex].ToString() + ", Quality: " + PlayerPrefs.GetString("Quality") + ".");

        titlePage.SetActive(true);
        settingsPage.SetActive(false);
        fadeAlpha.alpha = 0f;
        fade.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Resolution[] resolutions = Screen.resolutions;

        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            Debug.Log("Volume: " +  volumeBar.value + ", Fullscreen: " + PlayerPrefs.GetInt("Fullscreen") + ", Resolution: " + widths[currentIndex].ToString() + " x " + heights[currentIndex].ToString() + ", Quality: " + PlayerPrefs.GetString("Quality") + ".");
            timer = 0f;
        }

        if (loadScene)
        {
            fadeTimer -= Time.deltaTime;

            fadeAlpha.alpha = 1f - (fadeTimer / 3);

            AudioSource[] sources = FindObjectsOfType<AudioSource>();

            foreach (AudioSource source in sources)
            {
                if (source.volume > 0f)
                {
                    source.volume -= (source.volume * Time.deltaTime);
                }
                else
                {
                    source.volume = 0f;
                }
            }

            if (fadeTimer <= 0f)
            {
                fadeAlpha.alpha = 1f;
                SceneManager.LoadScene(scene);
            }
        }
    }

    public void StartOnePlayer()
    {
        fade.SetActive(true);
        scene = "Multiplayer";
        loadScene = true;
    }

    /*public void StartTwoPlayer()
    {
        fade.SetActive(true);
        scene = "Multiplayer";
        loadScene = true;
    }

    public void ContinueOnePlayer()
    {
        fade.SetActive(true);
        scene = "Singeplayer";
        loadScene = true;
    }

    public void ContinueTwoPlayer()
    {
        fade.SetActive(true);
        scene = "Multiplayer";
        loadScene = true;
    }*/

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
        GUISounds.volume = (PlayerPrefs.GetFloat("Volume") / 100f);
        BackgroundMusic.volume = (PlayerPrefs.GetFloat("Volume") / 200f);
        //Fire.volume = (PlayerPrefs.GetFloat("Volume") / 150);
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
        if (currentIndex < maxIndex)
        {
            currentIndex++;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (widths[currentIndex].ToString() + " X " + heights[currentIndex].ToString());
        }
        else
        {
            currentIndex = 0;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (widths[currentIndex].ToString() + " X " + heights[currentIndex].ToString());
        }
    }

    public void ResDecrease()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (widths[currentIndex].ToString() + " X " + heights[currentIndex].ToString());
        }
        else
        {
            currentIndex = maxIndex;
            PlayerPrefs.SetInt("Resolution", currentIndex);
            resolution.text = (widths[currentIndex].ToString() + " X " + heights[currentIndex].ToString());
        }
    }

    public void QIncrease()
    {
        names = QualitySettings.names;

        if (qualityIndex < maxQualityIndex - 1)
        {
            qualityIndex++;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex].ToUpper();
        }
        else
        {
            qualityIndex = 0;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex].ToUpper();
        }
    }

    public void QDecrease()
    {
        names = QualitySettings.names;

        if (qualityIndex > 0)
        {
            qualityIndex--;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex].ToUpper();
        }
        else
        {
            qualityIndex = maxQualityIndex - 1;
            PlayerPrefs.SetString("Quality", names[qualityIndex]);
            quality.text = names[qualityIndex].ToUpper();
        }
    }

    public void SaveAndExit()
    {
        Screen.SetResolution(widths[currentIndex], heights[currentIndex], Screen.fullScreen);
        PlayerPrefs.Save();
        titlePage.SetActive(true);
        settingsPage.SetActive(false);
    }

    public void OnClick()
    {
        GUISounds.Play();
    }
}
