using System;
using TMPro;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public int PlayerPoint;
    public Text pointText;
    public TextMeshProUGUI totalPoint;
    public TextMeshProUGUI pointInterpretation;
    public static int Auras = 3;
    public Sprite auraLive;
    public Sprite auraDeath;
    public Image[] auraIcons;
    public Text TextbookCollected, LunchboxCollected, MinimartCollected;
    private int CountTextbook, CountLunchbox, CountMinimart;
    public GameObject EndGame;
    public bool isGameActive;
    [ContextMenu("IncreasePoint")]
    void Awake()
    {
        Auras = 3;
    }
    void Update()
    {
        foreach (Image img in auraIcons)
        {
            img.sprite = auraDeath;
        }
        for (int i = 0; i < Auras; i++)
        {
            auraIcons[i].sprite = auraLive;
        }
    }
    public void TakeDamage(int damageValue)
    {
        Auras = Auras - damageValue;
    }
    public void addPoint(int pointToAdd)
    {
        PlayerPoint = Mathf.Max(0,PlayerPoint + pointToAdd);
        pointText.text = PlayerPoint.ToString();
    }
    public void addTextbookCount(int TextbookAmount)
    {
        CountTextbook = Mathf.Max(0,CountTextbook + TextbookAmount);
        TextbookCollected.text = CountTextbook.ToString();
    }
        public void addLunchboxCount(int LunchboxAmount)
    {
        CountLunchbox = Mathf.Max(0,CountLunchbox + LunchboxAmount);
        LunchboxCollected.text = CountLunchbox.ToString();
    }
       public void addMinimartCount(int MinimartAmount)
    {
        CountMinimart = Mathf.Max(0,CountMinimart + MinimartAmount);
        MinimartCollected.text = CountMinimart.ToString();
    }
    public void playAgain()
    {
        Time.timeScale = 1f;
        SonicManager.instance.PlaySound("Clicked");
        SceneManager.LoadScene("Gameplay",LoadSceneMode.Single);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SonicManager.instance.PlaySound("Clicked");
        SceneManager.LoadScene("PlayMenu",LoadSceneMode.Single);
    }
    public void Play()
    {
        Time.timeScale = 1f;
        SonicManager.instance.PlaySound("Clicked");
        SceneManager.LoadScene("Gameplay",LoadSceneMode.Single);
    }
    public void gameOver()
    {
        if(Auras <=0)
        {
            totalPoint.text = PlayerPoint.ToString() + " " + "Points";

            if (PlayerPoint == 0)
            {
                if(CountTextbook == 0)
                {
                    pointInterpretation.text = "Are you serious?";
                }
                if(CountLunchbox == 1)
                {
                    pointInterpretation.text = "Let's lift this up in prayer.";
                }
                if(CountMinimart !=0)
                {
                    pointInterpretation.text = "Have you ever crossing a collapsing bridge to go to school?";
                }
            } else if (PlayerPoint != 0)
            {
                if(CountTextbook == 0)
                {
                    pointInterpretation.text = "Who are you?";
                }
                if(PlayerPoint >= CountTextbook && CountTextbook > CountLunchbox && CountTextbook > CountMinimart && (CountLunchbox >= CountMinimart || CountLunchbox <= CountMinimart))
                {
                    pointInterpretation.text = "You supported" + " " + CountTextbook.ToString() + " " + "students. Let's continue! They are our future leaders!";
                }
                if(PlayerPoint >= CountLunchbox && CountLunchbox > CountTextbook && CountLunchbox > CountMinimart && (CountTextbook >= CountMinimart || CountTextbook <= CountMinimart))
                {
                    pointInterpretation.text = "Hopefully" + " " + CountLunchbox.ToString() + " " + "student have a strong stomach. They still have homeworks!";
                }
                if(PlayerPoint >= CountMinimart && CountMinimart > CountTextbook && CountMinimart > CountLunchbox && (CountTextbook >= CountLunchbox || CountTextbook <= CountLunchbox))
                {
                    pointInterpretation.text = "Hmm, you actually have power to build" + " " + CountMinimart.ToString() + " " + "schools instead, right?";
                }
            }else
            {
                pointInterpretation.text = "What are you doing?";
            }
            EndGame.SetActive(true);
        }
        SonicManager.instance.PlaySound("GameCompleted");
        isGameActive = false;
        Time.timeScale = 0;
    }
}