using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button selectorButton;
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button backButton;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelSelector()
    {
        level1Button.gameObject.SetActive(true);
        level2Button.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        selectorButton.gameObject.SetActive(false);
    }

    public void PlayScene()
    {
        playButton.gameObject.SetActive(true);
        selectorButton.gameObject.SetActive(true);
        level1Button.gameObject.SetActive(false);
        level2Button.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }   

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

}
