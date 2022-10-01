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


    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;
    public TextMeshProUGUI DiamondText;
    public TextMeshProUGUI startText;

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
        //totalDiamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
       
        DiamondText.text= totalDiamond.ToString();
        //totalStar
        totalStar = PlayerPrefs.GetInt("totalStar");
        startText.text= totalStar.ToString();

        //bestScore
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
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
            yield return new WaitForSeconds(1f);
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
    public void GetStar()
    {
        totalStar++;
        PlayerPrefs.SetInt("totalStar", totalStar);
        startText.text = totalStar.ToString();
    }
    public void GetDiamond()
    {
       totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond", totalDiamond);
        DiamondText.text = totalDiamond.ToString();
    }
    IEnumerator WaitBeforeGameOver()
    {

        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0f;

    }
}
