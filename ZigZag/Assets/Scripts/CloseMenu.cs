using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI TimeToResum;
    public GameObject time;
    public Image img;
    public GameObject LoseMenu;

    private async Task TimeAfterResum()
    {
        Time.timeScale = 1f;
        time.SetActive(true);
        Time.timeScale = 0f;
        TimeToResum.text = "3";
        await Task.Delay(1000);
        TimeToResum.text = "2";
        await Task.Delay(1000);
        TimeToResum.text = "1";
        await Task.Delay(1000);


    }
    private void Update()
    {
        if ( LoseMenu.active == true||TimeToResum.IsActive())
        {
            img.enabled = false;

            return;
        }

        if (LoseMenu.active == false || !TimeToResum.IsActive())
        {
            img.enabled = true;

            return;
        }
    }


    private void Start()
    {
        time.SetActive(false);
        menu.active = false;
    }
    public void OnMenu()
    {

        Time.timeScale = 0f;
        menu.SetActive(true);


    }
    public void Quit()
    {
        Application.Quit();
    }
    public async void Resume()
    {

        TimeToResum.text = "3";
        menu.SetActive(false);
        await TimeAfterResum();
        Time.timeScale = 1f;
        time.SetActive(false);


    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}