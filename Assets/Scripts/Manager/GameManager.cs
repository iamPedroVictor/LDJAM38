using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    private static GameManager _instance;

    private float playerPoint;

    public Crystals[] crystals;

    public GameObject WinPanel, GameOverPanel, GamePlay;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        crystals = GameObject.FindObjectsOfType<Crystals>();
    }

    private void Start()
    {
        playerPoint = 0;
        
    }



    public void AddPoint(float value)
    {
        playerPoint += value;
    }

    public void Win()
    {
        print("Venci");
        Time.timeScale = 0;
        GamePlay.SetActive(false);
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    public void CheckVitory(int crystal)
    {
        if(crystal >= crystals.Length)
        {
            Win();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GamePlay.SetActive(false);
        GameOverPanel.SetActive(true);
        WinPanel.SetActive(false);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

}
