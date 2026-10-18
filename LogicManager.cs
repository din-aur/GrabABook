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
                if(CountMinimart != 0)
                {
                    pointInterpretation.text = "Can you build" + " " + CountMinimart.ToString() + " " + "schools instead?";
                }
            } else if(PlayerPoint != 0)
            {
                if(CountTextbook == 0)
                {
                    pointInterpretation.text = "Who are you?";
                }
                else if(CountTextbook > CountLunchbox && CountTextbook > CountMinimart)
                {
                    if(CountLunchbox > CountMinimart)
                    {
                        pointInterpretation.text = "You have supported" + " " + CountTextbook.ToString() + " " + "students, while" + " " + CountLunchbox.ToString() + " " + "student is seeking a doctor.";
                    } else
                    {
                        pointInterpretation.text = "You have supported" + " " + CountTextbook.ToString() + " " + "students, while" + " " + CountMinimart.ToString() + " " + "student is crossing a river to go to school.";
                    }
                }
                else if(CountMinimart > CountTextbook && CountMinimart > CountLunchbox)
                {
                    if(CountLunchbox > CountTextbook)
                    {
                        pointInterpretation.text = "It's definitely hard to cross a collapsing bridge with a stocmachache.";
                    } else
                    {
                        pointInterpretation.text = "How if you renovate" + " " + CountMinimart.ToString() + " " + "bridges instead?";
                    }
                } else
                {
                    pointInterpretation.text = "You have" + " " + PlayerPoint.ToString() + " " + "opportunities, but what are you doing?";
                }
            }else
            {
                pointInterpretation.text = "It's hard to say...";
            }
            EndGame.SetActive(true);
        }
        SonicManager.instance.PlaySound("GameCompleted");
        isGameActive = false;
        Time.timeScale = 0;
    }
}