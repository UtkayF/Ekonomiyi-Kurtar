using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using System.IO;

public class GManager : MonoBehaviour
{
    public int randomNumberForRing;
    public int randomNumberForPosition;
    public bool setSpawn = false;
    public GameObject[] allRings;
    public Transform[] allPositions;
    private GameObject currentRings;
    private GameObject currentTransform;
    public bool GameStarted = false;

    [Header("UI")]
    public TextMeshProUGUI StartTimeText;
    public TextMeshProUGUI H_Bar_text;
    public int healthValue = 3;
    public GameObject GameOverScene;
    public GameObject StartGameSceneTT;
    public TextMeshProUGUI DolarEqualsWText;
    public TextMeshProUGUI LevelText;
    public GameObject WinGameScene;
    public Button HomeButton;
    public Button NextLevelButton;
    public Button HomeButtonGOS;
    public Button RestartButtonGOS;
    public TextMeshProUGUI ObjectPerNeagtiveMoneyText;


    [Header("Economy and LEVEL")]
    public int economyDiv = 2;
    public int levelNumber;
    public int economyNumber = 15;
    public float cuMoney;
    public float propsEarn;
    public TextMeshProUGUI LevelUpText;

    [Header("Game Music")]
    public int haveSound;
    public GameObject MusicGenerator;

    [Header("Pause Method")]
    public GameObject PauseLayer;
    public Button PauseBTN;
    public Button NextPlayBTNop;
    public Button HomeBTNop;
    public bool isPause = false;
    public Button ResetGameO;

    [Header("ADS")]
    public DeadAds dAds;
    public bool adsController = false;



    void Start()
    {

        dAds.LoadAd();

        if (PlayerPrefs.HasKey("levels"))
        {
            print("PLAYERPREFS BAŞARILI");
        }
        else
        {
            print("PLAYEPREFS YOKTU OLUŞTURULDU");
            PlayerPrefs.SetInt("levels", 1);
            PlayerPrefs.SetFloat("earns", 0.35f);
            PlayerPrefs.Save();
        }


        levelNumber = PlayerPrefs.GetInt("levels");
        propsEarn = PlayerPrefs.GetFloat("earns");
        cuMoney = (levelNumber * economyNumber) / economyDiv;
        cuMoney = cuMoney - 1;
        print("CuMONEY > " + cuMoney.ToString());
        DolarEqualsWText.text = "1$ " + cuMoney + "Cu";
        LevelText.text = levelNumber + " Level";
        ObjectPerNeagtiveMoneyText.text = "1 Eşya\n" + "-" + string.Format("{0:#0.00}", propsEarn) + "Cu";

        GameStarted = false;
        HomeButton.onClick.AddListener(GoHomeButton);
        NextLevelButton.onClick.AddListener(GoNextLevelButton);

        HomeButtonGOS.onClick.AddListener(GoHomeButton);
        RestartButtonGOS.onClick.AddListener(GoRestartButtonGOS);

        PauseBTN.onClick.AddListener(GoPauseButton);

        NextPlayBTNop.onClick.AddListener(GoPauseButton);
        HomeBTNop.onClick.AddListener(GoHomeButton);

        ResetGameO.onClick.AddListener(GoRestartButtonGOS);

        StartCoroutine(StartToGame());
    }

    

    void GoHomeButton()
    {
        print("HOME");
        SceneManager.LoadScene("Menu");
    }

    void GoNextLevelButton()
    {
        print("NEXT LEVEL");
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GoRestartButtonGOS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GoPauseButton()
    {
        isPause = !isPause;
        if(isPause == true)
        {
            GameStarted = false;
            PauseLayer.SetActive(true);
        }
        else
        {
            GameStarted = true;
            PauseLayer.SetActive(false);
        }
    }

    void Update()
    {

        // PlayerPrefs.DeleteAll();

        haveSound = PlayerPrefs.GetInt("sound", 1);
        if(haveSound == 1)
        {
            MusicGenerator.SetActive(true);
        }
        else
        {
            MusicGenerator.SetActive(false);
        }

        if(healthValue >= 0 && healthValue <= 3)
        {
            H_Bar_text.text = healthValue.ToString();
        }
        else
        {
            H_Bar_text.text = "0";
        }
       

        if (cuMoney <= 1)
        {
            DolarEqualsWText.text = "1$ "+"1Cu";
        }
        else 
        {
            DolarEqualsWText.text = "1$ " + string.Format("{0:#0.00}", cuMoney) + "Cu";
        }

        if (cuMoney <= 1)
        {
            print("Win");
            //Time.timeScale = 0;-
            if(levelNumber == 40)
            {
                LevelUpText.text = "Oyun bitti!";
                PlayerPrefs.SetInt("levels", 40);
                PlayerPrefs.Save();
            }
            else
            {
                PlayerPrefs.SetInt("levels", levelNumber + 1);
                PlayerPrefs.SetFloat("earns", propsEarn + 0.65f);
                PlayerPrefs.Save();
            }
            
            GameStarted = false;
            WinGameScene.SetActive(true);
        }


        if (healthValue == 0)
        {
            print("GameOver");
            //Time.timeScale = 0;
            GameStarted = false;
            GameOverScene.SetActive(true);

            adsController = true;
            if (adsController == true)
            {
                dAds.ShowAd();
                adsController = false;
                healthValue = -1;
            }
        }


        if (setSpawn == true)
        {
            randomNumberForRing = Random.Range(0, allRings.Length);
            randomNumberForPosition = Random.Range(0, allPositions.Length);
            print("RING > " + randomNumberForRing);
            print("POSITION > " + randomNumberForPosition);

            currentRings = allRings[randomNumberForRing];
            currentTransform = allPositions[randomNumberForPosition].gameObject;
            Quaternion quaCR = currentRings.transform.rotation;
            Instantiate(allRings[randomNumberForRing], currentTransform.gameObject.transform.position, quaCR);

            setSpawn = false;
        }
    }

    IEnumerator StartToGame()
    {
        StartTimeText.text = "5";
        yield return new WaitForSeconds(1);
        StartTimeText.text = "4";
        yield return new WaitForSeconds(1);
        StartTimeText.text = "3";
        yield return new WaitForSeconds(1);
        StartTimeText.text = "2";
        yield return new WaitForSeconds(1);
        StartTimeText.text = "1";
        yield return new WaitForSeconds(1);
        StartTimeText.text = "Başla!";
        GameStarted = true;
        yield return new WaitForSeconds(0.5f);
        StartGameSceneTT.SetActive(false);


    }


}
