using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public bool isGameStarted;
    public GameObject platformSpawner;
    public GameObject but;


    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;
    public TextMeshProUGUI DiamondText;
   // public TextMeshProUGUI startText;

    [Header("GameOver")]
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] TextMeshProUGUI lastScoreText;


    int score = 0;

   private int bestScore, totalDiamond, totalStar;
    bool countScore;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        but.SetActive(true);
        //totalDiamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
       
        DiamondText.text= totalDiamond.ToString();
        //totalStar

        //bestScore
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();
    }
    public void ButtonDown()
    {
        but.SetActive(false);
        GameStart();
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }


    public void GameStart()
    {
        Time.timeScale = 1f ;
        countScore = true;
        isGameStarted = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        StartCoroutine(WaitBeforeGameOver());
       
        GameOverPanel.SetActive(true);
        
        lastScoreText.text = score.ToString();
        countScore = false;
        isGameStarted = false;
        platformSpawner.SetActive(false);
        if (score>bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
    }
    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1);
            score++;
            if (score>bestScore)
            {
                bestText.text = score.ToString();
            }
            
            scoreText.text = score.ToString();
        }
    }


    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GetDiamond()
    {
         totalDiamond++;
        PlayerPrefs.SetInt("Diamond", totalDiamond);
        DiamondText.text = totalDiamond.ToString();
    }
    IEnumerator WaitBeforeGameOver()
    {

        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0f;

    }
}
