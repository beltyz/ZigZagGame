using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void QuitGame()
   {
        Debug.Log("QuitGame");
        Application.Quit();
   }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("start");
    }
}
