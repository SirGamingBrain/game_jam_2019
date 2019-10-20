using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerUIScript : MonoBehaviour
{
    GameObject playerUI;
    GameObject settingsPage;
    GameObject fade;
    GameObject dayText;

    CanvasGroup fadeAlpha;
    CanvasGroup dayAlpha;

    Slider volumeBar;

    Toggle fullscreenToggle;

    TextMeshProUGUI volume;
    TextMeshProUGUI resolution;
    TextMeshProUGUI quality;
    TextMeshProUGUI interaction;
    TextMeshProUGUI objectOne;
    TextMeshProUGUI objectTwo;
    TextMeshProUGUI currentDay;
    TextMeshProUGUI timeSurvived;

    AudioSource GUISounds;
    AudioSource backgroundMusic;

    readonly int[] widths = new int[5] { 640, 1024, 1280, 1920, 2560 };
    readonly int[] heights = new int[5] { 360, 576, 720, 1080, 1440 };

    string[] names;

    int qualityIndex = 0;
    int maxQualityIndex = 0;
    int currentIndex = 0;
    readonly int maxIndex = 4;
    int strikes = 0;

    float fadeTimer = 3f;
    float levelTimer = 0f;

    bool startLevel = false;
    bool loadScene = false;
    bool fadeDay = false;
    bool playChime = false;
    bool timerGoing = false;

    // Start is called before the first frame update
    void Start()
    {
        GUISounds = GameObject.Find("GUI Sounds").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();

        names = QualitySettings.names;

        foreach (string qualityLevel in names)
        {
            qualityIndex++;
        }

        maxQualityIndex = qualityIndex;
        qualityIndex = 0;

        playerUI = GameObject.Find("First Layer");
        settingsPage = GameObject.Find("Settings Page");
        fade = GameObject.Find("Fade");
        dayText = GameObject.Find("DayLabel");

        fadeAlpha = fade.GetComponent<CanvasGroup>();
        dayAlpha = dayText.GetComponent<CanvasGroup>();

        volume = GameObject.Find("Volume Value").GetComponent<TextMeshProUGUI>();
        resolution = GameObject.Find("Resolution").GetComponent<TextMeshProUGUI>();
        quality = GameObject.Find("Current Quality").GetComponent<TextMeshProUGUI>();
        interaction = GameObject.Find("Interaction").GetComponent<TextMeshProUGUI>();
        objectOne = GameObject.Find("Object 1").GetComponent<TextMeshProUGUI>();
        objectTwo = GameObject.Find("Object 2").GetComponent<TextMeshProUGUI>();
        currentDay = dayText.GetComponent<TextMeshProUGUI>();
        timeSurvived = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();

        timeSurvived.text = "00:00";

        currentDay.text = "Make Money Magic Man!";

        interaction.text = "";
        objectOne.text = "";
        objectTwo.text = "";

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

        //Audiosources here.
        backgroundMusic.volume = (PlayerPrefs.GetFloat("Volume")/100);
        GUISounds.volume = (PlayerPrefs.GetFloat("Volume") / 100);

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
            QualitySettings.SetQualityLevel(maxQualityIndex - 1);
            PlayerPrefs.SetString("Quality", names[maxQualityIndex - 1]);
            quality.text = names[maxQualityIndex - 1].ToUpper();
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

        AudioSource[] sources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in sources)
        {
            source.volume = 0f;
        }

        Debug.Log("Volume: " + PlayerPrefs.GetFloat("Volume") + ", Fullscreen: " + PlayerPrefs.GetInt("Fullscreen") + ", Resolution: " + widths[currentIndex].ToString() + " x " + heights[currentIndex].ToString() + ", Quality: " + PlayerPrefs.GetString("Quality") + ".");

        playerUI.SetActive(true);
        settingsPage.SetActive(false);
        fadeAlpha.alpha = 1f;
        fade.SetActive(true);
        dayText.SetActive(true);
        dayAlpha.alpha = 0f;
        startLevel = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.L) )
        {
            Settings();
            Cursor.lockState = CursorLockMode.None;
            //(!fadeDay && !startLevel)
        }

        if (startLevel)
        {
            fadeTimer -= Time.deltaTime;

            fadeAlpha.alpha = (fadeTimer / 3f);

            AudioSource[] sources = FindObjectsOfType<AudioSource>();

            foreach (AudioSource source in sources)
            {
                if (source.volume < (PlayerPrefs.GetFloat("Volume")/100f))
                {
                    source.volume += Time.deltaTime;
                }
                else
                {
                    source.volume = PlayerPrefs.GetFloat("Volume") / 100f;
                }
            }

            dayAlpha.alpha = (1f - (fadeTimer / 3f));

            if (fadeTimer <= 0f)
            {
                dayAlpha.alpha = 1f;
                fadeAlpha.alpha = 0f;
                fade.SetActive(false);
                fadeDay = true;
                startLevel = false;
                playChime = true;
            }
        }

        if (playChime)
        {
            //GUISounds.volume = (PlayerPrefs.GetFloat("Volume") / 200f);
            GUISounds.Play();
            playChime = false;
        }

        if (fadeDay == true)
        {
            dayAlpha.alpha -= Time.deltaTime/2f;

            if (dayAlpha.alpha <= 0f)
            {
                dayAlpha.alpha = 0f;
                dayText.SetActive(false);
                fadeDay = false;
                timerGoing = true;
            }
        }

        if (timerGoing && strikes < 5)
        {
            levelTimer += Time.deltaTime;

            float minutes = Mathf.Floor(levelTimer / 60);
            float seconds = (levelTimer % 60);

            timeSurvived.text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
        }

        if (loadScene)
        {
            fadeTimer -= Time.deltaTime/6;

            fadeAlpha.alpha = 1f - (fadeTimer / 3);

            AudioSource[] sources = FindObjectsOfType<AudioSource>();

            foreach (AudioSource source in sources)
            {
                if (source.volume > 0f)
                {
                    source.volume -= Time.deltaTime;
                }
                else
                {
                    source.volume = 0f;
                }
            }

            if (fadeTimer <= 0f)
            {
                fadeAlpha.alpha = 1f;
                SceneManager.LoadSceneAsync("Menu");
            }
        }
    }

    public void Settings()
    {
        settingsPage.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ExitGame()
    {
        PlayerPrefs.Save();
        fade.SetActive(true);
        loadScene = true;
    }

    public void VolumeSlider(Slider slider)
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        volume.text = (PlayerPrefs.GetFloat("Volume").ToString());
        GUISounds.volume = (PlayerPrefs.GetFloat("Volume") / 100);
        backgroundMusic.volume = (PlayerPrefs.GetFloat("Volume") / 100);
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

    public void SaveAndContinue()
    {
        Screen.SetResolution(widths[currentIndex], heights[currentIndex], Screen.fullScreen);
        PlayerPrefs.Save();
        Time.timeScale = 1f;
        settingsPage.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnClick()
    {
        GUISounds.Play();
    }
}
