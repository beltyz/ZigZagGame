using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public bool isGameStarted;
    public GameObject platformSpawner;
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
        isGameStarted = true;
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        isGameStarted = false;
        platformSpawner.SetActive(false);
    }
}
