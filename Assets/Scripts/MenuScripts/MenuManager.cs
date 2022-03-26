using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Menu UI")]
    public Button PlayBTN;
    public Button SettingsBTN;

    [Header("Settings UI")]
    public GameObject SettingsLayer;
    public Button GameSoundBTN;
    public TextMeshProUGUI GameSoundBTN_Text;
    public Button SettingsCloseBTN;

    [Header("Game Sound Value")]
    public int haveSound;
    public GameObject MenuSoundManager;

    void Awake()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            print("Ses için prefs var.");
        }
        else
        {
            print("Ses için prefs yok ilk giriş");
            PlayerPrefs.SetInt("sound", 1); // TRUE
        }
    }

    void Start()
    {
        PlayBTN.onClick.AddListener(PlayMethod);
        SettingsBTN.onClick.AddListener(SettingsMethod);
        GameSoundBTN.onClick.AddListener(GameSoundMethod);
        SettingsCloseBTN.onClick.AddListener(SettingsCloseMethod);
    }

    void Update()
    {
        haveSound = PlayerPrefs.GetInt("sound", 1);
        if(haveSound == 1)
        {
            MenuSoundManager.SetActive(true);
            GameSoundBTN_Text.text = "Açık";
        }
        else
        {
            MenuSoundManager.SetActive(false);
            GameSoundBTN_Text.text = "Kapalı";
        }
    }

    void PlayMethod()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void SettingsMethod()
    {
        PlayBTN.gameObject.SetActive(false);
        SettingsBTN.gameObject.SetActive(false);
        SettingsLayer.SetActive(true);
    }

    void SettingsCloseMethod()
    {
        SettingsLayer.SetActive(false);
        PlayBTN.gameObject.SetActive(true);
        SettingsBTN.gameObject.SetActive(true);
    }

    void GameSoundMethod()
    {
        if (haveSound == 1)
            PlayerPrefs.SetInt("sound", 0);

        if (haveSound == 0)
            PlayerPrefs.SetInt("sound", 1);
    }

}
